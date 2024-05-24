namespace Raylib_cs.Extensions.Game.Core;

public class InputKeysExample : IExample
{
    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - keyboard input");

        var ballPosition = new Vector2(screenWidth / 2f, screenHeight / 2f);

        SetTargetFPS(60);

        while (!WindowShouldClose())
        {
            if (IsKeyDown(KeyboardKey.Right)) ballPosition.X += 2.0f;
            if (IsKeyDown(KeyboardKey.Left)) ballPosition.X -= 2.0f;
            if (IsKeyDown(KeyboardKey.Up)) ballPosition.Y -= 2.0f;
            if (IsKeyDown(KeyboardKey.Down)) ballPosition.Y += 2.0f;

            BeginDrawing();

            Color.RayWhite.ClearBackground();

            Color.DarkGray.DrawText("move the ball with arrow keys", 10, 10, 20);

            Color.Maroon.DrawCircle(ballPosition, 50);

            EndDrawing();
        }

        CloseWindow();
    }
}