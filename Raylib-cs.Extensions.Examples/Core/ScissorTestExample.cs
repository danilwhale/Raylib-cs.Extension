namespace Raylib_cs.Extensions.Game.Core;

public class ScissorTestExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - scissor test");

        var scissorArea = new Rectangle(0, 0, 300, 300);
        var scissorMode = true;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.S)) scissorMode = !scissorMode;

            // Centre the scissor area around the mouse position
            scissorArea.X = GetMouseX() - scissorArea.Width / 2;
            scissorArea.Y = GetMouseY() - scissorArea.Height / 2;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                if (scissorMode) RaylibEx.BeginScissorMode(scissorArea);

                // Draw full screen rectangle and some text
                // NOTE: Only part defined by scissor area will be rendered
                Color.Red.DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight());
                Color.LightGray.DrawText("Move the mouse around to reveal this text!", 190, 200, 20);

                if (scissorMode) EndScissorMode();

                scissorArea.DrawLines(1, Color.Black);
                Color.Black.DrawText("Press S to toggle scissor test", 10, 10, 20);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}