namespace Raylib_cs.Extensions.Game.Core;

public class MouseInputExample : IExample
{
    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - mouse input");

        Vector2 ballPosition = new Vector2(-100, -100);
        Color ballColor = Color.DARKBLUE;

        SetTargetFPS(60);
        
        while (!WindowShouldClose())
        {
            ballPosition = GetMousePosition();

            if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) ballColor = Color.MAROON;
            else if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_MIDDLE)) ballColor = Color.LIME;
            else if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT)) ballColor = Color.DARKBLUE;
            else if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_SIDE)) ballColor = Color.PURPLE;
            else if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_EXTRA)) ballColor = Color.YELLOW;
            else if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_FORWARD)) ballColor = Color.ORANGE;
            else if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_BACK)) ballColor = Color.BEIGE;

            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            ballColor.DrawCircle(ballPosition, 40);

            Color.DARKGRAY.DrawText("move ball with mouse and click mouse button to change color", 10, 10, 20);

            EndDrawing();
        }
        
        CloseWindow();
    }
}