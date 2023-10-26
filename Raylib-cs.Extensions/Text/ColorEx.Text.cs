using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    public static void DrawText(this Color tint, string text, int x, int y, int fontSize)
        => Raylib.DrawText(text, x, y, fontSize, tint);
    
    public static void DrawText(this Color tint, Font font, string text, Vector2 position, float fontSize, float spacing)
        => font.DrawText(text, position, fontSize, spacing, tint);

    public static void DrawText(this Color tint, Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing)
        => font.DrawText(text, position, origin, rotation, fontSize, spacing, tint);

    public static void DrawCodepoint(this Color tint, Font font, char codepoint, Vector2 position, float fontSize)
        => font.DrawCodepoint(codepoint, position, fontSize, tint);

    public static void DrawCodepoints(this Color tint, Font font, char[] codepoints, Vector2 position, float fontSize, float spacing)
        => font.DrawCodepoints(codepoints, position, fontSize, spacing, tint);
}