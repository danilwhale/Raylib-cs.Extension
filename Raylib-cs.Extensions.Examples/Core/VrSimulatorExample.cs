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

        VrDeviceInfo device = new VrDeviceInfo()
        {
            // Oculus Rift CV1 parameters for simulator
            hResolution = 2160, // Horizontal resolution in pixels
            vResolution = 1200, // Vertical resolution in pixels
            hScreenSize = 0.133793f, // Horizontal size in meters
            vScreenSize = 0.0669f, // Vertical size in meters
            vScreenCenter = 0.04678f, // Screen center in meters
            eyeToScreenDistance = 0.041f, // Distance between eye and display in meters
            lensSeparationDistance = 0.07f, // Lens separation distance in meters
            interpupillaryDistance = 0.07f, // IPD (distance between pupils) in meters
        };

        // NOTE: CV1 uses fresnel-hybrid-asymmetric lenses with specific compute shaders
        // Following parameters are just an approximation to CV1 distortion stereo rendering
        device.lensDistortionValues[0] = 1.0f; // Lens distortion constant parameter 0
        device.lensDistortionValues[1] = 0.22f; // Lens distortion constant parameter 1
        device.lensDistortionValues[2] = 0.24f; // Lens distortion constant parameter 2
        device.lensDistortionValues[3] = 0.0f; // Lens distortion constant parameter 3
        device.chromaAbCorrection[0] = 0.996f; // Chromatic aberration correction parameter 0
        device.chromaAbCorrection[1] = -0.004f; // Chromatic aberration correction parameter 1
        device.chromaAbCorrection[2] = 1.014f; // Chromatic aberration correction parameter 2
        device.chromaAbCorrection[3] = 0.0f; // Chromatic aberration correction parameter 3

        // Load VR stereo config for VR device parameteres (Oculus Rift CV1 parameters)
        VrStereoConfig config = device.LoadConfig();

        // Distortion shader (uses device lens distortion and chroma)
        Shader distortion = LoadShader(null, $"Assets/Shaders/Distortion/GL{GlslVersion}.frag");

        // Update distortion shader with lens and distortion-scale parameters
        distortion.SetValue("leftLensCenter", config.leftLensCenter, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        distortion.SetValue("rightLensCenter", config.rightLensCenter, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        distortion.SetValue("leftScreenCenter", config.leftScreenCenter, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        distortion.SetValue("rightScreenCenter",config.rightScreenCenter, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
    
        distortion.SetValue("scale", config.scale, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        distortion.SetValue("scaleIn", config.scaleIn, ShaderUniformDataType.SHADER_UNIFORM_VEC2);
        distortion.SetValue("deviceWarpParam", device.lensDistortionValues, ShaderUniformDataType.SHADER_UNIFORM_VEC4);
        distortion.SetValue("chromaAbParam", device.chromaAbCorrection, ShaderUniformDataType.SHADER_UNIFORM_VEC4);

        // Initialize framebuffer for stereo rendering
        // NOTE: Screen size should match HMD aspect ratio
        RenderTexture2D target = LoadRenderTexture(device.hResolution, device.vResolution);

        // The target's height is flipped (in the source Rectangle), due to OpenGL reasons
        Rectangle sourceRec = new Rectangle(0.0f, 0.0f, target.texture.width, -target.texture.height);
        Rectangle destRec = new Rectangle(0.0f, 0.0f, GetScreenWidth(), GetScreenHeight());

        // Define the camera to look into our 3d world
        Camera3D camera = new Camera3D(
            new Vector3(5.0f, 2.0f, 5.0f), // Camera position
            new Vector3(0.0f, 2.0f, 0.0f), // Camera looking at point
            Vector3.UnitY, // Camera up vector
            60.0f, // Camera field-of-view Y
            CameraProjection.CAMERA_PERSPECTIVE // Camera projection type
            );

        Vector3 cubePosition = new Vector3(0.0f, 0.0f, 0.0f);

        DisableCursor(); // Limit cursor to relative movement inside the window

        SetTargetFPS(90); // Set our game to run at 90 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            camera.Update(CameraMode.CAMERA_FIRST_PERSON);
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            target.BeginMode();
            {
                Color.RAYWHITE.ClearBackground();
                
                config.BeginMode();
                camera.BeginMode();
                {
                    Color.RED.DrawCube(cubePosition, 2.0f, 2.0f, 2.0f);
                    Color.MAROON.DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f);
                    DrawGrid(40, 1.0f);
                }
                camera.EndMode();
                config.EndMode();
            }
            target.EndMode();

            BeginDrawing();
            {
                Color.RAYWHITE.ClearBackground();
                
                distortion.BeginMode();
                {
                    target.texture.Draw(sourceRec, destRec, Vector2.Zero, 0.0f, Color.WHITE);
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