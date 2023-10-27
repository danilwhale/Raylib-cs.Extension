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
        Camera3D camera = new Camera3D(
            new Vector3(10.0f, 10.0f, 10.0f), // Camera position
            Vector3.Zero, // Camera looking at point
            Vector3.UnitY, // Camera up vector (rotation towards target)
            45.0f, // Camera field-of-view Y
            CameraProjection.CAMERA_PERSPECTIVE // Camera projection type
        );

        Vector3 cubePosition = new Vector3(0.0f, 1.0f, 0.0f);
        Vector3 cubeSize = new Vector3(2.0f, 2.0f, 2.0f);

        Ray ray = new Ray(); // Picking line ray
        RayCollision collision = new RayCollision(); // Ray collision hit info

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsCursorHidden()) camera.Update(CameraMode.CAMERA_FIRST_PERSON);

            // Toggle camera controls
            if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                if (IsCursorHidden()) EnableCursor();
                else DisableCursor();
            }

            if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                if (!collision.hit)
                {
                    ray = camera.GetMouseRay(GetMousePosition());

                    // Check collision between ray and box
                    collision = ray.GetRayCollisionBox(new BoundingBox(cubePosition - cubeSize / 2, cubePosition + cubeSize / 2));
                }
                else collision.hit = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RAYWHITE.ClearBackground();

                camera.BeginMode();
                {
                    if (collision.hit)
                    {
                        Color.RED.DrawCube(cubePosition, cubeSize);
                        Color.MAROON.DrawCubeWires(cubePosition, cubeSize);

                        Color.GREEN.DrawCubeWires(cubePosition, cubeSize + Vector3.One * 0.2f);
                    }
                    else
                    {
                        Color.GRAY.DrawCube(cubePosition, cubeSize);
                        Color.DARKGRAY.DrawCubeWires(cubePosition, cubeSize);
                    }

                    ray.Draw(Color.MAROON);
                    DrawGrid(10, 1.0f);
                }
                camera.EndMode();

                Color.DARKGRAY.DrawText("Try clicking on the box with your mouse!", 240, 10, 20);

                if (collision.hit) Color.GREEN.DrawText("BOX SELECTED", (screenWidth - MeasureText("BOX SELECTED", 30)) / 2f, screenHeight * 0.1f, 30);

                Color.GRAY.DrawText("Right click mouse to toggle camera controls", 10, 430, 10);

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