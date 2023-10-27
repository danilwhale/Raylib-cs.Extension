namespace Raylib_cs.Extensions.Game.Core;

public class MultitouchInputExample : IExample
{
    private const int MaxTouchPoints = 10;

    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input multitouch");

        Vector2[] touchPositions = new Vector2[MaxTouchPoints];

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //---------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Get the touch point count ( how many fingers are touching the screen )
            int tCount = GetTouchPointCount();
            // Clamp touch points available ( set the maximum touch points allowed )
            if (tCount > MaxTouchPoints) tCount = MaxTouchPoints;
            // Get touch points positions
            for (int i = 0; i < tCount; ++i) touchPositions[i] = GetTouchPosition(i);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            for (int i = 0; i < tCount; ++i)
            {
                // Make sure point is not (0, 0) as this means there is no touch for it
                if ((touchPositions[i].X > 0) && (touchPositions[i].Y > 0))
                {
                    // Draw circle and touch index number
                    Color.ORANGE.DrawCircle(touchPositions[i], 34);
                    Color.BLACK.DrawText(i.ToString(), (int)touchPositions[i].X - 10, (int)touchPositions[i].Y - 70, 40);
                }
            }

            Color.DARKGRAY.DrawText("touch the screen at multiple locations to get multiple balls", 10, 10, 20);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}