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
        var camera = new Camera3D(
            new Vector3(0.0f, 2.0f, 4.0f),
            new Vector3(0.0f, 2.0f, 0.0f),
            Vector3.UnitY,
            60.0f,
            CameraProjection.Perspective
        );
        var cameraMode = CameraMode.FirstPerson;

        // Generates some random columns
        var heights = new float[MAX_COLUMNS];
        var positions = new Vector3[MAX_COLUMNS];
        var colors = new Color[MAX_COLUMNS];
        var random = new Random();

        for (var i = 0; i < MAX_COLUMNS; i++)
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
            if (IsKeyPressed(KeyboardKey.One))
            {
                cameraMode = CameraMode.Free;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.Two))
            {
                cameraMode = CameraMode.FirstPerson;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.Three))
            {
                cameraMode = CameraMode.ThirdPerson;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            if (IsKeyPressed(KeyboardKey.Four))
            {
                cameraMode = CameraMode.Orbital;
                camera.Up = Vector3.UnitY; // Reset roll
            }

            // Switch camera projection
            if (IsKeyPressed(KeyboardKey.P))
            {
                if (camera.Projection == CameraProjection.Perspective)
                {
                    // Create isometric view
                    cameraMode = CameraMode.ThirdPerson;
                    // Note: The target distance is related to the render distance in the orthographic projection
                    camera.Position = new Vector3(0.0f, 2.0f, -100.0f);
                    camera.Target = new Vector3(0.0f, 2.0f, 0.0f);
                    camera.Up = Vector3.UnitY;
                    camera.Projection = CameraProjection.Orthographic;
                    camera.FovY = 20.0f; // near plane width in Orthographic
                    CameraYaw(&camera, -135 * DEG2RAD, true);
                    CameraPitch(&camera, -45 * DEG2RAD, true, true, false);
                }
                else if (camera.Projection == CameraProjection.Orthographic)
                {
                    // Reset to default view
                    cameraMode = CameraMode.ThirdPerson;
                    camera.Position = new Vector3(0.0f, 2.0f, 10.0f);
                    camera.Target = new Vector3(0.0f, 2.0f, 0.0f);
                    camera.Up = Vector3.UnitY;
                    camera.Projection = CameraProjection.Perspective;
                    camera.FovY = 60.0f;
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
                Color.RayWhite.ClearBackground();

                camera.BeginMode();

                Color.LightGray.DrawPlane(Vector3.Zero, new Vector2(32, 32)); // Draw ground
                Color.Blue.DrawCube(new Vector3(-16.0f, 2.5f, 0.0f), 1.0f, 5.0f, 32.0f); // Draw a blue wall
                Color.Lime.DrawCube(new Vector3(16.0f, 2.5f, 32.0f), 1.0f, 5.0f, 32.0f); // Draw a green wall
                Color.Gold.DrawCube(new Vector3(0.0f, 2.5f, 16.0f), 32.0f, 5.0f, 1.0f); // Draw a yellow wall

                // Draw some cubes around
                for (var i = 0; i < MAX_COLUMNS; i++)
                {
                    colors[i].DrawCube(positions[i], 2.0f, heights[i], 2.0f);
                    Color.Maroon.DrawCubeWires(positions[i], 2.0f, heights[i], 2.0f);
                }

                // Draw player cube
                if (cameraMode == CameraMode.ThirdPerson)
                {
                    Color.Purple.DrawCube(camera.Target, 0.5f, 0.5f, 0.5f);
                    Color.DarkPurple.DrawCubeWires(camera.Target, 0.5f, 0.5f, 0.5f);
                }
            }
            camera.EndMode();

            // Draw info boxes
            Color.SkyBlue.Alpha(0.5f).DrawRectangle(5, 5, 330, 100);
            Color.Blue.DrawRectangleLines(5, 5, 330, 100);

            Color.Black.DrawText("Camera controls:", 15, 15, 10);
            Color.Black.DrawText("- Move keys: W, A, S, D, Space, Left-Ctrl", 15, 30, 10);
            Color.Black.DrawText("- Look around: arrow keys or mouse", 15, 45, 10);
            Color.Black.DrawText("- Camera mode keys: 1, 2, 3, 4", 15, 60, 10);
            Color.Black.DrawText("- Zoom keys: num-plus, num-minus or mouse scroll", 15, 75, 10);
            Color.Black.DrawText("- Camera projection key: P", 15, 90, 10);

            Color.SkyBlue.Alpha(0.5f).DrawRectangle(600, 5, 195, 100);
            Color.Blue.DrawRectangleLines(600, 5, 195, 100);

            Color.Black.DrawText("Camera status:", 610, 15, 10);
            Color.Black.DrawText($"- Mode: {cameraMode.ToString().Replace("CAMERA_", null)}", 610, 30, 10);
            Color.Black.DrawText($"- Projection: {camera.Projection.ToString().Replace("CAMERA_", null)}", 610, 45, 10);
            Color.Black.DrawText(
                $"- Position: ({camera.Position.X:00.000}, {camera.Position.Y:00.000}, {camera.Position.Z:00.000}", 610,
                60, 10);
            Color.Black.DrawText(
                $"- Target: ({camera.Target.X:00.000}, {camera.Target.Y:00.000}, {camera.Target.Z:00.000})", 610, 75,
                10);
            Color.Black.DrawText($"- Up: ({camera.Up.X:00.000}, {camera.Up.Y:00.000}), {camera.Up.Z:00.000}", 610, 90,
                10);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}