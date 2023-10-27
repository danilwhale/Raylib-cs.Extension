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

        Camera2D camera = new Camera2D(Vector2.Zero, Vector2.Zero, 0.0f, 1.0f);

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Translate based on mouse right click
            if (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                Vector2 delta = GetMouseDelta();
                delta = delta * (-1.0f / camera.zoom);

                camera.target = camera.target + delta;
            }

            // Zoom based on mouse wheel
            float wheel = GetMouseWheelMove();
            if (wheel != 0)
            {
                // Get the world point that is under the mouse
                Vector2 mouseWorldPos = camera.GetScreenToWorld(GetMousePosition());

                // Set the offset to where the mouse is
                camera.offset = GetMousePosition();

                // Set the target to match, so that the camera maps the world space point 
                // under the cursor to the screen space point under the cursor at any zoom
                camera.target = mouseWorldPos;

                // Zoom increment
                const float zoomIncrement = 0.125f;

                camera.zoom += wheel * zoomIncrement;
                if (camera.zoom < zoomIncrement) camera.zoom = zoomIncrement;
            }

            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            Color.BLACK.ClearBackground();

            camera.BeginMode();
            {
                // Draw the 3d grid, rotated 90 degrees and centered around 0,0 
                // just so we have something in the XY plane
                Rlgl.rlPushMatrix();
                {
                    Rlgl.rlTranslatef(0, 25 * 50, 0);
                    Rlgl.rlRotatef(90, 1, 0, 0);
                    DrawGrid(100, 50);
                }
                Rlgl.rlPopMatrix();

                // Draw a reference circle
                Color.YELLOW.DrawCircle(100, 100, 50);
            }
            camera.EndMode();

            Color.WHITE.DrawText("Mouse right button drag to move, mouse wheel to zoom", 10, 10, 20);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}