namespace Raylib_cs.Extensions.Game.Core;

public class SmoothPixelPerfectExample : IExample
{
    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        const int virtualScreenWidth = 160;
        const int virtualScreenHeight = 90;

        const float virtualRatio = screenWidth / virtualScreenWidth;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - smooth pixel-perfect camera");

        Camera2D worldSpaceCamera = new Camera2D
        {
            zoom = 1.0f
        }; // Game world camera

        Camera2D screenSpaceCamera = new Camera2D
        {
            zoom = 1.0f
        }; // Smoothing camera

        RenderTexture2D target = LoadRenderTexture(virtualScreenWidth, virtualScreenHeight); // This is where we'll draw all our objects.

        Rectangle rec01 = new Rectangle(70.0f, 35.0f, 20.0f, 20.0f);
        Rectangle rec02 = new Rectangle(90.0f, 55.0f, 30.0f, 10.0f);
        Rectangle rec03 = new Rectangle(80.0f, 65.0f, 15.0f, 25.0f);

        // The target's height is flipped (in the source Rectangle), due to OpenGL reasons
        Rectangle sourceRec = new Rectangle(0.0f, 0.0f, target.texture.width, -target.texture.height);
        Rectangle destRec = new Rectangle(-virtualRatio, -virtualRatio, screenWidth + (virtualRatio * 2), screenHeight + (virtualRatio * 2));

        Vector2 origin = Vector2.Zero;

        float rotation = 0.0f;

        float cameraX = 0.0f;
        float cameraY = 0.0f;

        SetTargetFPS(60);
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            rotation += 60.0f * GetFrameTime(); // Rotate the rectangles, 60 degrees per second

            // Make the camera move to demonstrate the effect
            cameraX = MathF.Sin((float)GetTime()) * 50.0f - 10.0f;
            cameraY = MathF.Cos((float)GetTime()) * 30.0f;

            // Set the camera's target to the values computed above
            screenSpaceCamera.target = new Vector2(cameraX, cameraY);

            // Round worldSpace coordinates, keep decimals into screenSpace coordinates
            worldSpaceCamera.target.X = (int)screenSpaceCamera.target.X;
            screenSpaceCamera.target.X -= worldSpaceCamera.target.X;
            screenSpaceCamera.target.X *= virtualRatio;

            worldSpaceCamera.target.Y = (int)screenSpaceCamera.target.Y;
            screenSpaceCamera.target.Y -= worldSpaceCamera.target.Y;
            screenSpaceCamera.target.Y *= virtualRatio;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            target.BeginMode();
            {
                Color.RAYWHITE.ClearBackground();

                worldSpaceCamera.BeginMode();
                {
                    rec01.Draw(origin, rotation, Color.BLACK);
                    rec02.Draw(origin, -rotation, Color.RED);
                    rec03.Draw(origin, rotation + 45.0f, Color.BLUE);
                }
                worldSpaceCamera.EndMode();
            }
            target.EndMode();

            BeginDrawing();
            {
                Color.RED.ClearBackground();

                screenSpaceCamera.BeginMode();
                {
                    target.texture.Draw(sourceRec, destRec, origin, 0.0f, Color.WHITE);
                }
                screenSpaceCamera.EndMode();

                Color.DARKBLUE.DrawText($"Screen resolution: {screenWidth}x{screenHeight}", 10, 10, 20);
                Color.DARKGREEN.DrawText($"World resolution: {virtualScreenWidth}x{virtualScreenHeight}", 10, 40, 20);
                DrawFPS(GetScreenWidth() - 95, 10);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        target.Unload(); // Unload render texture

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}