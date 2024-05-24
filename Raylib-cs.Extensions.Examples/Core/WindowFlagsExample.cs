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
        ConfigFlags.VSyncHint
        ConfigFlags.FullscreenMode    -> not working properly -> wrong scaling!
        ConfigFlags.ResizableWindow
        ConfigFlags.UndecoratedWindow
        ConfigFlags.TransparentWindow
        ConfigFlags.HiddenWindow
        ConfigFlags.MinimizedWindow   -> Not supported on window creation
        ConfigFlags.MaximizedWindow   -> Not supported on window creation
        ConfigFlags.UnfocusedWindow
        ConfigFlags.TopmostWindow
        ConfigFlags.HighDpiWindow     -> errors after minimize-resize, fb size is recalculated
        ConfigFlags.AlwaysRunWindow
        ConfigFlags.Msaa4xHint
        */

        // Set configuration flags for window creation
        //SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint | ConfigFlags.HighDpiWindow);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - window flags");

        var ballPosition = new Vector2(GetScreenWidth(), GetScreenHeight()) / 2f;
        var ballSpeed = new Vector2(5.0f, 4.0f);
        float ballRadius = 20;

        var framesCounter = 0;

        // SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
        //----------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //-----------------------------------------------------
            if (IsKeyPressed(KeyboardKey.F)) ToggleFullscreen(); // modifies window size when scaling!

            if (IsKeyPressed(KeyboardKey.R))
            {
                if (IsWindowState(ConfigFlags.ResizableWindow)) ClearWindowState(ConfigFlags.ResizableWindow);
                else SetWindowState(ConfigFlags.ResizableWindow);
            }

            if (IsKeyPressed(KeyboardKey.D))
            {
                if (IsWindowState(ConfigFlags.UndecoratedWindow)) ClearWindowState(ConfigFlags.UndecoratedWindow);
                else SetWindowState(ConfigFlags.UndecoratedWindow);
            }

            if (IsKeyPressed(KeyboardKey.H))
            {
                if (!IsWindowState(ConfigFlags.HiddenWindow)) SetWindowState(ConfigFlags.HiddenWindow);

                framesCounter = 0;
            }

            if (IsWindowState(ConfigFlags.HiddenWindow))
            {
                framesCounter++;
                if (framesCounter >= 240) ClearWindowState(ConfigFlags.HiddenWindow); // Show window after 3 seconds
            }

            if (IsKeyPressed(KeyboardKey.N))
            {
                if (!IsWindowState(ConfigFlags.MinimizedWindow)) MinimizeWindow();

                framesCounter = 0;
            }

            if (IsWindowState(ConfigFlags.MinimizedWindow))
            {
                framesCounter++;
                if (framesCounter >= 240) RestoreWindow(); // Restore window after 3 seconds
            }

            if (IsKeyPressed(KeyboardKey.M))
            {
                // NOTE: Requires ConfigFlags.ResizableWindow enabled!
                if (IsWindowState(ConfigFlags.MaximizedWindow)) RestoreWindow();
                else MaximizeWindow();
            }

            if (IsKeyPressed(KeyboardKey.U))
            {
                if (IsWindowState(ConfigFlags.UnfocusedWindow)) ClearWindowState(ConfigFlags.UnfocusedWindow);
                else SetWindowState(ConfigFlags.UnfocusedWindow);
            }

            if (IsKeyPressed(KeyboardKey.T))
            {
                if (IsWindowState(ConfigFlags.TopmostWindow)) ClearWindowState(ConfigFlags.TopmostWindow);
                else SetWindowState(ConfigFlags.TopmostWindow);
            }

            if (IsKeyPressed(KeyboardKey.A))
            {
                if (IsWindowState(ConfigFlags.AlwaysRunWindow)) ClearWindowState(ConfigFlags.AlwaysRunWindow);
                else SetWindowState(ConfigFlags.AlwaysRunWindow);
            }

            if (IsKeyPressed(KeyboardKey.V))
            {
                if (IsWindowState(ConfigFlags.VSyncHint)) ClearWindowState(ConfigFlags.VSyncHint);
                else SetWindowState(ConfigFlags.VSyncHint);
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

            if (IsWindowState(ConfigFlags.TransparentWindow)) Color.Blank.ClearBackground();
            else Color.RayWhite.ClearBackground();

            Color.Maroon.DrawCircle(ballPosition, ballRadius);
            Color.RayWhite.DrawRectangleLines(new Rectangle(0, 0, GetScreenWidth(), GetScreenHeight()), 4f);

            Color.DarkBlue.DrawCircle(GetMousePosition(), 10);

            DrawFPS(10, 10);

            Color.Green.DrawText($"Screen Size: [{GetScreenWidth()}, {GetScreenHeight()}]", 10, 40, 10);

            // Draw window state info
            Color.Gray.DrawText("Following flags can be set after window creation:", 10, 60, 10);
            if (IsWindowState(ConfigFlags.FullscreenMode))
                Color.Lime.DrawText("[F] ConfigFlags.FullscreenMode: on", 10, 80, 10);
            else Color.Maroon.DrawText("[F] ConfigFlags.FullscreenMode: off", 10, 80, 10);
            if (IsWindowState(ConfigFlags.ResizableWindow))
                Color.Lime.DrawText("[R] ConfigFlags.ResizableWindow: on", 10, 100, 10);
            else Color.Maroon.DrawText("[R] ConfigFlags.ResizableWindow: off", 10, 100, 10);
            if (IsWindowState(ConfigFlags.UndecoratedWindow))
                Color.Lime.DrawText("[D] ConfigFlags.UndecoratedWindow: on", 10, 120, 10);
            else Color.Maroon.DrawText("[D] ConfigFlags.UndecoratedWindow: off", 10, 120, 10);
            if (IsWindowState(ConfigFlags.HiddenWindow))
                Color.Lime.DrawText("[H] ConfigFlags.HiddenWindow: on", 10, 140, 10);
            else Color.Maroon.DrawText("[H] ConfigFlags.HiddenWindow: off", 10, 140, 10);
            if (IsWindowState(ConfigFlags.MinimizedWindow))
                Color.Lime.DrawText("[N] ConfigFlags.MinimizedWindow: on", 10, 160, 10);
            else Color.Maroon.DrawText("[N] ConfigFlags.MinimizedWindow: off", 10, 160, 10);
            if (IsWindowState(ConfigFlags.MaximizedWindow))
                Color.Lime.DrawText("[M] ConfigFlags.MaximizedWindow: on", 10, 180, 10);
            else Color.Maroon.DrawText("[M] ConfigFlags.MaximizedWindow: off", 10, 180, 10);
            if (IsWindowState(ConfigFlags.UnfocusedWindow))
                Color.Lime.DrawText("[G] ConfigFlags.UnfocusedWindow: on", 10, 200, 10);
            else Color.Maroon.DrawText("[U] ConfigFlags.UnfocusedWindow: off", 10, 200, 10);
            if (IsWindowState(ConfigFlags.TopmostWindow))
                Color.Lime.DrawText("[T] ConfigFlags.TopmostWindow: on", 10, 220, 10);
            else Color.Maroon.DrawText("[T] ConfigFlags.TopmostWindow: off", 10, 220, 10);
            if (IsWindowState(ConfigFlags.AlwaysRunWindow))
                Color.Lime.DrawText("[A] ConfigFlags.AlwaysRunWindow: on", 10, 240, 10);
            else Color.Maroon.DrawText("[A] ConfigFlags.AlwaysRunWindow: off", 10, 240, 10);
            if (IsWindowState(ConfigFlags.VSyncHint)) Color.Lime.DrawText("[V] ConfigFlags.VSyncHint: on", 10, 260, 10);
            else Color.Maroon.DrawText("[V] ConfigFlags.VSyncHint: off", 10, 260, 10);

            Color.Gray.DrawText("Following flags can only be set before window creation:", 10, 300, 10);
            if (IsWindowState(ConfigFlags.HighDpiWindow))
                Color.Lime.DrawText("ConfigFlags.HighDpiWindow: on", 10, 320, 10);
            else Color.Maroon.DrawText("ConfigFlags.HighDpiWindow: off", 10, 320, 10);
            if (IsWindowState(ConfigFlags.TransparentWindow))
                Color.Lime.DrawText("ConfigFlags.TransparentWindow: on", 10, 340, 10);
            else Color.Maroon.DrawText("ConfigFlags.TransparentWindow: off", 10, 340, 10);
            if (IsWindowState(ConfigFlags.Msaa4xHint)) Color.Lime.DrawText("ConfigFlags.Msaa4xHint: on", 10, 360, 10);
            else Color.Maroon.DrawText("ConfigFlags.Msaa4xHint: off", 10, 360, 10);

            EndDrawing();
            //-----------------------------------------------------
        }

        // De-Initialization
        //---------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //----------------------------------------------------------
    }
}