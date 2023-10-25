using System.Numerics;

namespace Raylib_cs.Extension.Core;

public static partial class Camera3DEx
{
    public static void BeginMode(this Camera3D camera) => Raylib.BeginMode3D(camera);
    public static void EndMode(this Camera3D camera) => Raylib.EndMode3D();

    public static Ray GetMouseRay(this Camera3D camera, Vector2 mousePosition) =>
        Raylib.GetMouseRay(mousePosition, camera);

    public static Vector2 GetWorldToScreen(this Camera3D camera, Vector3 position) =>
        Raylib.GetWorldToScreen(position, camera);

    public static Vector2 GetWorldToScreen(this Camera3D camera, Vector3 position, int width, int height) =>
        Raylib.GetWorldToScreenEx(position, camera, width, height);

    public static Matrix4x4 GetMatrix(this Camera3D camera) => Raylib.GetCameraMatrix(camera);

    public static void Update(this ref Camera3D camera, CameraMode mode) => Raylib.UpdateCamera(ref camera, mode);

    public static void Update(this ref Camera3D camera, Vector3 movement, Vector3 rotation, float zoom) =>
        Raylib.UpdateCameraPro(ref camera, movement, rotation, zoom);
}