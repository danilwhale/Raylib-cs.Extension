namespace Raylib_cs.Extensions;

public static partial class Texture2DEx
{
    /// <summary>
    /// Set texture and rectangle to be used on shapes drawing
    /// </summary>
    public static void SetShapesTexture(this Texture2D texture, Rectangle source) =>
        Raylib.SetShapesTexture(texture, source);
}