namespace Raylib_cs.Extensions;

public static partial class MaterialEx
{
    /// <summary>
    /// Sets color for specified material map
    /// </summary>
    public static unsafe void SetColor(this Material material, MaterialMapIndex index, Color color)
        => material.maps[(int)index].color = color;
    
    /// <summary>
    /// Sets value for specified material map
    /// </summary>
    public static unsafe void SetValue(this Material material, MaterialMapIndex index, float value)
        => material.maps[(int)index].value = value;
    
    /// <summary>
    /// Gets texture of specified material map
    /// </summary>
    public static unsafe Texture2D GetTexture(this Material material, MaterialMapIndex index)
        => material.maps[(int)index].texture;
    
    /// <summary>
    /// Gets color of specified material map
    /// </summary>
    public static unsafe Color GetColor(this Material material, MaterialMapIndex index)
        => material.maps[(int)index].color;
    
    /// <summary>
    /// Gets value of specified material map
    /// </summary>
    public static unsafe float GetValue(this Material material, MaterialMapIndex index)
        => material.maps[(int)index].value;
    
    /// <summary>
    /// Gets specified material map
    /// </summary>
    public static unsafe MaterialMap GetMap(this Material material, MaterialMapIndex index)
        => material.maps[(int)index];
}