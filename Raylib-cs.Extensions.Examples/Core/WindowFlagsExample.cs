namespace Raylib_cs.Extensions.Game.Core;

public class WindowFlagsExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //---------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Possible window flags
        /*
        ConfigFlags.FLAG_VSYNC_HINT
        ConfigFlags.FLAG_FULLSCREEN_MODE    -> not working properly -> wrong scaling!
        ConfigFlags.FLAG_WINDOW_RESIZABLE
        ConfigFlags.FLAG_WINDOW_UNDECORATED
        ConfigFlags.FLAG_WINDOW_TRANSPARENT
        ConfigFlags.FLAG_WINDOW_HIDDEN
        ConfigFlags.FLAG_WINDOW_MINIMIZED   -> Not supported on window creation
        ConfigFlags.FLAG_WINDOW_MAXIMIZED   -> Not supported on window creation
        ConfigFlags.FLAG_WINDOW_UNFOCUSED
        ConfigFlags.FLAG_WINDOW_TOPMOST
        ConfigFlags.FLAG_WINDOW_HIGHDPI     -> errors after minimize-resize, fb size is recalculated
        ConfigFlags.FLAG_WINDOW_ALWAYS_RUN
        ConfigFlags.FLAG_MSAA_4X_HINT
        */

        // Set configuration flags for window creation
        //SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT | ConfigFlags.FLAG_MSAA_4X_HINT | ConfigFlags.FLAG_WINDOW_HIGHDPI);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - window flags");

        Vector2 ballPosition = new Vector2(GetScreenWidth(), GetScreenHeight()) / 2f;
        Vector2 ballSpeed = new Vector2(5.0f, 4.0f);
        float ballRadius = 20;

        int framesCounter = 0;

        // SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
        //----------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //-----------------------------------------------------
            if (IsKeyPressed(KeyboardKey.KEY_F)) ToggleFullscreen(); // modifies window size when scaling!

            if (IsKeyPressed(KeyboardKey.KEY_R))
            {
                if (IsWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE)) ClearWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
                else SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            }

            if (IsKeyPressed(KeyboardKey.KEY_D))
            {
                if (IsWindowState(ConfigFlags.FLAG_WINDOW_UNDECORATED)) ClearWindowState(ConfigFlags.FLAG_WINDOW_UNDECORATED);
                else SetWindowState(ConfigFlags.FLAG_WINDOW_UNDECORATED);
            }

            if (IsKeyPressed(KeyboardKey.KEY_H))
            {
                if (!IsWindowState(ConfigFlags.FLAG_WINDOW_HIDDEN)) SetWindowState(ConfigFlags.FLAG_WINDOW_HIDDEN);

                framesCounter = 0;
            }

            if (IsWindowState(ConfigFlags.FLAG_WINDOW_HIDDEN))
            {
                framesCounter++;
                if (framesCounter >= 240) ClearWindowState(ConfigFlags.FLAG_WINDOW_HIDDEN); // Show window after 3 seconds
            }

            if (IsKeyPressed(KeyboardKey.KEY_N))
            {
                if (!IsWindowState(ConfigFlags.FLAG_WINDOW_MINIMIZED)) MinimizeWindow();

                framesCounter = 0;
            }

            if (IsWindowState(ConfigFlags.FLAG_WINDOW_MINIMIZED))
            {
                framesCounter++;
                if (framesCounter >= 240) RestoreWindow(); // Restore window after 3 seconds
            }

            if (IsKeyPressed(KeyboardKey.KEY_M))
            {
                // NOTE: Requires ConfigFlags.FLAG_WINDOW_RESIZABLE enabled!
                if (IsWindowState(ConfigFlags.FLAG_WINDOW_MAXIMIZED)) RestoreWindow();
                else MaximizeWindow();
            }

            if (IsKeyPressed(KeyboardKey.KEY_U))
            {
                if (IsWindowState(ConfigFlags.FLAG_WINDOW_UNFOCUSED)) ClearWindowState(ConfigFlags.FLAG_WINDOW_UNFOCUSED);
                else SetWindowState(ConfigFlags.FLAG_WINDOW_UNFOCUSED);
            }

            if (IsKeyPressed(KeyboardKey.KEY_T))
            {
                if (IsWindowState(ConfigFlags.FLAG_WINDOW_TOPMOST)) ClearWindowState(ConfigFlags.FLAG_WINDOW_TOPMOST);
                else SetWindowState(ConfigFlags.FLAG_WINDOW_TOPMOST);
            }

            if (IsKeyPressed(KeyboardKey.KEY_A))
            {
                if (IsWindowState(ConfigFlags.FLAG_WINDOW_ALWAYS_RUN)) ClearWindowState(ConfigFlags.FLAG_WINDOW_ALWAYS_RUN);
                else SetWindowState(ConfigFlags.FLAG_WINDOW_ALWAYS_RUN);
            }

            if (IsKeyPressed(KeyboardKey.KEY_V))
            {
                if (IsWindowState(ConfigFlags.FLAG_VSYNC_HINT)) ClearWindowState(ConfigFlags.FLAG_VSYNC_HINT);
                else SetWindowState(ConfigFlags.FLAG_VSYNC_HINT);
            }

            // Bouncing ball logic
            ballPosition.X += ballSpeed.X;
            ballPosition.Y += ballSpeed.Y;
            if (ballPosition.X >= GetScreenWidth() - ballRadius || ballPosition.X <= ballRadius) ballSpeed.X *= -1.0f;
            if (ballPosition.Y >= GetScreenHeight() - ballRadius || ballPosition.Y <= ballRadius) ballSpeed.Y *= -1.0f;
            //-----------------------------------------------------

            // Draw
            //-----------------------------------------------------
            BeginDrawing();

            if (IsWindowState(ConfigFlags.FLAG_WINDOW_TRANSPARENT)) Color.BLANK.ClearBackground();
            else Color.RAYWHITE.ClearBackground();

            Color.MAROON.DrawCircle(ballPosition, ballRadius);
            Color.RAYWHITE.DrawRectangleLines(new Rectangle(0, 0, GetScreenWidth(), GetScreenHeight()), 4f);

            Color.DARKBLUE.DrawCircle(GetMousePosition(), 10);

            DrawFPS(10, 10);

            Color.GREEN.DrawText($"Screen Size: [{GetScreenWidth()}, {GetScreenHeight()}]", 10, 40, 10);

            // Draw window state info
            Color.GRAY.DrawText("Following flags can be set after window creation:", 10, 60, 10);
            if (IsWindowState(ConfigFlags.FLAG_FULLSCREEN_MODE)) Color.LIME.DrawText("[F] ConfigFlags.FLAG_FULLSCREEN_MODE: on", 10, 80, 10);
            else Color.MAROON.DrawText("[F] ConfigFlags.FLAG_FULLSCREEN_MODE: off", 10, 80, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE)) Color.LIME.DrawText("[R] ConfigFlags.FLAG_WINDOW_RESIZABLE: on", 10, 100, 10);
            else Color.MAROON.DrawText("[R] ConfigFlags.FLAG_WINDOW_RESIZABLE: off", 10, 100, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_UNDECORATED)) Color.LIME.DrawText("[D] ConfigFlags.FLAG_WINDOW_UNDECORATED: on", 10, 120, 10);
            else Color.MAROON.DrawText("[D] ConfigFlags.FLAG_WINDOW_UNDECORATED: off", 10, 120, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_HIDDEN)) Color.LIME.DrawText("[H] ConfigFlags.FLAG_WINDOW_HIDDEN: on", 10, 140, 10);
            else Color.MAROON.DrawText("[H] ConfigFlags.FLAG_WINDOW_HIDDEN: off", 10, 140, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_MINIMIZED)) Color.LIME.DrawText("[N] ConfigFlags.FLAG_WINDOW_MINIMIZED: on", 10, 160, 10);
            else Color.MAROON.DrawText("[N] ConfigFlags.FLAG_WINDOW_MINIMIZED: off", 10, 160, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_MAXIMIZED)) Color.LIME.DrawText("[M] ConfigFlags.FLAG_WINDOW_MAXIMIZED: on", 10, 180, 10);
            else Color.MAROON.DrawText("[M] ConfigFlags.FLAG_WINDOW_MAXIMIZED: off", 10, 180, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_UNFOCUSED)) Color.LIME.DrawText("[G] ConfigFlags.FLAG_WINDOW_UNFOCUSED: on", 10, 200, 10);
            else Color.MAROON.DrawText("[U] ConfigFlags.FLAG_WINDOW_UNFOCUSED: off", 10, 200, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_TOPMOST)) Color.LIME.DrawText("[T] ConfigFlags.FLAG_WINDOW_TOPMOST: on", 10, 220, 10);
            else Color.MAROON.DrawText("[T] ConfigFlags.FLAG_WINDOW_TOPMOST: off", 10, 220, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_ALWAYS_RUN)) Color.LIME.DrawText("[A] ConfigFlags.FLAG_WINDOW_ALWAYS_RUN: on", 10, 240, 10);
            else Color.MAROON.DrawText("[A] ConfigFlags.FLAG_WINDOW_ALWAYS_RUN: off", 10, 240, 10);
            if (IsWindowState(ConfigFlags.FLAG_VSYNC_HINT)) Color.LIME.DrawText("[V] ConfigFlags.FLAG_VSYNC_HINT: on", 10, 260, 10);
            else Color.MAROON.DrawText("[V] ConfigFlags.FLAG_VSYNC_HINT: off", 10, 260, 10);

            Color.GRAY.DrawText("Following flags can only be set before window creation:", 10, 300, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_HIGHDPI)) Color.LIME.DrawText("ConfigFlags.FLAG_WINDOW_HIGHDPI: on", 10, 320, 10);
            else Color.MAROON.DrawText("ConfigFlags.FLAG_WINDOW_HIGHDPI: off", 10, 320, 10);
            if (IsWindowState(ConfigFlags.FLAG_WINDOW_TRANSPARENT)) Color.LIME.DrawText("ConfigFlags.FLAG_WINDOW_TRANSPARENT: on", 10, 340, 10);
            else Color.MAROON.DrawText("ConfigFlags.FLAG_WINDOW_TRANSPARENT: off", 10, 340, 10);
            if (IsWindowState(ConfigFlags.FLAG_MSAA_4X_HINT)) Color.LIME.DrawText("ConfigFlags.FLAG_MSAA_4X_HINT: on", 10, 360, 10);
            else Color.MAROON.DrawText("ConfigFlags.FLAG_MSAA_4X_HINT: off", 10, 360, 10);

            EndDrawing();
            //-----------------------------------------------------
        }

        // De-Initialization
        //---------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //----------------------------------------------------------
    }
}