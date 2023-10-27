namespace Raylib_cs.Extensions.Game.Core;

public class MouseWheelInputExample : IExample
{
    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input mouse wheel");

        int boxPositionY = screenHeight / 2 - 40;
        int scrollSpeed = 4;

        SetTargetFPS(60);
        
        while (!WindowShouldClose())
        {
            boxPositionY -= (int)(GetMouseWheelMove() * scrollSpeed);
            
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            Color.MAROON.DrawRectangle(screenWidth / 2 - 40, boxPositionY, 80, 80);

            Color.GRAY.DrawText("Use mouse wheel to move the cube up and down!", 10, 10, 20);
            Color.LIGHTGRAY.DrawText($"Box position Y: {boxPositionY:D}", 10, 40, 20);

            EndDrawing();
        }
        
        CloseWindow();
    }
}