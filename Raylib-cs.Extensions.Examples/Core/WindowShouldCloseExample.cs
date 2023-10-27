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

        SetExitKey(KeyboardKey.KEY_NULL); // Disable KEY_ESCAPE to close window, X-button still works

        bool exitWindowRequested = false; // Flag to request window to exit
        bool exitWindow = false; // Flag to set window to exit

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!exitWindow)
        {
            // Update
            //----------------------------------------------------------------------------------
            // Detect if X-button or KEY_ESCAPE have been pressed to close window
            if (WindowShouldClose() || IsKeyPressed(KeyboardKey.KEY_ESCAPE)) exitWindowRequested = true;

            if (exitWindowRequested)
            {
                // A request for close window has been issued, we can save data before closing
                // or just show a message asking for confirmation

                if (IsKeyPressed(KeyboardKey.KEY_Y)) exitWindow = true;
                else if (IsKeyPressed(KeyboardKey.KEY_N)) exitWindowRequested = false;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RAYWHITE.ClearBackground();

                if (exitWindowRequested)
                {
                    Color.BLACK.DrawRectangle(0, 100, screenWidth, 200);
                    Color.WHITE.DrawText("Are you sure you want to exit program? [Y/N]", 40, 180, 30);
                }
                else Color.LIGHTGRAY.DrawText("Try to close the window to get confirmation message!", 120, 200, 20);
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