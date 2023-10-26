using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class FontEx
{
    public static bool IsReady(this Font font) => Raylib.IsFontReady(font);
    public static void Unload(this Font font) => Raylib.UnloadFont(font);

    public static void DrawText(this Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
        => Raylib.DrawTextEx(font, text, position, fontSize, spacing, tint);

    public static void DrawText(this Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
        => Raylib.DrawTextPro(font, text, position, origin, rotation, fontSize, spacing, tint);

    public static void DrawCodepoint(this Font font, char codepoint, Vector2 position, float fontSize, Color tint)
        => Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
    
    public static unsafe void DrawCodepoints(this Font font, char[] codepoints, Vector2 position, float fontSize, float spacing, Color tint)
    { fixed (char* ptr = codepoints) Raylib.DrawTextCodepoints(font, (int*)ptr, codepoints.Length, position, fontSize, spacing, tint);}


    public static Vector2 MeasureText(this Font font, string text, float fontSize, float spacing)
        => Raylib.MeasureTextEx(font, text, fontSize, spacing);

    public static int GetGlyphIndex(this Font font, char codepoint)
        => Raylib.GetGlyphIndex(font, codepoint);

    public static GlyphInfo GetGlyphInfo(this Font font, char codepoint)
        => Raylib.GetGlyphInfo(font, codepoint);

    public static Rectangle GetGlyphAtlasRect(this Font font, char codepoint)
        => Raylib.GetGlyphAtlasRec(font, codepoint);
}