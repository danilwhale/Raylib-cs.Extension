namespace Raylib_cs.Extensions.Game.Core;

public class CustomFrameControlExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - custom frame control");

        // Custom timming variables
        var previousTime = GetTime(); // Previous time measure
        var currentTime = 0.0; // Current time measure
        var updateDrawTime = 0.0; // Update + Draw time
        var waitTime = 0.0; // Wait time (if target fps required)
        var deltaTime = 0.0f; // Frame time (Update + Draw + Wait time)

        var timeCounter = 0.0f; // Accumulative time counter (seconds)
        var position = 0.0f; // Circle position
        var pause = false; // Pause control flag

        var targetFPS = 60; // Our initial target fps
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------

            // raylib-cs' dll is built without SUPPORT_CUSTOM_FRAME_CONTROL
            // if you want to, you can rebuild raylib dll with this flag
            // and uncomment method lower
            // PollInputEvents(); // Poll input events (SUPPORT_CUSTOM_FRAME_CONTROL)

            if (IsKeyPressed(KeyboardKey.Space)) pause = !pause;

            if (IsKeyPressed(KeyboardKey.Up)) targetFPS += 20;
            else if (IsKeyPressed(KeyboardKey.Down)) targetFPS -= 20;

            if (targetFPS < 0) targetFPS = 0;

            if (!pause)
            {
                position += 200 * deltaTime; // We move at 200 pixels per second
                if (position >= GetScreenWidth()) position = 0;
                timeCounter += deltaTime; // We count time (seconds)
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                for (var i = 0; i < GetScreenWidth() / 200; i++)
                    Color.SkyBlue.DrawRectangle(200 * i, 0, 1, GetScreenHeight());

                Color.Red.DrawCircle(position, GetScreenHeight() / 2f - 25, 50);

                Color.Maroon.DrawText($"{timeCounter:0000.0} ms", position - 40, GetScreenHeight() / 2f - 100, 20);
                Color.Black.DrawText($"PosX: {position:0000.0}", position - 50, GetScreenHeight() / 2 + 40, 20);

                Color.DarkGray.DrawText(
                    "Circle is moving at a constant 200 pixels/sec,\nindependently of the frame rate.", 10, 10, 20);
                Color.Gray.DrawText("PRESS SPACE to PAUSE MOVEMENT", 10, GetScreenHeight() - 60, 20);
                Color.Gray.DrawText("PRESS UP | DOWN to CHANGE TARGET FPS", 10, GetScreenHeight() - 30, 20);
                Color.Lime.DrawText($"TARGET FPS: {targetFPS}", GetScreenWidth() - 220, 10, 20);
                Color.Green.DrawText($"CURRENT FPS: {(int)(1.0f / deltaTime)}", GetScreenWidth() - 220, 40, 20);
            }
            EndDrawing();

            // NOTE: In case raylib is configured to SUPPORT_CUSTOM_FRAME_CONTROL, 
            // Events polling, screen buffer swap and frame time control must be managed by the user

            // raylib-cs' dll is built without SUPPORT_CUSTOM_FRAME_CONTROL
            // if you want to, you can rebuild raylib dll with this flag
            // and uncomment method lower
            // SwapScreenBuffer(); // Flip the back buffer to screen (front buffer)

            currentTime = GetTime();
            updateDrawTime = currentTime - previousTime;

            if (targetFPS > 0) // We want a fixed frame rate
            {
                waitTime = 1.0f / targetFPS - updateDrawTime;
                if (waitTime > 0.0)
                {
                    WaitTime((float)waitTime);
                    currentTime = GetTime();
                    deltaTime = (float)(currentTime - previousTime);
                }
            }
            else
            {
                deltaTime = (float)updateDrawTime; // Framerate could be variable
            }

            previousTime = currentTime;
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}