using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class Camera2DEx
{
    /// <summary>
    /// Begin 2D mode with custom camera (2D)
    /// </summary>
    /// <param name="camera"></param>
    public static void BeginMode(this Camera2D camera) => Raylib.BeginMode2D(camera);
    
    /// <summary>
    /// Ends 2D mode with custom camera
    /// </summary>
    /// <param name="camera"></param>
    public static void EndMode(this Camera2D camera) => Raylib.EndMode2D();
    
    /// <summary>
    /// Get camera 2d transform matrix
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Matrix4x4 GetMatrix(this Camera2D camera)
        => Raylib.GetCameraMatrix2D(camera);
    
    /// <summary>
    /// Get the world space position for a 2d camera screen space position
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Vector2 GetScreenToWorld(this Camera2D camera, Vector2 position) =>
        Raylib.GetScreenToWorld2D(position, camera);
    
    /// <summary>
    /// Get the screen space position for a 2d camera world space position
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Vector2 GetWorldToScreen(this Camera2D camera, Vector2 position) =>
        Raylib.GetWorldToScreen2D(position, camera);
}