using System.Numerics;

namespace Raylib_cs.Extension;

public static partial class ColorEx
{
    public static int ToInt(this Color color) => Raylib.ColorToInt(color);
    public static Vector4 Normalize(this Color color) => Raylib.ColorNormalize(color);
    public static Vector3 ToHsv(this Color color) => Raylib.ColorToHSV(color);

    public static Color Fade(this Color color, float alpha) => Raylib.Fade(color, alpha);
    public static Color Tint(this Color color, Color tint) => Raylib.ColorTint(color, tint);
    public static Color Brightness(this Color color, float factor) => Raylib.ColorBrightness(color, factor);
    public static Color Contrast(this Color color, float contrast) => Raylib.ColorContrast(color, contrast);
    public static Color Alpha(this Color color, float alpha) => Raylib.ColorAlpha(color, alpha);
    public static Color AlphaBlend(this Color dst, Color src, Color tint) => Raylib.ColorAlphaBlend(dst, src, tint);
    
    public static unsafe void SetPixel<T>(this Color color, ReadOnlySpan<T> dst, PixelFormat format) where T : unmanaged
    { fixed (T* ptr = dst) Raylib.SetPixelColor(ptr, color, format); }
}