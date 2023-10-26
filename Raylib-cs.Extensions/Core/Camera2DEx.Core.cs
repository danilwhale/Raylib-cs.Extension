using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class Camera2DEx
{
    public static void BeginMode(this Camera2D camera) => Raylib.BeginMode2D(camera);
    public static void EndMode(this Camera2D camera) => Raylib.EndMode2D();

    public static Vector2 GetScreenToWorld(this Camera2D camera, Vector2 position) =>
        Raylib.GetScreenToWorld2D(position, camera);

    public static Vector2 GetWorldToScreen(this Camera2D camera, Vector2 position) =>
        Raylib.GetWorldToScreen2D(position, camera);
}