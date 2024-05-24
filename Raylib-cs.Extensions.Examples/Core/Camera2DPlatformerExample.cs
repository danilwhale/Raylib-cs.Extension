namespace Raylib_cs.Extensions.Game.Core;

public class Camera2DPlatformerExample : IExample
{
    private const int Gravity = 400;
    private const float PlayerJumpSpeed = 350.0f;
    private const float PlayerHorSpeed = 200.0f;

    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        var player = new Player(new Vector2(400, 280), 0);
        EnvItem[] envItems =
        {
            new(new Rectangle(0, 0, 1000, 400), false, Color.LightGray),
            new(new Rectangle(0, 400, 1000, 200), true, Color.Gray),
            new(new Rectangle(300, 200, 400, 10), true, Color.Gray),
            new(new Rectangle(250, 300, 100, 10), true, Color.Gray),
            new(new Rectangle(650, 300, 100, 10), true, Color.Gray)
        };

        var camera = new Camera2D(new Vector2(screenWidth, screenHeight) / 2.0f, player.Position, 0.0f, 1.0f);

        // Store pointers to the multiple update camera functions
        CameraUpdaterDelegate[] cameraUpdaters =
        {
            UpdateCameraCenter,
            UpdateCameraCenterInsideMap,
            UpdateCameraCenterSmoothFollow,
            UpdateCameraEvenOutOnLanding,
            UpdateCameraPlayerBoundsPush
        };

        var cameraOption = 0;

        string[] cameraDescriptions =
        {
            "Follow player center",
            "Follow player center, but clamp to map edges",
            "Follow player center; smoothed",
            "Follow player center horizontally; update player center vertically after landing",
            "Player push camera on getting too close to screen edge"
        };

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose())
        {
            // Update
            //----------------------------------------------------------------------------------
            var deltaTime = GetFrameTime();

            UpdatePlayer(ref player, envItems, deltaTime);

            camera.Zoom += GetMouseWheelMove() * 0.05f;

            if (camera.Zoom > 3.0f) camera.Zoom = 3.0f;
            else if (camera.Zoom < 0.25f) camera.Zoom = 0.25f;

            if (IsKeyPressed(KeyboardKey.R))
            {
                camera.Zoom = 1.0f;
                player.Position = new Vector2(400, 280);
            }

            if (IsKeyPressed(KeyboardKey.C)) cameraOption = (cameraOption + 1) % cameraUpdaters.Length;

            // Call update camera function by its pointer
            cameraUpdaters[cameraOption](ref camera, ref player, envItems, deltaTime, screenWidth, screenHeight);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.LightGray.ClearBackground();

                camera.BeginMode();
                {
                    for (var i = 0; i < envItems.Length; i++) envItems[i].Rectangle.Draw(envItems[i].Color);

                    var playerRect = new Rectangle(player.Position.X - 20, player.Position.Y - 40, 40, 40);
                    playerRect.Draw(Color.Red);
                }
                camera.EndMode();

                Color.Black.DrawText("Controls:", 20, 20, 10);
                Color.DarkGray.DrawText("- Right/Left to move", 40, 40, 10);
                Color.DarkGray.DrawText("- Space to jump", 40, 60, 10);
                Color.DarkGray.DrawText("- Mouse Wheel to Zoom in-out, R to reset zoom", 40, 80, 10);
                Color.DarkGray.DrawText("- C to change camera mode", 40, 100, 10);
                Color.Black.DrawText("Current camera mode:", 20, 120, 10);
                Color.DarkGray.DrawText(cameraDescriptions[cameraOption], 40, 140, 10);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    private void UpdatePlayer(ref Player player, EnvItem[] envItems, float delta)
    {
        if (IsKeyDown(KeyboardKey.Left)) player.Position.X -= PlayerHorSpeed * delta;
        if (IsKeyDown(KeyboardKey.Right)) player.Position.X += PlayerHorSpeed * delta;
        if (IsKeyDown(KeyboardKey.Space) && player.CanJump)
        {
            player.Speed = -PlayerJumpSpeed;
            player.CanJump = false;
        }

        var hitObstacle = false;
        for (var i = 0; i < envItems.Length; i++)
        {
            var ei = envItems[i];
            ref var p = ref player.Position;
            if (ei.Blocking &&
                ei.Rectangle.X <= p.X &&
                ei.Rectangle.X + ei.Rectangle.Width >= p.X &&
                ei.Rectangle.Y >= p.Y &&
                ei.Rectangle.Y <= p.Y + player.Speed * delta)
            {
                hitObstacle = true;
                player.Speed = 0.0f;
                p.Y = ei.Rectangle.Y;
            }
        }

        if (!hitObstacle)
        {
            player.Position.Y += player.Speed * delta;
            player.Speed += Gravity * delta;
            player.CanJump = false;
        }
        else
        {
            player.CanJump = true;
        }
    }

    private void UpdateCameraCenter(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta, int width,
        int height)
    {
        camera.Offset = new Vector2(width, height) / 2.0f;
        camera.Target = player.Position;
    }

    private void UpdateCameraCenterInsideMap(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta,
        int width, int height)
    {
        camera.Target = player.Position;
        camera.Offset = new Vector2(width, height) / 2.0f;
        float minX = 1000, minY = 1000, maxX = -1000, maxY = -1000;

        for (var i = 0; i < envItems.Length; i++)
        {
            var ei = envItems[i];
            minX = MathF.Min(ei.Rectangle.X, minX);
            maxX = MathF.Max(ei.Rectangle.X + ei.Rectangle.Width, maxX);
            minY = MathF.Min(ei.Rectangle.Y, minY);
            maxY = MathF.Max(ei.Rectangle.Y + ei.Rectangle.Height, maxY);
        }

        var max = camera.GetWorldToScreen(new Vector2(maxX, maxY));
        var min = camera.GetWorldToScreen(new Vector2(minX, minY));

        if (max.X < width) camera.Offset.X = width - (max.X - width / 2.0f);
        if (max.Y < height) camera.Offset.Y = height - (max.Y - height / 2.0f);
        if (min.X > 0) camera.Offset.X = width / 2.0f - min.X;
        if (min.Y > 0) camera.Offset.Y = height / 2.0f - min.Y;
    }

    private void UpdateCameraCenterSmoothFollow(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta,
        int width, int height)
    {
        float minSpeed = 30;
        float minEffectLength = 10;
        var fractionSpeed = 0.8f;

        camera.Offset = new Vector2(width, height) / 2.0f;
        var diff = player.Position - camera.Target;
        var length = diff.Length();

        if (length > minEffectLength)
        {
            var speed = MathF.Max(fractionSpeed * length, minSpeed);
            camera.Target = camera.Target + diff * (speed * delta / length);
        }
    }

    private void UpdateCameraEvenOutOnLanding(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta,
        int width, int height)
    {
        var evenOutSpeed = 700.0f;
        var eveningOut = false;
        var evenOutTarget = 0.0f;

        camera.Offset = new Vector2(width, height) / 2.0f;
        camera.Target.X = player.Position.X;

        if (eveningOut)
        {
            if (evenOutTarget > camera.Target.Y)
            {
                camera.Target.Y += evenOutSpeed * delta;

                if (camera.Target.Y > evenOutTarget)
                {
                    camera.Target.Y = evenOutTarget;
                    eveningOut = false;
                }
            }
            else
            {
                camera.Target.Y -= evenOutSpeed * delta;

                if (camera.Target.Y < evenOutTarget)
                {
                    camera.Target.Y = evenOutTarget;
                    eveningOut = false;
                }
            }
        }
        else
        {
            if (player.CanJump && player.Speed == 0 && player.Position.Y != camera.Target.Y)
            {
                eveningOut = true;
                evenOutTarget = player.Position.Y;
            }
        }
    }

    private void UpdateCameraPlayerBoundsPush(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta,
        int width, int height)
    {
        var bbox = new Vector2(0.2f, 0.2f);

        var bboxWorldMin =
            camera.GetScreenToWorld(new Vector2((1 - bbox.X) * 0.5f * width, (1 - bbox.Y) * 0.5f * height));
        var bboxWorldMax =
            camera.GetScreenToWorld(new Vector2((1 + bbox.X) * 0.5f * width, (1 + bbox.Y) * 0.5f * height));
        camera.Offset = new Vector2((1 - bbox.X) * 0.5f * width, (1 - bbox.Y) * 0.5f * height);

        if (player.Position.X < bboxWorldMin.X) camera.Target.X = player.Position.X;
        if (player.Position.Y < bboxWorldMin.Y) camera.Target.Y = player.Position.Y;
        if (player.Position.X > bboxWorldMax.X) camera.Target.X = bboxWorldMin.X + (player.Position.X - bboxWorldMax.X);
        if (player.Position.Y > bboxWorldMax.Y) camera.Target.Y = bboxWorldMin.Y + (player.Position.Y - bboxWorldMax.Y);
    }

    private struct Player
    {
        public Vector2 Position;
        public float Speed;
        public bool CanJump;

        public Player(Vector2 position, float speed)
        {
            Position = position;
            Speed = speed;
            CanJump = false;
        }
    }

    private struct EnvItem
    {
        public readonly Rectangle Rectangle;
        public readonly bool Blocking;
        public readonly Color Color;

        public EnvItem(Rectangle rectangle, bool blocking, Color color)
        {
            Rectangle = rectangle;
            Color = color;
            Blocking = blocking;
        }
    }

    private delegate void CameraUpdaterDelegate(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta,
        int width, int height);
}