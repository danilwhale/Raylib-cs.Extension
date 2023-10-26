using System.Runtime.InteropServices;

namespace Raylib_cs.Extensions;

public static partial class MaterialEx
{
    // temporary fix for #206 (https://github.com/ChrisDill/Raylib-cs/issues/206) >>>
    [DllImport(Raylib.nativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern CBool IsMaterialReady(Material material);
    // <<<
    
    public static bool IsReady(this Material material) => IsMaterialReady(material);
    public static void Unload(this Material material) => Raylib.UnloadMaterial(material);

    public static void SetTexture(this ref Material material, MaterialMapIndex mapType, Texture2D texture)
        => Raylib.SetMaterialTexture(ref material, mapType, texture);
    
}