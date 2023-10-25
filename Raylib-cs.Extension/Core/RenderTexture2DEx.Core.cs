namespace Raylib_cs.Extension;

public static partial class RenderTexture2DEx
{
    public static void BeginMode(this RenderTexture2D target) => Raylib.BeginTextureMode(target);
    public static void EndMode(this RenderTexture2D target) => Raylib.EndTextureMode();
}