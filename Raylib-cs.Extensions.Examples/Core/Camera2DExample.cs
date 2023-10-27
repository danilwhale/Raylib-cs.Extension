namespace Raylib_cs.Extensions.Game.Core;

public class Camera2DExample : IExample
{
    private const int MaxBuildings = 100;

    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        Rectangle player = new Rectangle(400, 280, 40, 40);
        Rectangle[] buildings = new Rectangle[MaxBuildings];
        Color[] buildColors = new Color[MaxBuildings];
        Random random = new Random();

        int spacing = 0;
        
        for (int i = 0; i < MaxBuildings; i++)
        {
            buildings[i].width = random.Next(50, 200);
            buildings[i].height = random.Next(100, 800);
            buildings[i].y = screenHeight - 130.0f - buildings[i].height;
            buildings[i].x = -6000.0f + spacing;

            spacing += (int)buildings[i].width;

            buildColors[i] = new Color(random.Next(200, 240), random.Next(200, 240), random.Next(200, 250), 255);
        }

        Camera2D camera = new Camera2D(
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
            if (IsKeyDown(KeyboardKey.KEY_RIGHT)) player.x += 2;
            else if (IsKeyDown(KeyboardKey.KEY_LEFT)) player.x -= 2;

            // Camera target follows player
            camera.target = player.GetPosition() + new Vector2(20, 20);

            // Camera rotation controls
            if (IsKeyDown(KeyboardKey.KEY_A)) camera.rotation--;
            else if (IsKeyDown(KeyboardKey.KEY_S)) camera.rotation++;

            // Limit camera rotation to 80 degrees (-40 to 40)
            if (camera.rotation > 40) camera.rotation = 40;
            else if (camera.rotation < -40) camera.rotation = -40;

            // Camera zoom controls
            camera.zoom += GetMouseWheelMove() * 0.05f;

            if (camera.zoom > 3.0f) camera.zoom = 3.0f;
            else if (camera.zoom < 0.1f) camera.zoom = 0.1f;

            // Camera reset (zoom and rotation)
            if (IsKeyPressed(KeyboardKey.KEY_R))
            {
                camera.zoom = 1.0f;
                camera.rotation = 0.0f;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            camera.BeginMode();
            {
                Color.DARKGRAY.DrawRectangle(-6000, 320, 13000, 8000);

                for (int i = 0; i < MaxBuildings; i++) buildings[i].Draw(buildColors[i]);

                player.Draw(Color.RED);

                Color.GREEN.DrawLine(camera.target.X, -screenHeight * 10, camera.target.X, screenHeight * 10);
                Color.GREEN.DrawLine(-screenWidth * 10, camera.target.Y, screenWidth * 10, camera.target.Y);
            }
            camera.EndMode();

            Color.RED.DrawText("SCREEN AREA", 640, 10, 20);

            Color.RED.DrawRectangle(0, 0, screenWidth, 5);
            Color.RED.DrawRectangle(0, 5, 5, screenHeight - 10);
            Color.RED.DrawRectangle(screenWidth - 5, 5, 5, screenHeight - 10);
            Color.RED.DrawRectangle(0, screenHeight - 5, screenWidth, 5);

            Color.SKYBLUE.Alpha(0.5f).DrawRectangle(10, 10, 250, 113);
            Color.BLUE.DrawRectangleLines(10, 10, 250, 113);

            Color.BLACK.DrawText("Free 2d camera controls:", 20, 20, 10);
            Color.DARKGRAY.DrawText("- Right/Left to move Offset", 40, 40, 10);
            Color.DARKGRAY.DrawText("- Mouse Wheel to Zoom in-out", 40, 60, 10);
            Color.DARKGRAY.DrawText("- A / S to Rotate", 40, 80, 10);
            Color.DARKGRAY.DrawText("- R to reset Zoom and Rotation", 40, 100, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}