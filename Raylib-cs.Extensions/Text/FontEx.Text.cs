using System.Numerics;

namespace Raylib_cs.Extensions;

public static class FontEx
{
    /// <summary>
    ///     Check if a font is ready
    /// </summary>
    public static bool IsReady(this Font font)
    {
        return Raylib.IsFontReady(font);
    }

    /// <summary>
    ///     Unload font from GPU memory (VRAM)
    /// </summary>
    public static void Unload(this Font font)
    {
        Raylib.UnloadFont(font);
    }

    /// <summary>
    ///     Export font as code file, returns true on success
    /// </summary>
    public static unsafe bool ExportAsCode(this Font font, string path)
    {
        using var buffer = new Utf8Buffer(path);
        bool value = Raylib.ExportFontAsCode(font, buffer.AsPointer());

        return value;
    }

    /// <summary>
    ///     Draw text using font and additional parameters
    /// </summary>
    public static void DrawText(this Font font, string text, Vector2 position, float fontSize, float spacing,
        Color tint)
    {
        Raylib.DrawTextEx(font, text, position, fontSize, spacing, tint);
    }

    /// <summary>
    ///     Draw text using Font and pro parameters (rotation)
    /// </summary>
    public static void DrawText(this Font font, string text, Vector2 position, Vector2 origin, float rotation,
        float fontSize, float spacing, Color tint)
    {
        Raylib.DrawTextPro(font, text, position, origin, rotation, fontSize, spacing, tint);
    }

    /// <summary>
    ///     Draw one character (codepoint)
    /// </summary>
    public static void DrawCodepoint(this Font font, char codepoint, Vector2 position, float fontSize, Color tint)
    {
        Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
    }

    /// <summary>
    ///     Draw multiple character (codepoint)
    /// </summary>
    public static unsafe void DrawCodepoints(this Font font, char[] codepoints, Vector2 position, float fontSize,
        float spacing, Color tint)
    {
        fixed (char* ptr = codepoints)
        {
            Raylib.DrawTextCodepoints(font, (int*)ptr, codepoints.Length, position, fontSize, spacing, tint);
        }
    }


    /// <summary>
    ///     Measure string size for Font
    /// </summary>
    public static Vector2 MeasureText(this Font font, string text, float fontSize, float spacing)
    {
        return Raylib.MeasureTextEx(font, text, fontSize, spacing);
    }

    /// <summary>
    ///     Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static int GetGlyphIndex(this Font font, char codepoint)
    {
        return Raylib.GetGlyphIndex(font, codepoint);
    }

    /// <summary>
    ///     Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static GlyphInfo GetGlyphInfo(this Font font, char codepoint)
    {
        return Raylib.GetGlyphInfo(font, codepoint);
    }

    /// <summary>
    ///     Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static Rectangle GetGlyphAtlasRect(this Font font, char codepoint)
    {
        return Raylib.GetGlyphAtlasRec(font, codepoint);
    }
}