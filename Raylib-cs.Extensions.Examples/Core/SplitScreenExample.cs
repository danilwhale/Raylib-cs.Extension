namespace Raylib_cs.Extensions.Game.Core;

public class SplitScreenExample : IExample
{
    public void Run(string[] args)
    {
            // Initialization
    //--------------------------------------------------------------------------------------
    const int screenWidth = 800;
    const int screenHeight = 450;

    InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera split screen");

    // Setup player 1 camera and screen
    Camera3D cameraPlayer1 = new Camera3D(
        new Vector3(-0.0f, 1.0f, -3.0f), 
        new Vector3(0.0f, 1.0f, 0.0f), 
        Vector3.UnitY, 
        45.0f, 
        CameraProjection.CAMERA_PERSPECTIVE
        );

    RenderTexture2D screenPlayer1 = LoadRenderTexture(screenWidth/2, screenHeight);

    // Setup player two camera and screen
    Camera3D cameraPlayer2 = new Camera3D(
        new Vector3(-3.0f, 3.0f, 0.0f), 
        new Vector3(0.0f, 3.0f, 0.0f), 
        Vector3.UnitY, 
        45.0f, 
        CameraProjection.CAMERA_PERSPECTIVE
        );

    RenderTexture2D screenPlayer2 = LoadRenderTexture(screenWidth / 2, screenHeight);

    // Build a flipped rectangle the size of the split view to use for drawing later
    Rectangle splitScreenRect = new Rectangle(0.0f, 0.0f, (float)screenPlayer1.texture.width, (float)-screenPlayer1.texture.height);
    
    // Grid data
    int count = 5;
    float spacing = 4;

    SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
    //--------------------------------------------------------------------------------------

    // Main game loop
    while (!WindowShouldClose())    // Detect window close button or ESC key
    {
        // Update
        //----------------------------------------------------------------------------------
        // If anyone moves this frame, how far will they move based on the time since the last frame
        // this moves thigns at 10 world units per second, regardless of the actual FPS
        float offsetThisFrame = 10.0f*GetFrameTime();

        // Move Player1 forward and backwards (no turning)
        if (IsKeyDown(KeyboardKey.KEY_W))
        {
            cameraPlayer1.position.Z += offsetThisFrame;
            cameraPlayer1.target.Z += offsetThisFrame;
        }
        else if (IsKeyDown(KeyboardKey.KEY_S))
        {
            cameraPlayer1.position.Z -= offsetThisFrame;
            cameraPlayer1.target.Z -= offsetThisFrame;
        }

        // Move Player2 forward and backwards (no turning)
        if (IsKeyDown(KeyboardKey.KEY_UP))
        {
            cameraPlayer2.position.X += offsetThisFrame;
            cameraPlayer2.target.X += offsetThisFrame;
        }
        else if (IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            cameraPlayer2.position.X -= offsetThisFrame;
            cameraPlayer2.target.X -= offsetThisFrame;
        }
        //----------------------------------------------------------------------------------

        // Draw
        //----------------------------------------------------------------------------------
        // Draw Player1 view to the render texture
        screenPlayer1.BeginMode();
        {
            Color.SKYBLUE.ClearBackground();

            cameraPlayer1.BeginMode();
            {
                // Draw scene: grid of cube trees on a plane to make a "world"
                Color.BEIGE.DrawPlane(Vector3.Zero, new Vector2(50.0f, 50.0f)); // Simple world plane

                for (float x = -count * spacing; x <= count * spacing; x += spacing)
                {
                    for (float z = -count * spacing; z <= count * spacing; z += spacing)
                    {
                        Color.LIME.DrawCube(new Vector3(x, 1.5f, z), 1, 1, 1);
                        Color.BROWN.DrawCube(new Vector3(x, 0.5f, z), 0.25f, 1, 0.25f);
                    }
                }

                // Draw a cube at each player's position
                Color.RED.DrawCube(cameraPlayer1.position, 1, 1, 1);
                Color.BLUE.DrawCube(cameraPlayer2.position, 1, 1, 1);
            }
            cameraPlayer1.EndMode();

            Color.RAYWHITE.Alpha(0.8f).DrawRectangle(0, 0, GetScreenWidth() / 2, 40);
            Color.MAROON.DrawText("PLAYER1: W/S to move", 10, 10, 20);
        }
        screenPlayer1.BeginMode();

        // Draw Player2 view to the render texture
        screenPlayer2.BeginMode();
        {
            Color.SKYBLUE.ClearBackground();

            cameraPlayer2.BeginMode();
            {
                // Draw scene: grid of cube trees on a plane to make a "world"
                Color.BEIGE.DrawPlane(Vector3.Zero, new Vector2(50.0f, 50.0f)); // Simple world plane

                for (float x = -count * spacing; x <= count * spacing; x += spacing)
                {
                    for (float z = -count * spacing; z <= count * spacing; z += spacing)
                    {
                        Color.LIME.DrawCube(new Vector3(x, 1.5f, z), 1, 1, 1);
                        Color.BROWN.DrawCube(new Vector3(x, 0.5f, z), 0.25f, 1, 0.25f);
                    }
                }

                // Draw a cube at each player's position
                Color.RED.DrawCube(cameraPlayer1.position, 1, 1, 1);
                Color.BLUE.DrawCube(cameraPlayer2.position, 1, 1, 1);
            }
            cameraPlayer2.EndMode();

            Color.RAYWHITE.Alpha(0.8f).DrawRectangle(0, 0, GetScreenWidth() / 2, 40);
            Color.DARKBLUE.DrawText("PLAYER2: UP/DOWN to move", 10, 10, 20);

        }screenPlayer2.EndMode();

        // Draw both views render textures to the screen side by side
        BeginDrawing();
        {
            Color.BLACK.ClearBackground();

            screenPlayer1.texture.Draw(splitScreenRect, new Vector2(0.0f, 0.0f), Color.WHITE);
            screenPlayer2.texture.Draw(splitScreenRect, new Vector2(screenWidth / 2, 0.0f), Color.WHITE);

            Color.LIGHTGRAY.DrawRectangle(GetScreenWidth() / 2 - 2, 0, 4, GetScreenHeight());
        }EndDrawing();
    }

    // De-Initialization
    //--------------------------------------------------------------------------------------
    screenPlayer1.Unload(); // Unload render texture
    screenPlayer2.Unload();  // Unload render texture

    CloseWindow();                      // Close window and OpenGL context
    //--------------------------------------------------------------------------------------

    }
}