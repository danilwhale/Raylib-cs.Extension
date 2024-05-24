namespace Raylib_cs.Extensions.Game.Core;

public class MouseInputExample : IExample
{
    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - mouse input");

        var ballPosition = new Vector2(-100, -100);
        var ballColor = Color.DarkBlue;

        SetTargetFPS(60);

        while (!WindowShouldClose())
        {
            ballPosition = GetMousePosition();

            if (IsMouseButtonPressed(MouseButton.Left)) ballColor = Color.Maroon;
            else if (IsMouseButtonPressed(MouseButton.Middle)) ballColor = Color.Lime;
            else if (IsMouseButtonPressed(MouseButton.Right)) ballColor = Color.DarkBlue;
            else if (IsMouseButtonPressed(MouseButton.Side)) ballColor = Color.Purple;
            else if (IsMouseButtonPressed(MouseButton.Extra)) ballColor = Color.Yellow;
            else if (IsMouseButtonPressed(MouseButton.Forward)) ballColor = Color.Orange;
            else if (IsMouseButtonPressed(MouseButton.Back)) ballColor = Color.Beige;

            BeginDrawing();

            Color.RayWhite.ClearBackground();

            ballColor.DrawCircle(ballPosition, 40);

            Color.DarkGray.DrawText("move ball with mouse and click mouse button to change color", 10, 10, 20);

            EndDrawing();
        }

        CloseWindow();
    }
}