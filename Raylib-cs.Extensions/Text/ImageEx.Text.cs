namespace Raylib_cs.Extensions;

public static partial class ImageEx
{
    /// <summary>
    /// Load font from Image (XNA style)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="key"></param>
    /// <param name="firstChar"></param>
    /// <returns></returns>
    public static Font LoadFont(this Image image, Color key, char firstChar) => Raylib.LoadFontFromImage(image, key, firstChar);
}