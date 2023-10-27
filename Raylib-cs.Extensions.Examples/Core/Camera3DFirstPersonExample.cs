namespace Raylib_cs.Extensions.Game.Core;

public class Camera3DFirstPersonExample : IExample
{
    private const int MAX_COLUMNS = 20;

    public unsafe void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera first person");

        // Define the camera to look into our 3d world (position, target, up vector)
        Camera3D camera = new Camera3D(
            new Vector3(0.0f, 2.0f, 4.0f),
            new Vector3(0.0f, 2.0f, 0.0f),
            Vector3.UnitY,
            60.0f,
            CameraProjection.CAMERA_PERSPECTIVE
        );
        CameraMode cameraMode = CameraMode.CAMERA_FIRST_PERSON;

        // Generates some random columns
        float[] heights = new float[MAX_COLUMNS];
        Vector3[] positions = new Vector3[MAX_COLUMNS];
        Color[] colors = new Color[MAX_COLUMNS];
        Random random = new Random();

        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            heights[i] = random.Next(1, 12);
            positions[i] = new Vector3(
                GetRandomValue(-15, 15),
                heights[i] / 2.0f,
                GetRandomValue(-15, 15)
            );
            colors[i] = new Color(random.Next(20, 255), random.Next(10, 55), 30, 255);
        }

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            // Switch camera mode
            if (IsKeyPressed(KeyboardKey.KEY_ONE))
            {
                cameraMode = CameraMode.CAMERA_FREE;
                camera.up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.KEY_TWO))
            {
                cameraMode = CameraMode.CAMERA_FIRST_PERSON;
                camera.up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.KEY_THREE))
            {
                cameraMode = CameraMode.CAMERA_THIRD_PERSON;
                camera.up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.KEY_FOUR))
            {
                cameraMode = CameraMode.CAMERA_ORBITAL;
                camera.up = Vector3.UnitY; // Reset roll
            }

            // Switch camera projection
            if (IsKeyPressed(KeyboardKey.KEY_P))
            {
                if (camera.projection == CameraProjection.CAMERA_PERSPECTIVE)
                {
                    // Create isometric view
                    cameraMode = CameraMode.CAMERA_THIRD_PERSON;
                    // Note: The target distance is related to the render distance in the orthographic projection
                    camera.position = new Vector3(0.0f, 2.0f, -100.0f);
                    camera.target = new Vector3(0.0f, 2.0f, 0.0f);
                    camera.up = Vector3.UnitY;
                    camera.projection = CameraProjection.CAMERA_ORTHOGRAPHIC;
                    camera.fovy = 20.0f; // near plane width in CAMERA_ORTHOGRAPHIC
                    CameraYaw(&camera, -135 * DEG2RAD, true);
                    CameraPitch(&camera, -45 * DEG2RAD, true, true, false);
                }
                else if (camera.projection == CameraProjection.CAMERA_ORTHOGRAPHIC)
                {
                    // Reset to default view
                    cameraMode = CameraMode.CAMERA_THIRD_PERSON;
                    camera.position = new Vector3(0.0f, 2.0f, 10.0f);
                    camera.target = new Vector3(0.0f, 2.0f, 0.0f);
                    camera.up = Vector3.UnitY;
                    camera.projection = CameraProjection.CAMERA_PERSPECTIVE;
                    camera.fovy = 60.0f;
                }
            }

            // Update camera computes movement internally depending on the camera mode
            // Some default standard keyboard/mouse inputs are hardcoded to simplify use
            // For advance camera controls, it's reecommended to compute camera movement manually
            camera.Update(cameraMode); // Update camera

            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RAYWHITE.ClearBackground();

                camera.BeginMode();

                Color.LIGHTGRAY.DrawPlane(Vector3.Zero, new Vector2(32, 32)); // Draw ground
                Color.BLUE.DrawCube(new Vector3(-16.0f, 2.5f, 0.0f), 1.0f, 5.0f, 32.0f); // Draw a blue wall
                Color.LIME.DrawCube(new Vector3(16.0f, 2.5f, 32.0f), 1.0f, 5.0f, 32.0f); // Draw a green wall
                Color.GOLD.DrawCube(new Vector3(0.0f, 2.5f, 16.0f), 32.0f, 5.0f, 1.0f); // Draw a yellow wall

                // Draw some cubes around
                for (int i = 0; i < MAX_COLUMNS; i++)
                {
                    colors[i].DrawCube(positions[i], 2.0f, heights[i], 2.0f);
                    Color.MAROON.DrawCubeWires(positions[i], 2.0f, heights[i], 2.0f);
                }

                // Draw player cube
                if (cameraMode == CameraMode.CAMERA_THIRD_PERSON)
                {
                    Color.PURPLE.DrawCube(camera.target, 0.5f, 0.5f, 0.5f);
                    Color.DARKPURPLE.DrawCubeWires(camera.target, 0.5f, 0.5f, 0.5f);
                }
            }
            camera.EndMode();

            // Draw info boxes
            Color.SKYBLUE.Alpha(0.5f).DrawRectangle(5, 5, 330, 100);
            Color.BLUE.DrawRectangleLines(5, 5, 330, 100);

            Color.BLACK.DrawText("Camera controls:", 15, 15, 10);
            Color.BLACK.DrawText("- Move keys: W, A, S, D, Space, Left-Ctrl", 15, 30, 10);
            Color.BLACK.DrawText("- Look around: arrow keys or mouse", 15, 45, 10);
            Color.BLACK.DrawText("- Camera mode keys: 1, 2, 3, 4", 15, 60, 10);
            Color.BLACK.DrawText("- Zoom keys: num-plus, num-minus or mouse scroll", 15, 75, 10);
            Color.BLACK.DrawText("- Camera projection key: P", 15, 90, 10);

            Color.SKYBLUE.Alpha(0.5f).DrawRectangle(600, 5, 195, 100);
            Color.BLUE.DrawRectangleLines(600, 5, 195, 100);

            Color.BLACK.DrawText("Camera status:", 610, 15, 10);
            Color.BLACK.DrawText($"- Mode: {cameraMode.ToString().Replace("CAMERA_", null)}", 610, 30, 10);
            Color.BLACK.DrawText($"- Projection: {camera.projection.ToString().Replace("CAMERA_", null)}", 610, 45, 10);
            Color.BLACK.DrawText($"- Position: ({camera.position.X:00.000}, {camera.position.Y:00.000}, {camera.position.Z:00.000}", 610, 60, 10);
            Color.BLACK.DrawText($"- Target: ({camera.target.X:00.000}, {camera.target.Y:00.000}, {camera.target.Z:00.000})", 610, 75, 10);
            Color.BLACK.DrawText($"- Up: ({camera.up.X:00.000}, {camera.up.Y:00.000}), {camera.up.Z:00.000}", 610, 90, 10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}