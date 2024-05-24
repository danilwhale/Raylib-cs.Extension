using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class Camera3DEx
{
    /// <summary>
    ///     Draw a billboard texture
    /// </summary>
    public static void DrawBillboard(this Camera3D camera, Texture2D texture, Vector3 position, float size, Color tint)
    {
        texture.DrawBillboard(camera, position, size, tint);
    }

    /// <summary>
    ///     Draw a billboard texture defined by source
    /// </summary>
    public static void DrawBillboard(this Camera3D camera, Texture2D texture, Rectangle source, Vector3 position,
        Vector2 size, Color tint)
    {
        texture.DrawBillboard(camera, source, position, size, tint);
    }

    /// <summary>
    ///     Draw a billboard texture defined by source and rotation
    /// </summary>
    public static void DrawBillboard(this Camera3D camera, Texture2D texture, Rectangle source, Vector3 position,
        Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint)
    {
        texture.DrawBillboard(camera, source, position, up, size, origin, rotation, tint);
    }
}