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

    Rectangle scissorArea = new Rectangle(0, 0, 300, 300);
    bool scissorMode = true;

    SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
    //--------------------------------------------------------------------------------------

    // Main game loop
    while (!WindowShouldClose())    // Detect window close button or ESC key
    {
        // Update
        //----------------------------------------------------------------------------------
        if (IsKeyPressed(KeyboardKey.KEY_S)) scissorMode = !scissorMode;

        // Centre the scissor area around the mouse position
        scissorArea.x = GetMouseX() - scissorArea.width/2;
        scissorArea.y = GetMouseY() - scissorArea.height/2;
        //----------------------------------------------------------------------------------

        // Draw
        //----------------------------------------------------------------------------------
        BeginDrawing();
        {
            Color.RAYWHITE.ClearBackground();

            if (scissorMode) RaylibEx.BeginScissorMode(scissorArea);

            // Draw full screen rectangle and some text
            // NOTE: Only part defined by scissor area will be rendered
            Color.RED.DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight());
            Color.LIGHTGRAY.DrawText("Move the mouse around to reveal this text!", 190, 200, 20);

            if (scissorMode) EndScissorMode();

            scissorArea.DrawLines(1, Color.BLACK);
            Color.BLACK.DrawText("Press S to toggle scissor test", 10, 10, 20);
        }
        EndDrawing();
        //----------------------------------------------------------------------------------
    }

    // De-Initialization
    //--------------------------------------------------------------------------------------
    CloseWindow();        // Close window and OpenGL context
    //--------------------------------------------------------------------------------------

    }
}