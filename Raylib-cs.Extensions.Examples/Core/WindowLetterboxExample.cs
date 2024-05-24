namespace Raylib_cs.Extensions.Game.Core;

public class WindowLetterboxExample : IExample
{
    public void Run(string[] args)
    {
        const int windowWidth = 800;
        const int windowHeight = 450;

        // Enable config flags for resizable window and vertical synchro
        SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
        InitWindow(windowWidth, windowHeight, "raylib [core] example - window scale letterbox");
        SetWindowMinSize(320, 240);

        var gameScreenWidth = 640;
        var gameScreenHeight = 480;

        // Render texture initialization, used to hold the rendering result so we can easily resize it
        var target = LoadRenderTexture(gameScreenWidth, gameScreenHeight);
        target.Texture.SetFilter(TextureFilter.Bilinear);

        var colors = new Color[10];
        var random = new Random();
        for (var i = 0; i < 10; i++)
            colors[i] = new Color(random.Next(100, 250), random.Next(50, 150), random.Next(10, 100), 255);

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Compute required framebuffer scaling
            var scale = MathF.Min((float)GetScreenWidth() / gameScreenWidth,
                (float)GetScreenHeight() / gameScreenHeight);

            if (IsKeyPressed(KeyboardKey.Space))
                // Recalculate random colors for the bars
                for (var i = 0; i < 10; i++)
                    colors[i] = new Color(random.Next(100, 250), random.Next(50, 150), random.Next(10, 100), 255);

            // Update virtual mouse (clamped mouse value behind game screen)
            var mouse = GetMousePosition();
            var virtualMouse = Vector2.Zero;
            virtualMouse.X = (mouse.X - (GetScreenWidth() - gameScreenWidth * scale) * 0.5f) / scale;
            virtualMouse.Y = (mouse.Y - (GetScreenHeight() - gameScreenHeight * scale) * 0.5f) / scale;
            virtualMouse = Vector2.Clamp(virtualMouse, Vector2.Zero, new Vector2(gameScreenWidth, gameScreenHeight));

            // Apply the same transformation as the virtual mouse to the real mouse (i.e. to work with raygui)
            //SetMouseOffset(-(GetScreenWidth() - (gameScreenWidth*scale))*0.5f, -(GetScreenHeight() - (gameScreenHeight*scale))*0.5f);
            //SetMouseScale(1/scale, 1/scale);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            // Draw everything in the render texture, note this will not be rendered on screen, yet
            target.BeginMode();
            {
                Color.RayWhite.ClearBackground(); // Clear render texture background color

                for (var i = 0; i < 10; i++)
                    colors[i].DrawRectangle(0, gameScreenHeight / 10 * i, gameScreenWidth, gameScreenHeight / 10);

                Color.White.DrawText(
                    "If executed inside a window,\nyou can resize the window,\nand see the screen scaling!", 10, 25,
                    20);
                Color.Green.DrawText($"Default Mouse: [{mouse.X:0} , {mouse.Y:0}]", 350, 25, 20);
                Color.Yellow.DrawText($"Virtual Mouse: [{virtualMouse.X:0} , {virtualMouse.Y:0}]", 350, 55, 20);
            }
            target.EndMode();

            BeginDrawing();
            {
                Color.Black.ClearBackground(); // Clear screen background

                // Draw render texture to screen, properly scaled
                target.Texture.Draw(
                    new Rectangle(
                        0.0f, 0.0f,
                        target.Texture.Width, -target.Texture.Height
                    ),
                    new Rectangle(
                        (GetScreenWidth() - gameScreenWidth * scale) * 0.5f,
                        (GetScreenHeight() - gameScreenHeight * scale) * 0.5f,
                        gameScreenWidth * scale, gameScreenHeight * scale
                    ),
                    Vector2.Zero, 0.0f, Color.White);
            }
            EndDrawing();
            //--------------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        target.Unload(); // Unload render texture

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}