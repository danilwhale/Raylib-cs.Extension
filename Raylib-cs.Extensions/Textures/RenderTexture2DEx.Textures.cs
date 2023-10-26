namespace Raylib_cs.Extensions;

public static partial class RenderTexture2DEx
{
    public static bool IsReady(this RenderTexture2D target) => Raylib.IsRenderTextureReady(target);
    public static void Unload(this RenderTexture2D target) => Raylib.UnloadRenderTexture(target);
    
    
}