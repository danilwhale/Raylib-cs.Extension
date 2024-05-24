namespace Raylib_cs.Extensions.Game.Core;

public class WindowShouldCloseExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - window should close");

        SetExitKey(KeyboardKey.Null); // Disable Escape to close window, X-button still works

        var exitWindowRequested = false; // Flag to request window to exit
        var exitWindow = false; // Flag to set window to exit

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!exitWindow)
        {
            // Update
            //----------------------------------------------------------------------------------
            // Detect if X-button or Escape have been pressed to close window
            if (WindowShouldClose() || IsKeyPressed(KeyboardKey.Escape)) exitWindowRequested = true;

            if (exitWindowRequested)
            {
                // A request for close window has been issued, we can save data before closing
                // or just show a message asking for confirmation

                if (IsKeyPressed(KeyboardKey.Y)) exitWindow = true;
                else if (IsKeyPressed(KeyboardKey.N)) exitWindowRequested = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                if (exitWindowRequested)
                {
                    Color.Black.DrawRectangle(0, 100, screenWidth, 200);
                    Color.White.DrawText("Are you sure you want to exit program? [Y/N]", 40, 180, 30);
                }
                else
                {
                    Color.LightGray.DrawText("Try to close the window to get confirmation message!", 120, 200, 20);
                }
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