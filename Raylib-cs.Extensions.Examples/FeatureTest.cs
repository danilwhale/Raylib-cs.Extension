using System.Text;

namespace Raylib_cs.Extensions.Game;

public class FeatureTest : IExample
{
    public void Run(string[] args)
    {
        InitWindow(1024, 768, "test");
        SetTargetFPS(60);
        Rlgl.DisableBackfaceCulling();

// rcore >>
        var encoded = RaylibEx.EncodeDataBase64(Encoding.UTF8.GetBytes("Hello, World!"));
        var decoded = Encoding.UTF8.GetString(RaylibEx.DecodeDataBase64(encoded));

        var cam2d = new Camera2D(new Vector2(1024 / 2f, 768 / 2f), Vector2.Zero, 0, 1.5f);
        var cam3d = new Camera3D(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY, 70, CameraProjection.Perspective);
// <<<

        var use2DCamera = true;

// rtextures >>> 
        var image = LoadImage("Assets/Textures/RaylibCsExtension.png");
        image.ColorContrast(0.5f);
        image.ColorBrightness(10);
        image.ColorTint(Color.Red);
        image.Resize(image.Width * 2, image.Height / 2);

        var texture = LoadTextureFromImage(image);

        image.Unload();
// <<<

// rmodels >>>
        var sphereMesh = GenMeshCube(1, 1, 1);
        var meshBox = sphereMesh.GetBoundingBox();
        var material = LoadMaterialDefault();
        material.SetTexture(MaterialMapIndex.Albedo, texture);
// <<<

        while (!WindowShouldClose())
        {
            // rcore >>>
            if (!use2DCamera) cam3d.Update(CameraMode.FirstPerson);

            if (IsKeyPressed(KeyboardKey.F))
            {
                use2DCamera = !use2DCamera;
                if (!use2DCamera) DisableCursor();
                else EnableCursor();
            }
            // rcore <<<

            BeginDrawing();
            Color.SkyBlue.ClearBackground(); // rcore

            if (use2DCamera) cam2d.BeginMode(); // rcore
            else cam3d.BeginMode();
            {
                // rshapes >>>
                Color.Orange.DrawCircle(new Vector2(0, 0), 64);
                new Rectangle(64, 64, 64, 64).DrawGradient(GradientDirection.Horizontal, Color.Red, Color.Blue);
                // <<<

                // rtextures
                texture.Draw(new Vector2(-256, -256), 0, 1, Color.White);

                // rmodels >>>
                sphereMesh.Draw(material, Matrix4x4.Identity);
                meshBox.Draw(Color.Red);
                // <<<

                // rtext >>>
                Color.Red.DrawText(encoded, 0, 0, 32);
                Color.Green.DrawText(decoded, 0, 32, 32);
                // <<<
            }
            if (use2DCamera) cam2d.EndMode();
            else cam3d.EndMode(); // rcore

            // rtext
            Color.Orange.DrawText("PRESS F TO SWITCH CAMERA DIMENSION", 8, 8, 32);

            EndDrawing();
        }

        texture.Unload(); // rtextures
        sphereMesh.Unload(); // rmodels
        material.Unload(); // rmodels

        CloseWindow();
    }
}