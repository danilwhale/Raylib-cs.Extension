using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class Texture2DEx
{
    /// <summary>
    /// Draw a billboard texture
    /// </summary>
    public static void DrawBillboard(this Texture2D texture, Camera3D camera, Vector3 position, float size, Color tint)
        => Raylib.DrawBillboard(camera, texture, position, size, tint);
    
    /// <summary>
    /// Draw a billboard texture defined by source
    /// </summary>
    public static void DrawBillboard(this Texture2D texture, Camera3D camera, Rectangle source, Vector3 position, Vector2 size, Color tint)
        => Raylib.DrawBillboardRec(camera, texture, source, position, size, tint);
    
    /// <summary>
    /// Draw a billboard texture defined by source and rotation
    /// </summary>
    public static void DrawBillboard(this Texture2D texture, Camera3D camera, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint)
        => Raylib.DrawBillboardPro(camera, texture, source, position, up, size, origin, rotation, tint);
}