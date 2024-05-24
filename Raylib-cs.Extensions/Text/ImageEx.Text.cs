namespace Raylib_cs.Extensions;

public static partial class ImageEx
{
    /// <summary>
    ///     Load font from Image (XNA style)
    /// </summary>
    public static Font LoadFont(this Image image, Color key, char firstChar)
    {
        return Raylib.LoadFontFromImage(image, key, firstChar);
    }
}