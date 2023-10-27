using System.Runtime.InteropServices;

namespace Raylib_cs.Extensions.Game.Core;

public class CustomLoggingExample : IExample
{
    public unsafe void Run(string[] args)
    {
        // Custom logging function

        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // Set custom logger
        RaylibEx.SetTraceLogCallback(CustomLog);

        InitWindow(screenWidth, screenHeight, "raylib [core] example - custom logging");

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // TODO: Update your variables here
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            Color.LIGHTGRAY.DrawText("Check out the console output to see the custom logger in action!", 60, 200, 20);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    unsafe void CustomLog(TraceLogLevel msgType, sbyte* text, sbyte* args)
    {
        DateTime now = DateTime.Now;
        string timeStr = now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.Write($"[{timeStr}] ");

        switch (msgType)
        {
            case TraceLogLevel.LOG_INFO:
                Console.Write("[INFO] : ");
                break;
            case TraceLogLevel.LOG_ERROR:
                Console.Write("[ERROR]: ");
                break;
            case TraceLogLevel.LOG_WARNING:
                Console.Write("[WARN] : ");
                break;
            case TraceLogLevel.LOG_DEBUG:
                Console.Write("[DEBUG]: ");
                break;
        }

        Console.Write(Logging.GetLogMessage((nint)text, (nint)args));
        Console.WriteLine();
    }
}