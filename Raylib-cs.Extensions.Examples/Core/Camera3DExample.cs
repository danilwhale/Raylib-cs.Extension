namespace Raylib_cs.Extensions.Game.Core;

public class Camera3DExample : IExample
{
    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera mode");

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D(
            new Vector3(10.0f, 10.0f, 10.0f), 
            Vector3.Zero, 
            Vector3.UnitY, 
            45.0f, 
            CameraProjection.CAMERA_PERSPECTIVE
            );

        Vector3 cubePosition = Vector3.Zero;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RAYWHITE.ClearBackground();

                camera.BeginMode();
                {
                    Color.RED.DrawCube(cubePosition, 2.0f, 2.0f, 2.0f);
                    Color.MAROON.DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f);

                    DrawGrid(10, 1.0f);
                }
                camera.EndMode();

                Color.DARKGRAY.DrawText("Welcome to the third dimension!", 10, 40, 20);

                DrawFPS(10, 10);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}