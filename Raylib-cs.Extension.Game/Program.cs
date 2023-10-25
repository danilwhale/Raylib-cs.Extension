global using static Raylib_cs.Raylib;
global using Raylib_cs;
global using System.Numerics;
global using System.Text;
global using Raylib_cs.Extension;

InitWindow(1024, 768, "test");
SetTargetFPS(60);
Rlgl.rlDisableBackfaceCulling();

string encoded = RaylibEx.EncodeDataBase64(Encoding.UTF8.GetBytes("Hello, World!"));
string decoded = Encoding.UTF8.GetString(RaylibEx.DecodeDataBase64(encoded));

Camera2D cam2d = new Camera2D(new Vector2(1024 / 2f, 768 / 2f), Vector2.Zero, 45, 2);
Camera3D cam3d = new Camera3D(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY, 70, CameraProjection.CAMERA_PERSPECTIVE);

bool use2DCamera = true;

while (!WindowShouldClose())
{
    if (!use2DCamera) cam3d.Update(CameraMode.CAMERA_FIRST_PERSON);
    if (IsKeyPressed(KeyboardKey.KEY_F))
    {
        use2DCamera = !use2DCamera;
        if (!use2DCamera) DisableCursor();
        else EnableCursor();
    }
    
    BeginDrawing();
    Color.SKYBLUE.ClearBackground();
    
    if (use2DCamera) cam2d.BeginMode();
    else cam3d.BeginMode();
    
    Color.ORANGE.DrawCircle(new Vector2(0, 0), 64);
    RectangleEx.FromVector(Vector2.One * 64, Vector2.One * 64).DrawGradient(GradientDirection.Horizontal, Color.RED, Color.BLUE);
    
    DrawText(encoded, 0, 0, 32, Color.RED);
    DrawText(decoded, 0, 32, 32, Color.GREEN);
    
    
    if (use2DCamera) cam2d.EndMode();
    else cam3d.EndMode();
            
    DrawText("PRESS F TO SWITCH CAMERA DIMENSION", 8, 8, 32, Color.ORANGE);
    
    EndDrawing();
}

CloseWindow();