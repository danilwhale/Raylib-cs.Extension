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

        var touchPosition = new Vector2(0, 0);
        var touchArea = new Rectangle(220, 10, screenWidth - 230.0f, screenHeight - 20.0f);

        var gesturesCount = 0;
        var gestureStrings = new string[MaxGestureStrings];

        var currentGesture = Gesture.None;
        var lastGesture = Gesture.None;

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

            if (touchArea.CheckCollisionPoint(touchPosition) && currentGesture != Gesture.None)
                if (currentGesture != lastGesture)
                {
                    gestureStrings[gesturesCount] = currentGesture.ToString().Replace('_', ' ');

                    gesturesCount++;

                    // Reset gestures strings
                    if (gesturesCount >= MaxGestureStrings)
                    {
                        for (var i = 0; i < MaxGestureStrings; i++) gestureStrings[i] = string.Empty;

                        gesturesCount = 0;
                    }
                }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            Color.RayWhite.ClearBackground();

            touchArea.Draw(Color.Gray);
            Color.RayWhite.DrawRectangle(225, 15, screenWidth - 240, screenHeight - 30);

            Color.Gray.Alpha(0.5f).DrawText("GESTURES TEST AREA", screenWidth - 270, screenHeight - 40, 20);

            for (var i = 0; i < gesturesCount; i++)
            {
                if (i % 2 == 0) Color.LightGray.Alpha(0.5f).DrawRectangle(10, 30 + 20 * i, 200, 20);
                else Color.LightGray.Alpha(0.3f).DrawRectangle(10, 30 + 20 * i, 200, 20);

                if (i < gesturesCount - 1) Color.DarkGray.DrawText(gestureStrings[i], 35, 36 + 20 * i, 10);
                else Color.Maroon.DrawText(gestureStrings[i], 35, 36 + 20 * i, 10);
            }

            Color.Gray.DrawRectangleLines(10, 29, 200, screenHeight - 50);
            Color.Gray.DrawText("DETECTED GESTURES", 50, 15, 10);

            if (currentGesture != Gesture.None) Color.Maroon.DrawCircle(touchPosition, 30);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}