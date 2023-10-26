namespace Raylib_cs.Extensions;

public static partial class RenderTexture2DEx
{
    /// <summary>
    /// Begin drawing to render texture
    /// </summary>
    /// <param name="target"></param>
    public static void BeginMode(this RenderTexture2D target) => Raylib.BeginTextureMode(target);
    
    /// <summary>
    /// Ends drawing to render texture
    /// </summary>
    /// <param name="target"></param>
    public static void EndMode(this RenderTexture2D target) => Raylib.EndTextureMode();
}