using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class Camera3DEx
{
    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    public static void BeginMode(this Camera3D camera) => Raylib.BeginMode3D(camera);
    
    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    public static void EndMode(this Camera3D camera) => Raylib.EndMode3D();
    
    /// <summary>
    /// Get a ray trace from mouse position
    /// </summary>
    public static Ray GetMouseRay(this Camera3D camera, Vector2 mousePosition) =>
        Raylib.GetMouseRay(mousePosition, camera);
    
    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreen(this Camera3D camera, Vector3 position) =>
        Raylib.GetWorldToScreen(position, camera);
    
    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreen(this Camera3D camera, Vector3 position, int width, int height) =>
        Raylib.GetWorldToScreenEx(position, camera, width, height);
    
    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    public static Matrix4x4 GetMatrix(this Camera3D camera) => Raylib.GetCameraMatrix(camera);
    
    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public static void Update(this ref Camera3D camera, CameraMode mode) => Raylib.UpdateCamera(ref camera, mode);
    
    /// <summary>
    /// Update camera movement/rotation
    /// </summary>
    public static void Update(this ref Camera3D camera, Vector3 movement, Vector3 rotation, float zoom) =>
        Raylib.UpdateCameraPro(ref camera, movement, rotation, zoom);
}