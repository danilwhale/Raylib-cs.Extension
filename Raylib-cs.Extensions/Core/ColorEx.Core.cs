namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    /// <summary>
    /// Set background color (framebuffer clear color)
    /// </summary>
    /// <param name="color"></param>
    public static void ClearBackground(this Color color) => Raylib.ClearBackground(color);
    
}