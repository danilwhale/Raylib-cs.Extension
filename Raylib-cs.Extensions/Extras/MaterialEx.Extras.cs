namespace Raylib_cs.Extensions;

public static partial class MaterialEx
{
    /// <summary>
    ///     Sets color for specified material map
    /// </summary>
    public static unsafe void SetColor(this Material material, MaterialMapIndex index, Color color)
    {
        material.Maps[(int)index].Color = color;
    }

    /// <summary>
    ///     Sets value for specified material map
    /// </summary>
    public static unsafe void SetValue(this Material material, MaterialMapIndex index, float value)
    {
        material.Maps[(int)index].Value = value;
    }

    /// <summary>
    ///     Gets texture of specified material map
    /// </summary>
    public static unsafe Texture2D GetTexture(this Material material, MaterialMapIndex index)
    {
        return material.Maps[(int)index].Texture;
    }

    /// <summary>
    ///     Gets color of specified material map
    /// </summary>
    public static unsafe Color GetColor(this Material material, MaterialMapIndex index)
    {
        return material.Maps[(int)index].Color;
    }

    /// <summary>
    ///     Gets value of specified material map
    /// </summary>
    public static unsafe float GetValue(this Material material, MaterialMapIndex index)
    {
        return material.Maps[(int)index].Value;
    }

    /// <summary>
    ///     Gets specified material map
    /// </summary>
    public static unsafe MaterialMap GetMap(this Material material, MaterialMapIndex index)
    {
        return material.Maps[(int)index];
    }
}