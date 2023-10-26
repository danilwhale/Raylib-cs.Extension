using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    /// <param name="tint"></param>
    /// <param name="text"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="fontSize"></param>
    public static void DrawText(this Color tint, string text, int x, int y, int fontSize)
        => Raylib.DrawText(text, x, y, fontSize, tint);
    
    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    /// <param name="tint"></param>
    /// <param name="font"></param>
    /// <param name="text"></param>
    /// <param name="position"></param>
    /// <param name="fontSize"></param>
    /// <param name="spacing"></param>
    public static void DrawText(this Color tint, Font font, string text, Vector2 position, float fontSize, float spacing)
        => font.DrawText(text, position, fontSize, spacing, tint);
    
    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    /// <param name="tint"></param>
    /// <param name="font"></param>
    /// <param name="text"></param>
    /// <param name="position"></param>
    /// <param name="origin"></param>
    /// <param name="rotation"></param>
    /// <param name="fontSize"></param>
    /// <param name="spacing"></param>
    public static void DrawText(this Color tint, Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing)
        => font.DrawText(text, position, origin, rotation, fontSize, spacing, tint);
    
    /// <summary>
    /// Draw one character (codepoint)
    /// </summary>
    /// <param name="tint"></param>
    /// <param name="font"></param>
    /// <param name="codepoint"></param>
    /// <param name="position"></param>
    /// <param name="fontSize"></param>
    public static void DrawCodepoint(this Color tint, Font font, char codepoint, Vector2 position, float fontSize)
        => font.DrawCodepoint(codepoint, position, fontSize, tint);
    
    /// <summary>
    /// Draw multiple character (codepoint)
    /// </summary>
    /// <param name="tint"></param>
    /// <param name="font"></param>
    /// <param name="codepoints"></param>
    /// <param name="position"></param>
    /// <param name="fontSize"></param>
    /// <param name="spacing"></param>
    public static void DrawCodepoints(this Color tint, Font font, char[] codepoints, Vector2 position, float fontSize, float spacing)
        => font.DrawCodepoints(codepoints, position, fontSize, spacing, tint);
}