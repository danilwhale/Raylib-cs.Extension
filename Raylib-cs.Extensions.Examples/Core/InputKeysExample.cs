namespace Raylib_cs.Extensions.Game.Core;

public class InputKeysExample : IExample
{
    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - keyboard input");

        Vector2 ballPosition = new Vector2(screenWidth / 2f, screenHeight / 2f);

        SetTargetFPS(60);
        
        while (!WindowShouldClose())
        {
            if (IsKeyDown(KeyboardKey.KEY_RIGHT)) ballPosition.X += 2.0f;
            if (IsKeyDown(KeyboardKey.KEY_LEFT)) ballPosition.X -= 2.0f;
            if (IsKeyDown(KeyboardKey.KEY_UP)) ballPosition.Y -= 2.0f;
            if (IsKeyDown(KeyboardKey.KEY_DOWN)) ballPosition.Y += 2.0f;
            
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            Color.DARKGRAY.DrawText("move the ball with arrow keys", 10, 10, 20);

            Color.MAROON.DrawCircle(ballPosition, 50);

            EndDrawing();
        }
        
        CloseWindow();
    }
}