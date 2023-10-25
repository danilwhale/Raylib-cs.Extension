using System.Numerics;

namespace Raylib_cs.Extension;

public static partial class Texture2DEx
{
    public static bool IsReady(this Texture2D texture) => Raylib.IsTextureReady(texture);
    public static void Unload(this Texture2D texture) => Raylib.UnloadTexture(texture);

    
    public static void Update<T>(this Texture2D texture, ReadOnlySpan<T> pixels) where T : unmanaged
        => Raylib.UpdateTexture(texture, pixels);

    public static void Update<T>(this Texture2D texture, Rectangle area, ReadOnlySpan<T> pixels) where T : unmanaged
        => Raylib.UpdateTextureRec(texture, area, pixels);

    public static unsafe void GenerateMipmaps(this ref Texture2D texture)
    { fixed (Texture2D* ptr = &texture) Raylib.GenTextureMipmaps(ptr); }

    public static void SetFilter(this Texture2D texture, TextureFilter filter)
        => Raylib.SetTextureFilter(texture, filter);

    public static void SetWrap(this Texture2D texture, TextureWrap wrap)
        => Raylib.SetTextureWrap(texture, wrap);


    public static void Draw(this Texture2D texture, int x, int y, Color tint)
        => Raylib.DrawTexture(texture, x, y, tint);

    public static void Draw(this Texture2D texture, Vector2 position, Color tint)
        => Raylib.DrawTextureV(texture, position, tint);

    public static void Draw(this Texture2D texture, Vector2 position, float rotation, float scale, Color tint)
        => Raylib.DrawTextureEx(texture, position, rotation, scale, tint);

    public static void Draw(this Texture2D texture, Rectangle source, Vector2 position, Color tint)
        => Raylib.DrawTextureRec(texture, source, position, tint);

    public static void Draw(this Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint)
        => Raylib.DrawTexturePro(texture, source, dest, origin, rotation, tint);

    public static void Draw(this Texture2D texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint)
        => Raylib.DrawTextureNPatch(texture, nPatchInfo, dest, origin, rotation, tint);
}