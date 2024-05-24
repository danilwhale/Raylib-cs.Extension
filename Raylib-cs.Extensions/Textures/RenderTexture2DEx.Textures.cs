namespace Raylib_cs.Extensions;

public static partial class RenderTexture2DEx
{
    /// <summary>
    ///     Check if a render texture is ready
    /// </summary>
    public static bool IsReady(this RenderTexture2D target)
    {
        return Raylib.IsRenderTextureReady(target);
    }

    /// <summary>
    ///     Unload render texture from GPU memory (VRAM)
    /// </summary>
    public static void Unload(this RenderTexture2D target)
    {
        Raylib.UnloadRenderTexture(target);
    }
}