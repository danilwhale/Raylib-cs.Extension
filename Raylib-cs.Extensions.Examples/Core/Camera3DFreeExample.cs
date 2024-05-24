namespace Raylib_cs.Extensions.Game.Core;

public class Camera3DFreeExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera free");

        // Define the camera to look into our 3d world
        var camera = new Camera3D(
            new Vector3(0.0f, 10.0f, 10.0f),
            Vector3.Zero,
            Vector3.UnitY,
            45.0f,
            CameraProjection.Perspective);

        var cubePosition = Vector3.Zero;

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            camera.Update(CameraMode.Free);

            if (IsKeyDown(KeyboardKey.Z)) camera.Target = Vector3.Zero;
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

                Color.SkyBlue.Alpha(0.5f).DrawRectangle(10, 10, 320, 133);
                Color.Blue.DrawRectangleLines(10, 10, 320, 133);

                Color.Black.DrawText("Free camera default controls:", 20, 20, 10);
                Color.DarkGray.DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 10);
                Color.DarkGray.DrawText("- Mouse Wheel Pressed to Pan", 40, 60, 10);
                Color.DarkGray.DrawText("- Alt + Mouse Wheel Pressed to Rotate", 40, 80, 10);
                Color.DarkGray.DrawText("- Z to zoom to (0, 0, 0)", 40, 120, 10);
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