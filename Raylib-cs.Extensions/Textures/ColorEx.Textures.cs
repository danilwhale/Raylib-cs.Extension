using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    /// <summary>
    /// Get hexadecimal value for a Color
    /// </summary>
    public static int ToInt(this Color color) => Raylib.ColorToInt(color);
    
    /// <summary>
    /// Get Color normalized as float [0..1]
    /// </summary>
    public static Vector4 Normalize(this Color color) => Raylib.ColorNormalize(color);
    
    /// <summary>
    /// Get HSV values for a Color, hue [0..360], saturation/value [0..1]
    /// </summary>
    public static Vector3 ToHsv(this Color color) => Raylib.ColorToHSV(color);
    
    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color Fade(this Color color, float alpha) => Raylib.Fade(color, alpha);
    
    /// <summary>
    /// Get color multiplied with another color
    /// </summary>
    public static Color Tint(this Color color, Color tint) => Raylib.ColorTint(color, tint);
    
    /// <summary>
    /// Get color with brightness correction, brightness factor goes from -1.0f to 1.0f
    /// </summary>
    public static Color Brightness(this Color color, float factor) => Raylib.ColorBrightness(color, factor);
    
    /// <summary>
    /// Get color with contrast correction, contrast values between -1.0f and 1.0f
    /// </summary>
    public static Color Contrast(this Color color, float contrast) => Raylib.ColorContrast(color, contrast);
    
    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color Alpha(this Color color, float alpha) => Raylib.ColorAlpha(color, alpha);
    
    /// <summary>
    /// Get src alpha-blended into dst color with tint
    /// </summary>
    public static Color AlphaBlend(this Color dst, Color src, Color tint) => Raylib.ColorAlphaBlend(dst, src, tint);
    
    /// <summary>
    /// Set color formatted into destination pixel pointer
    /// </summary>
    public static unsafe void SetPixel<T>(this Color color, ReadOnlySpan<T> dst, PixelFormat format) where T : unmanaged
    { fixed (T* ptr = dst) Raylib.SetPixelColor(ptr, color, format); }
}