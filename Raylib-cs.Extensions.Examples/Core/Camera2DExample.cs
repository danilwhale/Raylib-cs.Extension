namespace Raylib_cs.Extensions.Game.Core;

public class Camera2DExample : IExample
{
    private const int MaxBuildings = 100;

    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        var player = new Rectangle(400, 280, 40, 40);
        var buildings = new Rectangle[MaxBuildings];
        var buildColors = new Color[MaxBuildings];
        var random = new Random();

        var spacing = 0;

        for (var i = 0; i < MaxBuildings; i++)
        {
            buildings[i].Width = random.Next(50, 200);
            buildings[i].Height = random.Next(100, 800);
            buildings[i].Y = screenHeight - 130.0f - buildings[i].Height;
            buildings[i].X = -6000.0f + spacing;

            spacing += (int)buildings[i].Width;

            buildColors[i] = new Color(random.Next(200, 240), random.Next(200, 240), random.Next(200, 250), 255);
        }

        var camera = new Camera2D(
            new Vector2(screenWidth / 2.0f, screenHeight / 2.0f),
            player.GetPosition() + new Vector2(20, 20),
            0.0f, 1.0f
        );

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Player movement
            if (IsKeyDown(KeyboardKey.Right)) player.X += 2;
            else if (IsKeyDown(KeyboardKey.Left)) player.X -= 2;

            // Camera target follows player
            camera.Target = player.GetPosition() + new Vector2(20, 20);

            // Camera rotation controls
            if (IsKeyDown(KeyboardKey.A)) camera.Rotation--;
            else if (IsKeyDown(KeyboardKey.S)) camera.Rotation++;

            // Limit camera rotation to 80 degrees (-40 to 40)
            if (camera.Rotation > 40) camera.Rotation = 40;
            else if (camera.Rotation < -40) camera.Rotation = -40;

            // Camera zoom controls
            camera.Zoom += GetMouseWheelMove() * 0.05f;

            if (camera.Zoom > 3.0f) camera.Zoom = 3.0f;
            else if (camera.Zoom < 0.1f) camera.Zoom = 0.1f;

            // Camera reset (zoom and rotation)
            if (IsKeyPressed(KeyboardKey.R))
            {
                camera.Zoom = 1.0f;
                camera.Rotation = 0.0f;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            Color.RayWhite.ClearBackground();

            camera.BeginMode();
            {
                Color.DarkGray.DrawRectangle(-6000, 320, 13000, 8000);

                for (var i = 0; i < MaxBuildings; i++) buildings[i].Draw(buildColors[i]);

                player.Draw(Color.Red);

                Color.Green.DrawLine(camera.Target.X, -screenHeight * 10, camera.Target.X, screenHeight * 10);
                Color.Green.DrawLine(-screenWidth * 10, camera.Target.Y, screenWidth * 10, camera.Target.Y);
            }
            camera.EndMode();

            Color.Red.DrawText("SCREEN AREA", 640, 10, 20);

            Color.Red.DrawRectangle(0, 0, screenWidth, 5);
            Color.Red.DrawRectangle(0, 5, 5, screenHeight - 10);
            Color.Red.DrawRectangle(screenWidth - 5, 5, 5, screenHeight - 10);
            Color.Red.DrawRectangle(0, screenHeight - 5, screenWidth, 5);

            Color.SkyBlue.Alpha(0.5f).DrawRectangle(10, 10, 250, 113);
            Color.Blue.DrawRectangleLines(10, 10, 250, 113);

            Color.Black.DrawText("Free 2d camera controls:", 20, 20, 10);
            Color.DarkGray.DrawText("- Right/Left to move Offset", 40, 40, 10);
            Color.DarkGray.DrawText("- Mouse Wheel to Zoom in-out", 40, 60, 10);
            Color.DarkGray.DrawText("- A / S to Rotate", 40, 80, 10);
            Color.DarkGray.DrawText("- R to reset Zoom and Rotation", 40, 100, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}