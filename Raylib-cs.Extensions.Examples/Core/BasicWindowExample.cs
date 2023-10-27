namespace Raylib_cs.Extensions.Game.Core;

public class BasicWindowExample : IExample
{
    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

        SetTargetFPS(60);
        
        while (!WindowShouldClose())
        {
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            Color.LIGHTGRAY.DrawText("Congrats! You created your first window!", 190, 200, 20);

            EndDrawing();
        }

        CloseWindow();
    }
}