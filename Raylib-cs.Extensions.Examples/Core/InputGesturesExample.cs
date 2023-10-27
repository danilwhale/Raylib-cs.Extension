namespace Raylib_cs.Extensions.Game.Core;

public class InputGesturesExample : IExample
{
    public const int MaxGestureStrings = 20;

    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input gestures");

        Vector2 touchPosition = new Vector2(0, 0);
        Rectangle touchArea = new Rectangle( 220, 10, screenWidth - 230.0f, screenHeight - 20.0f );

        int gesturesCount = 0;
        string[] gestureStrings = new string[MaxGestureStrings];

        Gesture currentGesture = Gesture.GESTURE_NONE;
        Gesture lastGesture = Gesture.GESTURE_NONE;

        //SetGesturesEnabled(0b0000000000001001);   // Enable only some gestures to be detected

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            lastGesture = currentGesture;
            currentGesture = GetGestureDetected();
            touchPosition = GetTouchPosition(0);

            if (touchArea.CheckCollisionPoint(touchPosition) && currentGesture != Gesture.GESTURE_NONE)
            {
                if (currentGesture != lastGesture)
                {
                    gestureStrings[gesturesCount] = currentGesture.ToString().Replace('_', ' ');

                    gesturesCount++;

                    // Reset gestures strings
                    if (gesturesCount >= MaxGestureStrings)
                    {
                        for (int i = 0; i < MaxGestureStrings; i++) gestureStrings[i] = string.Empty;

                        gesturesCount = 0;
                    }
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            touchArea.Draw(Color.GRAY);
            Color.RAYWHITE.DrawRectangle(225, 15, screenWidth - 240, screenHeight - 30);

            Color.GRAY.Alpha(0.5f).DrawText("GESTURES TEST AREA", screenWidth - 270, screenHeight - 40, 20);

            for (int i = 0; i < gesturesCount; i++)
            {
                if (i % 2 == 0) Color.LIGHTGRAY.Alpha(0.5f).DrawRectangle(10, 30 + 20 * i, 200, 20);
                else Color.LIGHTGRAY.Alpha(0.3f).DrawRectangle(10, 30 + 20 * i, 200, 20);

                if (i < gesturesCount - 1) Color.DARKGRAY.DrawText(gestureStrings[i], 35, 36 + 20 * i, 10);
                else Color.MAROON.DrawText(gestureStrings[i], 35, 36 + 20 * i, 10);
            }

            Color.GRAY.DrawRectangleLines(10, 29, 200, screenHeight - 50);
            Color.GRAY.DrawText("DETECTED GESTURES", 50, 15, 10);

            if (currentGesture != Gesture.GESTURE_NONE) Color.MAROON.DrawCircle(touchPosition, 30);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}