namespace Raylib_cs.Extensions.Game.Core;

public class SplitScreenExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera split screen");

        // Setup player 1 camera and screen
        var cameraPlayer1 = new Camera3D(
            new Vector3(-0.0f, 1.0f, -3.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            Vector3.UnitY,
            45.0f,
            CameraProjection.Perspective
        );

        var screenPlayer1 = LoadRenderTexture(screenWidth / 2, screenHeight);

        // Setup player two camera and screen
        var cameraPlayer2 = new Camera3D(
            new Vector3(-3.0f, 3.0f, 0.0f),
            new Vector3(0.0f, 3.0f, 0.0f),
            Vector3.UnitY,
            45.0f,
            CameraProjection.Perspective
        );

        var screenPlayer2 = LoadRenderTexture(screenWidth / 2, screenHeight);

        // Build a flipped rectangle the size of the split view to use for drawing later
        var splitScreenRect = new Rectangle(0.0f, 0.0f, screenPlayer1.Texture.Width, -screenPlayer1.Texture.Height);

        // Grid data
        var count = 5;
        float spacing = 4;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // If anyone moves this frame, how far will they move based on the time since the last frame
            // this moves thigns at 10 world units per second, regardless of the actual FPS
            var offsetThisFrame = 10.0f * GetFrameTime();

            // Move Player1 forward and backwards (no turning)
            if (IsKeyDown(KeyboardKey.W))
            {
                cameraPlayer1.Position.Z += offsetThisFrame;
                cameraPlayer1.Target.Z += offsetThisFrame;
            }
            else if (IsKeyDown(KeyboardKey.S))
            {
                cameraPlayer1.Position.Z -= offsetThisFrame;
                cameraPlayer1.Target.Z -= offsetThisFrame;
            }

            // Move Player2 forward and backwards (no turning)
            if (IsKeyDown(KeyboardKey.Up))
            {
                cameraPlayer2.Position.X += offsetThisFrame;
                cameraPlayer2.Target.X += offsetThisFrame;
            }
            else if (IsKeyDown(KeyboardKey.Down))
            {
                cameraPlayer2.Position.X -= offsetThisFrame;
                cameraPlayer2.Target.X -= offsetThisFrame;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            // Draw Player1 view to the render texture
            screenPlayer1.BeginMode();
            {
                Color.SkyBlue.ClearBackground();

                cameraPlayer1.BeginMode();
                {
                    // Draw scene: grid of cube trees on a plane to make a "world"
                    Color.Beige.DrawPlane(Vector3.Zero, new Vector2(50.0f, 50.0f)); // Simple world plane

                    for (var x = -count * spacing; x <= count * spacing; x += spacing)
                    for (var z = -count * spacing; z <= count * spacing; z += spacing)
                    {
                        Color.Lime.DrawCube(new Vector3(x, 1.5f, z), 1, 1, 1);
                        Color.Brown.DrawCube(new Vector3(x, 0.5f, z), 0.25f, 1, 0.25f);
                    }

                    // Draw a cube at each player's position
                    Color.Red.DrawCube(cameraPlayer1.Position, 1, 1, 1);
                    Color.Blue.DrawCube(cameraPlayer2.Position, 1, 1, 1);
                }
                cameraPlayer1.EndMode();

                Color.RayWhite.Alpha(0.8f).DrawRectangle(0, 0, GetScreenWidth() / 2, 40);
                Color.Maroon.DrawText("PLAYER1: W/S to move", 10, 10, 20);
            }
            screenPlayer1.BeginMode();

            // Draw Player2 view to the render texture
            screenPlayer2.BeginMode();
            {
                Color.SkyBlue.ClearBackground();

                cameraPlayer2.BeginMode();
                {
                    // Draw scene: grid of cube trees on a plane to make a "world"
                    Color.Beige.DrawPlane(Vector3.Zero, new Vector2(50.0f, 50.0f)); // Simple world plane

                    for (var x = -count * spacing; x <= count * spacing; x += spacing)
                    for (var z = -count * spacing; z <= count * spacing; z += spacing)
                    {
                        Color.Lime.DrawCube(new Vector3(x, 1.5f, z), 1, 1, 1);
                        Color.Brown.DrawCube(new Vector3(x, 0.5f, z), 0.25f, 1, 0.25f);
                    }

                    // Draw a cube at each player's position
                    Color.Red.DrawCube(cameraPlayer1.Position, 1, 1, 1);
                    Color.Blue.DrawCube(cameraPlayer2.Position, 1, 1, 1);
                }
                cameraPlayer2.EndMode();

                Color.RayWhite.Alpha(0.8f).DrawRectangle(0, 0, GetScreenWidth() / 2, 40);
                Color.DarkBlue.DrawText("PLAYER2: UP/DOWN to move", 10, 10, 20);
            }
            screenPlayer2.EndMode();

            // Draw both views render textures to the screen side by side
            BeginDrawing();
            {
                Color.Black.ClearBackground();

                screenPlayer1.Texture.Draw(splitScreenRect, new Vector2(0.0f, 0.0f), Color.White);
                screenPlayer2.Texture.Draw(splitScreenRect, new Vector2(screenWidth / 2, 0.0f), Color.White);

                Color.LightGray.DrawRectangle(GetScreenWidth() / 2 - 2, 0, 4, GetScreenHeight());
            }
            EndDrawing();
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        screenPlayer1.Unload(); // Unload render texture
        screenPlayer2.Unload(); // Unload render texture

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}