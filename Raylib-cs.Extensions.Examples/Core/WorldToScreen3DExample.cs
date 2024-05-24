namespace Raylib_cs.Extensions.Game.Core;

public class WorldToScreen3DExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - core world screen");

        // Define the camera to look into our 3d world
        var camera = new Camera3D(
            new Vector3(10.0f, 10.0f, 10.0f), // Camera position
            Vector3.Zero, // Camera looking at point
            Vector3.UnitY, // Camera up vector (rotation towards target)
            45.0f, // Camera field-of-view Y
            CameraProjection.Perspective // Camera projection type
        );

        var cubePosition = new Vector3(0.0f, 0.0f, 0.0f);
        var cubeScreenPosition = new Vector2(0.0f, 0.0f);

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            camera.Update(CameraMode.ThirdPerson);

            // Calculate cube screen space position (with a little offset to be in top)
            cubeScreenPosition = camera.GetWorldToScreen(cubePosition + Vector3.UnitY * 2.5f);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                camera.BeginMode();
                {
                    Color.Red.DrawCube(cubePosition, 2.0f, 2.0f, 2.0f);
                    Color.Maroon.DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f);

                    DrawGrid(10, 1.0f);
                }
                camera.EndMode();

                Color.Black.DrawText("Enemy: 100 / 100", cubeScreenPosition.X - MeasureText("Enemy: 100/100", 20) / 2f,
                    cubeScreenPosition.Y, 20);

                Color.Lime.DrawText(
                    $"Cube position in screen space coordinates: [{(int)cubeScreenPosition.X}, {(int)cubeScreenPosition.Y}]",
                    10, 10, 20);
                Color.Gray.DrawText("Text 2d should be always on top of the cube", 10, 40, 20);
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