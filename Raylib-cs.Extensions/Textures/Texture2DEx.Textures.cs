using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class Texture2DEx
{
    /// <summary>
    /// Load image from GPU texture data
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static Image LoadImage(this Texture2D texture) => Raylib.LoadImageFromTexture(texture);
    
    /// <summary>
    /// Check if a texture is ready
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static bool IsReady(this Texture2D texture) => Raylib.IsTextureReady(texture);
    
    /// <summary>
    /// Unload texture from GPU memory (VRAM)
    /// </summary>
    /// <param name="texture"></param>
    public static void Unload(this Texture2D texture) => Raylib.UnloadTexture(texture);

    
    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="pixels"></param>
    /// <typeparam name="T"></typeparam>
    public static void Update<T>(this Texture2D texture, ReadOnlySpan<T> pixels) where T : unmanaged
        => Raylib.UpdateTexture(texture, pixels);
    
    /// <summary>
    /// Update GPU texture rectangle with new data
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="area"></param>
    /// <param name="pixels"></param>
    /// <typeparam name="T"></typeparam>
    public static void Update<T>(this Texture2D texture, Rectangle area, ReadOnlySpan<T> pixels) where T : unmanaged
        => Raylib.UpdateTextureRec(texture, area, pixels);
    
    /// <summary>
    /// Generate GPU mipmaps for a texture
    /// </summary>
    /// <param name="texture"></param>
    public static unsafe void GenerateMipmaps(this ref Texture2D texture)
    { fixed (Texture2D* ptr = &texture) Raylib.GenTextureMipmaps(ptr); }
    
    /// <summary>
    /// Set texture scaling filter mode
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="filter"></param>
    public static void SetFilter(this Texture2D texture, TextureFilter filter)
        => Raylib.SetTextureFilter(texture, filter);
    
    /// <summary>
    /// Set texture wrapping mode
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="wrap"></param>
    public static void SetWrap(this Texture2D texture, TextureWrap wrap)
        => Raylib.SetTextureWrap(texture, wrap);

    
    /// <summary>
    /// Draw a Texture2D
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="tint"></param>
    public static void Draw(this Texture2D texture, int x, int y, Color tint)
        => Raylib.DrawTexture(texture, x, y, tint);
    
    /// <summary>
    /// Draw a Texture2D with position defined as Vector2
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="position"></param>
    /// <param name="tint"></param>
    public static void Draw(this Texture2D texture, Vector2 position, Color tint)
        => Raylib.DrawTextureV(texture, position, tint);
    
    /// <summary>
    /// Draw a Texture2D with extended parameters
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="scale"></param>
    /// <param name="tint"></param>
    public static void Draw(this Texture2D texture, Vector2 position, float rotation, float scale, Color tint)
        => Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
    
    /// <summary>
    /// Draw a part of a texture defined by a rectangle
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="source"></param>
    /// <param name="position"></param>
    /// <param name="tint"></param>
    public static void Draw(this Texture2D texture, Rectangle source, Vector2 position, Color tint)
        => Raylib.DrawTextureRec(texture, source, position, tint);
    
    /// <summary>
    /// Draw a part of a texture defined by a rectangle with 'pro' parameters
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="source"></param>
    /// <param name="dest"></param>
    /// <param name="origin"></param>
    /// <param name="rotation"></param>
    /// <param name="tint"></param>
    public static void Draw(this Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint)
        => Raylib.DrawTexturePro(texture, source, dest, origin, rotation, tint);
    
    /// <summary>
    /// Draws a texture (or part of it) that stretches or shrinks nicely
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="nPatchInfo"></param>
    /// <param name="dest"></param>
    /// <param name="origin"></param>
    /// <param name="rotation"></param>
    /// <param name="tint"></param>
    public static void Draw(this Texture2D texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint)
        => Raylib.DrawTextureNPatch(texture, nPatchInfo, dest, origin, rotation, tint);
}