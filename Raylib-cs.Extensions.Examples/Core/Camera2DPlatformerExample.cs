namespace Raylib_cs.Extensions.Game.Core;

public class Camera2DPlatformerExample : IExample
{
    private const int Gravity = 400;
    private const float PlayerJumpSpeed = 350.0f;
    private const float PlayerHorSpeed = 200.0f;

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
        public Rectangle Rectangle;
        public bool Blocking;
        public Color Color;

        public EnvItem(Rectangle rectangle, bool blocking, Color color)
        {
            Rectangle = rectangle;
            Color = color;
            Blocking = blocking;
        }
    }

    private delegate void CameraUpdaterDelegate(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta, int width, int height);

    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        Player player = new Player(new Vector2(400, 280), 0);
        EnvItem[] envItems =
        {
            new EnvItem(new Rectangle(0, 0, 1000, 400), false, Color.LIGHTGRAY),
            new EnvItem(new Rectangle(0, 400, 1000, 200), true, Color.GRAY),
            new EnvItem(new Rectangle(300, 200, 400, 10), true, Color.GRAY),
            new EnvItem(new Rectangle(250, 300, 100, 10), true, Color.GRAY),
            new EnvItem(new Rectangle(650, 300, 100, 10), true, Color.GRAY)
        };

        Camera2D camera = new Camera2D(new Vector2(screenWidth, screenHeight) / 2.0f, player.Position, 0.0f, 1.0f);

        // Store pointers to the multiple update camera functions
        CameraUpdaterDelegate[] cameraUpdaters =
        {
            UpdateCameraCenter,
            UpdateCameraCenterInsideMap,
            UpdateCameraCenterSmoothFollow,
            UpdateCameraEvenOutOnLanding,
            UpdateCameraPlayerBoundsPush
        };

        int cameraOption = 0;

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
            float deltaTime = GetFrameTime();

            UpdatePlayer(ref player, envItems, deltaTime);

            camera.zoom += GetMouseWheelMove() * 0.05f;

            if (camera.zoom > 3.0f) camera.zoom = 3.0f;
            else if (camera.zoom < 0.25f) camera.zoom = 0.25f;

            if (IsKeyPressed(KeyboardKey.KEY_R))
            {
                camera.zoom = 1.0f;
                player.Position = new Vector2(400, 280);
            }

            if (IsKeyPressed(KeyboardKey.KEY_C)) cameraOption = (cameraOption + 1) % cameraUpdaters.Length;

            // Call update camera function by its pointer
            cameraUpdaters[cameraOption](ref camera, ref player, envItems, deltaTime, screenWidth, screenHeight);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.LIGHTGRAY.ClearBackground();

                camera.BeginMode();
                {
                    for (int i = 0; i < envItems.Length; i++) envItems[i].Rectangle.Draw(envItems[i].Color);

                    Rectangle playerRect = new Rectangle(player.Position.X - 20, player.Position.Y - 40, 40, 40);
                    playerRect.Draw(Color.RED);
                }
                camera.EndMode();

                Color.BLACK.DrawText("Controls:", 20, 20, 10);
                Color.DARKGRAY.DrawText("- Right/Left to move", 40, 40, 10);
                Color.DARKGRAY.DrawText("- Space to jump", 40, 60, 10);
                Color.DARKGRAY.DrawText("- Mouse Wheel to Zoom in-out, R to reset zoom", 40, 80, 10);
                Color.DARKGRAY.DrawText("- C to change camera mode", 40, 100, 10);
                Color.BLACK.DrawText("Current camera mode:", 20, 120, 10);
                Color.DARKGRAY.DrawText(cameraDescriptions[cameraOption], 40, 140, 10);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    void UpdatePlayer(ref Player player, EnvItem[] envItems, float delta)
    {
        if (IsKeyDown(KeyboardKey.KEY_LEFT)) player.Position.X -= PlayerHorSpeed * delta;
        if (IsKeyDown(KeyboardKey.KEY_RIGHT)) player.Position.X += PlayerHorSpeed * delta;
        if (IsKeyDown(KeyboardKey.KEY_SPACE) && player.CanJump)
        {
            player.Speed = -PlayerJumpSpeed;
            player.CanJump = false;
        }

        bool hitObstacle = false;
        for (int i = 0; i < envItems.Length; i++)
        {
            EnvItem ei = envItems[i];
            ref Vector2 p = ref player.Position;
            if (ei.Blocking &&
                ei.Rectangle.x <= p.X &&
                ei.Rectangle.x + ei.Rectangle.width >= p.X &&
                ei.Rectangle.y >= p.Y &&
                ei.Rectangle.y <= p.Y + player.Speed * delta)
            {
                hitObstacle = true;
                player.Speed = 0.0f;
                p.Y = ei.Rectangle.y;
            }
        }

        if (!hitObstacle)
        {
            player.Position.Y += player.Speed * delta;
            player.Speed += Gravity * delta;
            player.CanJump = false;
        }
        else player.CanJump = true;
    }

    void UpdateCameraCenter(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta, int width, int height)
    {
        camera.offset = new Vector2(width, height) / 2.0f;
        camera.target = player.Position;
    }

    void UpdateCameraCenterInsideMap(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta, int width, int height)
    {
        camera.target = player.Position;
        camera.offset = new Vector2(width, height) / 2.0f;
        float minX = 1000, minY = 1000, maxX = -1000, maxY = -1000;

        for (int i = 0; i < envItems.Length; i++)
        {
            EnvItem ei = envItems[i];
            minX = MathF.Min(ei.Rectangle.x, minX);
            maxX = MathF.Max(ei.Rectangle.x + ei.Rectangle.width, maxX);
            minY = MathF.Min(ei.Rectangle.y, minY);
            maxY = MathF.Max(ei.Rectangle.y + ei.Rectangle.height, maxY);
        }

        Vector2 max = camera.GetWorldToScreen(new Vector2(maxX, maxY));
        Vector2 min = camera.GetWorldToScreen(new Vector2(minX, minY));

        if (max.X < width) camera.offset.X = width - (max.X - width / 2.0f);
        if (max.Y < height) camera.offset.Y = height - (max.Y - height / 2.0f);
        if (min.X > 0) camera.offset.X = width / 2.0f - min.X;
        if (min.Y > 0) camera.offset.Y = height / 2.0f - min.Y;
    }

    void UpdateCameraCenterSmoothFollow(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta, int width, int height)
    {
        float minSpeed = 30;
        float minEffectLength = 10;
        float fractionSpeed = 0.8f;

        camera.offset = new Vector2(width, height) / 2.0f;
        Vector2 diff = player.Position - camera.target;
        float length = diff.Length();

        if (length > minEffectLength)
        {
            float speed = MathF.Max(fractionSpeed * length, minSpeed);
            camera.target = camera.target + diff * (speed * delta / length);
        }
    }

    void UpdateCameraEvenOutOnLanding(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta, int width, int height)
    {
        float evenOutSpeed = 700.0f;
        bool eveningOut = false;
        float evenOutTarget = 0.0f;

        camera.offset = new Vector2(width, height) / 2.0f;
        camera.target.X = player.Position.X;

        if (eveningOut)
        {
            if (evenOutTarget > camera.target.Y)
            {
                camera.target.Y += evenOutSpeed * delta;

                if (camera.target.Y > evenOutTarget)
                {
                    camera.target.Y = evenOutTarget;
                    eveningOut = false;
                }
            }
            else
            {
                camera.target.Y -= evenOutSpeed * delta;

                if (camera.target.Y < evenOutTarget)
                {
                    camera.target.Y = evenOutTarget;
                    eveningOut = false;
                }
            }
        }
        else
        {
            if ((player.CanJump && player.Speed == 0) && (player.Position.Y != camera.target.Y))
            {
                eveningOut = true;
                evenOutTarget = player.Position.Y;
            }
        }
    }

    void UpdateCameraPlayerBoundsPush(ref Camera2D camera, ref Player player, EnvItem[] envItems, float delta, int width, int height)
    {
        Vector2 bbox = new Vector2(0.2f, 0.2f);

        Vector2 bboxWorldMin = camera.GetScreenToWorld(new Vector2((1 - bbox.X) * 0.5f * width, (1 - bbox.Y) * 0.5f * height));
        Vector2 bboxWorldMax = camera.GetScreenToWorld(new Vector2((1 + bbox.X) * 0.5f * width, (1 + bbox.Y) * 0.5f * height));
        camera.offset = new Vector2((1 - bbox.X) * 0.5f * width, (1 - bbox.Y) * 0.5f * height);

        if (player.Position.X < bboxWorldMin.X) camera.target.X = player.Position.X;
        if (player.Position.Y < bboxWorldMin.Y) camera.target.Y = player.Position.Y;
        if (player.Position.X > bboxWorldMax.X) camera.target.X = bboxWorldMin.X + (player.Position.X - bboxWorldMax.X);
        if (player.Position.Y > bboxWorldMax.Y) camera.target.Y = bboxWorldMin.Y + (player.Position.Y - bboxWorldMax.Y);
    }
}