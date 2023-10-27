using System.Text;

namespace Raylib_cs.Extensions.Game;

public class FeatureTest : IExample
{
    public void Run(string[] args)
    {
        InitWindow(1024, 768, "test");
        SetTargetFPS(60);
        Rlgl.rlDisableBackfaceCulling();

// rcore >>
        string encoded = RaylibEx.EncodeDataBase64(Encoding.UTF8.GetBytes("Hello, World!"));
        string decoded = Encoding.UTF8.GetString(RaylibEx.DecodeDataBase64(encoded));

        Camera2D cam2d = new Camera2D(new Vector2(1024 / 2f, 768 / 2f), Vector2.Zero, 0, 1.5f);
        Camera3D cam3d = new Camera3D(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY, 70, CameraProjection.CAMERA_PERSPECTIVE);
// <<<

        bool use2DCamera = true;

// rtextures >>> 
        Image image = LoadImage("Assets/Textures/RaylibCsExtension.png");
        image.ColorContrast(0.5f);
        image.ColorBrightness(10);
        image.ColorTint(Color.RED);
        image.Resize(image.width * 2, image.height / 2);

        Texture2D texture = LoadTextureFromImage(image);

        image.Unload();
// <<<

// rmodels >>>
        Mesh sphereMesh = GenMeshCube(1, 1, 1);
        BoundingBox meshBox = sphereMesh.GetBoundingBox();
        Material material = LoadMaterialDefault();
        material.SetTexture(MaterialMapIndex.MATERIAL_MAP_ALBEDO, texture);
// <<<

        while (!WindowShouldClose())
        {
            // rcore >>>
            if (!use2DCamera) cam3d.Update(CameraMode.CAMERA_FIRST_PERSON);

            if (IsKeyPressed(KeyboardKey.KEY_F))
            {
                use2DCamera = !use2DCamera;
                if (!use2DCamera) DisableCursor();
                else EnableCursor();
            }
            // rcore <<<

            BeginDrawing();
            Color.SKYBLUE.ClearBackground(); // rcore

            if (use2DCamera) cam2d.BeginMode(); // rcore
            else cam3d.BeginMode();
            {
                // rshapes >>>
                Color.ORANGE.DrawCircle(new Vector2(0, 0), 64);
                new Rectangle(64, 64, 64, 64).DrawGradient(GradientDirection.Horizontal, Color.RED, Color.BLUE);
                // <<<

                // rtextures
                texture.Draw(new Vector2(-256, -256), 0, 1, Color.WHITE);

                // rmodels >>>
                sphereMesh.Draw(material, Matrix4x4.Identity);
                meshBox.Draw(Color.RED);
                // <<<

                // rtext >>>
                Color.RED.DrawText(encoded, 0, 0, 32);
                Color.GREEN.DrawText(decoded, 0, 32, 32);
                // <<<
            }
            if (use2DCamera) cam2d.EndMode();
            else cam3d.EndMode(); // rcore

            // rtext
            Color.ORANGE.DrawText("PRESS F TO SWITCH CAMERA DIMENSION", 8, 8, 32);

            EndDrawing();
        }

        texture.Unload(); // rtextures
        sphereMesh.Unload(); // rmodels
        material.Unload(); // rmodels

        CloseWindow();
    }
}