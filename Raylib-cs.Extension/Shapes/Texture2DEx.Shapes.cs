namespace Raylib_cs.Extension;

public static partial class Texture2DEx
{
    public static void SetShapesTexture(this Texture2D texture, Rectangle source) =>
        Raylib.SetShapesTexture(texture, source);
}