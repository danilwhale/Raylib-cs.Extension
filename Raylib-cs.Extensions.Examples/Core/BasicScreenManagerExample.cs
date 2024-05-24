namespace Raylib_cs.Extensions.Game.Core;

public class BasicScreenManagerExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - basic screen manager");

        var currentScreen = GameScreen.Logo;

        // TODO: Initialize all required variables and load all required data here!

        var framesCounter = 0; // Useful to count frames

        SetTargetFPS(60); // Set desired framerate (frames-per-second)
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            switch (currentScreen)
            {
                case GameScreen.Logo:

                    // TODO: Update LOGO screen variables here!

                    framesCounter++; // Count frames

                    // Wait for 2 seconds (120 frames) before jumping to TITLE screen
                    if (framesCounter > 120) currentScreen = GameScreen.Title;

                    break;
                case GameScreen.Title:

                    // TODO: Update TITLE screen variables here!

                    // Press enter to change to GAMEPLAY screen
                    if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                        currentScreen = GameScreen.Gameplay;

                    break;
                case GameScreen.Gameplay:

                    // TODO: Update GAMEPLAY screen variables here!

                    // Press enter to change to ENDING screen
                    if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                        currentScreen = GameScreen.Ending;

                    break;
                case GameScreen.Ending:

                    // TODO: Update ENDING screen variables here!

                    // Press enter to return to TITLE screen
                    if (IsKeyPressed(KeyboardKey.Enter) || IsGestureDetected(Gesture.Tap))
                        currentScreen = GameScreen.Title;

                    break;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                switch (currentScreen)
                {
                    case GameScreen.Logo:

                        // TODO: Draw LOGO screen here!
                        Color.LightGray.DrawText("LOGO SCREEN", 20, 20, 40);
                        Color.Gray.DrawText("WAIT for 2 SECONDS...", 290, 220, 20);

                        break;
                    case GameScreen.Title:

                        // TODO: Draw TITLE screen here!
                        Color.Green.DrawRectangle(0, 0, screenWidth, screenHeight);
                        Color.DarkGreen.DrawText("TITLE SCREEN", 20, 20, 40);
                        Color.DarkGreen.DrawText("PRESS ENTER or TAP to JUMP to GAMEPLAY SCREEN", 120, 220, 20);

                        break;
                    case GameScreen.Gameplay:

                        // TODO: Draw GAMEPLAY screen here!
                        Color.Purple.DrawRectangle(0, 0, screenWidth, screenHeight);
                        Color.Maroon.DrawText("GAMEPLAY SCREEN", 20, 20, 40);
                        Color.Maroon.DrawText("PRESS ENTER or TAP to JUMP to ENDING SCREEN", 130, 220, 20);

                        break;
                    case GameScreen.Ending:

                        // TODO: Draw ENDING screen here!
                        Color.Blue.DrawRectangle(0, 0, screenWidth, screenHeight);
                        Color.DarkBlue.DrawText("ENDING SCREEN", 20, 20, 40);
                        Color.DarkBlue.DrawText("PRESS ENTER or TAP to RETURN to TITLE SCREEN", 120, 220, 20);

                        break;
                }
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------

        // TODO: Unload all loaded data (textures, fonts, audio) here!

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    private enum GameScreen
    {
        Logo,
        Title,
        Gameplay,
        Ending
    }
}