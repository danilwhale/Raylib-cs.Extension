namespace Raylib_cs.Extensions.Game.Core;

public class VrSimulatorExample : IExample
{
    public const int GlslVersion = 330; // PLATFORM_DESKTOP - 330 (GL 3.3)
    // PLATFORM_ANDROID - 100 (GL 1.0)
    // PLATFORM_WEB     - 100 (GL 1.0)

    public unsafe void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        // NOTE: screenWidth/screenHeight should match VR device aspect ratio
        InitWindow(screenWidth, screenHeight, "raylib [core] example - vr simulator");

        // VR device parameters definition

        var device = new VrDeviceInfo
        {
            // Oculus Rift CV1 parameters for simulator
            HResolution = 2160, // Horizontal resolution in pixels
            VResolution = 1200, // Vertical resolution in pixels
            HScreenSize = 0.133793f, // Horizontal size in meters
            VScreenSize = 0.0669f, // Vertical size in meters
            VScreenCenter = 0.04678f, // Screen center in meters
            EyeToScreenDistance = 0.041f, // Distance between eye and display in meters
            LensSeparationDistance = 0.07f, // Lens separation distance in meters
            InterpupillaryDistance = 0.07f // IPD (distance between pupils) in meters
        };

        // NOTE: CV1 uses fresnel-hybrid-asymmetric lenses with specific compute shaders
        // Following parameters are just an approximation to CV1 distortion stereo rendering
        device.LensDistortionValues[0] = 1.0f; // Lens distortion constant parameter 0
        device.LensDistortionValues[1] = 0.22f; // Lens distortion constant parameter 1
        device.LensDistortionValues[2] = 0.24f; // Lens distortion constant parameter 2
        device.LensDistortionValues[3] = 0.0f; // Lens distortion constant parameter 3
        device.ChromaAbCorrection[0] = 0.996f; // Chromatic aberration correction parameter 0
        device.ChromaAbCorrection[1] = -0.004f; // Chromatic aberration correction parameter 1
        device.ChromaAbCorrection[2] = 1.014f; // Chromatic aberration correction parameter 2
        device.ChromaAbCorrection[3] = 0.0f; // Chromatic aberration correction parameter 3

        // Load VR stereo config for VR device parameteres (Oculus Rift CV1 parameters)
        var config = device.LoadConfig();

        // Distortion shader (uses device lens distortion and chroma)
        var distortion = LoadShader(null, $"Assets/Shaders/Distortion/GL{GlslVersion}.frag");

        // Update distortion shader with lens and distortion-scale parameters
        distortion.SetValue("leftLensCenter", config.LeftLensCenter, ShaderUniformDataType.Vec2);
        distortion.SetValue("rightLensCenter", config.RightLensCenter, ShaderUniformDataType.Vec2);
        distortion.SetValue("leftScreenCenter", config.LeftScreenCenter, ShaderUniformDataType.Vec2);
        distortion.SetValue("rightScreenCenter", config.RightScreenCenter, ShaderUniformDataType.Vec2);

        distortion.SetValue("scale", config.Scale, ShaderUniformDataType.Vec2);
        distortion.SetValue("scaleIn", config.ScaleIn, ShaderUniformDataType.Vec2);
        distortion.SetValue("deviceWarpParam", device.LensDistortionValues, ShaderUniformDataType.Vec4);
        distortion.SetValue("chromaAbParam", device.ChromaAbCorrection, ShaderUniformDataType.Vec4);

        // Initialize framebuffer for stereo rendering
        // NOTE: Screen size should match HMD aspect ratio
        var target = LoadRenderTexture(device.HResolution, device.VResolution);

        // The target's height is flipped (in the source Rectangle), due to OpenGL reasons
        var sourceRec = new Rectangle(0.0f, 0.0f, target.Texture.Width, -target.Texture.Height);
        var destRec = new Rectangle(0.0f, 0.0f, GetScreenWidth(), GetScreenHeight());

        // Define the camera to look into our 3d world
        var camera = new Camera3D(
            new Vector3(5.0f, 2.0f, 5.0f), // Camera position
            new Vector3(0.0f, 2.0f, 0.0f), // Camera looking at point
            Vector3.UnitY, // Camera up vector
            60.0f, // Camera field-of-view Y
            CameraProjection.Perspective // Camera projection type
        );

        var cubePosition = new Vector3(0.0f, 0.0f, 0.0f);

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(90); // Set our game to run at 90 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            camera.Update(CameraMode.FirstPerson);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            target.BeginMode();
            {
                Color.RayWhite.ClearBackground();

                config.BeginMode();
                camera.BeginMode();
                {
                    Color.Red.DrawCube(cubePosition, 2.0f, 2.0f, 2.0f);
                    Color.Maroon.DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f);
                    DrawGrid(40, 1.0f);
                }
                camera.EndMode();
                config.EndMode();
            }
            target.EndMode();

            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                distortion.BeginMode();
                {
                    target.Texture.Draw(sourceRec, destRec, Vector2.Zero, 0.0f, Color.White);
                }
                distortion.EndMode();

                DrawFPS(10, 10);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        config.Unload(); // Unload stereo config

        target.Unload(); // Unload stereo render fbo
        distortion.Unload(); // Unload distortion shader

        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}