namespace Raylib_cs.Extensions.Game.Core;

public class Camera2DMouseZoom : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera mouse zoom");

        var camera = new Camera2D(Vector2.Zero, Vector2.Zero, 0.0f, 1.0f);

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Translate based on mouse right click
            if (IsMouseButtonDown(MouseButton.Right))
            {
                var delta = GetMouseDelta();
                delta = delta * (-1.0f / camera.Zoom);

                camera.Target = camera.Target + delta;
            }

            // Zoom based on mouse wheel
            var wheel = GetMouseWheelMove();
            if (wheel != 0)
            {
                // Get the world point that is under the mouse
                var mouseWorldPos = camera.GetScreenToWorld(GetMousePosition());

                // Set the offset to where the mouse is
                camera.Offset = GetMousePosition();

                // Set the target to match, so that the camera maps the world space point 
                // under the cursor to the screen space point under the cursor at any zoom
                camera.Target = mouseWorldPos;

                // Zoom increment
                const float zoomIncrement = 0.125f;

                camera.Zoom += wheel * zoomIncrement;
                if (camera.Zoom < zoomIncrement) camera.Zoom = zoomIncrement;
            }

            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            Color.Black.ClearBackground();

            camera.BeginMode();
            {
                // Draw the 3d grid, rotated 90 degrees and centered around 0,0 
                // just so we have something in the XY plane
                Rlgl.PushMatrix();
                {
                    Rlgl.Translatef(0, 25 * 50, 0);
                    Rlgl.Rotatef(90, 1, 0, 0);
                    DrawGrid(100, 50);
                }
                Rlgl.PopMatrix();

                // Draw a reference circle
                Color.Yellow.DrawCircle(100, 100, 50);
            }
            camera.EndMode();

            Color.White.DrawText("Mouse right button drag to move, mouse wheel to zoom", 10, 10, 20);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}