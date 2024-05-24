namespace Raylib_cs.Extensions.Game.Core;

public class Picking3DExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d picking");

        // Define the camera to look into our 3d world
        var camera = new Camera3D(
            new Vector3(10.0f, 10.0f, 10.0f), // Camera position
            Vector3.Zero, // Camera looking at point
            Vector3.UnitY, // Camera up vector (rotation towards target)
            45.0f, // Camera field-of-view Y
            CameraProjection.Perspective // Camera projection type
        );

        var cubePosition = new Vector3(0.0f, 1.0f, 0.0f);
        var cubeSize = new Vector3(2.0f, 2.0f, 2.0f);

        var ray = new Ray(); // Picking line ray
        var collision = new RayCollision(); // Ray collision hit info

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsCursorHidden()) camera.Update(CameraMode.FirstPerson);

            // Toggle camera controls
            if (IsMouseButtonPressed(MouseButton.Right))
            {
                if (IsCursorHidden()) EnableCursor();
                else DisableCursor();
            }

            if (IsMouseButtonPressed(MouseButton.Left))
            {
                if (!collision.Hit)
                {
                    ray = camera.GetMouseRay(GetMousePosition());

                    // Check collision between ray and box
                    collision = ray.GetRayCollisionBox(new BoundingBox(cubePosition - cubeSize / 2,
                        cubePosition + cubeSize / 2));
                }
                else
                {
                    collision.Hit = false;
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                camera.BeginMode();
                {
                    if (collision.Hit)
                    {
                        Color.Red.DrawCube(cubePosition, cubeSize);
                        Color.Maroon.DrawCubeWires(cubePosition, cubeSize);

                        Color.Green.DrawCubeWires(cubePosition, cubeSize + Vector3.One * 0.2f);
                    }
                    else
                    {
                        Color.Gray.DrawCube(cubePosition, cubeSize);
                        Color.DarkGray.DrawCubeWires(cubePosition, cubeSize);
                    }

                    ray.Draw(Color.Maroon);
                    DrawGrid(10, 1.0f);
                }
                camera.EndMode();

                Color.DarkGray.DrawText("Try clicking on the box with your mouse!", 240, 10, 20);

                if (collision.Hit)
                    Color.Green.DrawText("BOX SELECTED", (screenWidth - MeasureText("BOX SELECTED", 30)) / 2f,
                        screenHeight * 0.1f, 30);

                Color.Gray.DrawText("Right click mouse to toggle camera controls", 10, 430, 10);

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