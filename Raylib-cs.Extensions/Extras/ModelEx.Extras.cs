namespace Raylib_cs.Extensions;

public static partial class ModelEx
{
    public static Material GetMaterial(this ref Model model, int materialIndex)
    {
        return Raylib.GetMaterial(ref model, materialIndex);
    }

    public static MaterialMap GetMaterialMap(this ref Model model, int materialIndex, MaterialMapIndex map)
    {
        return model.GetMaterial(materialIndex).GetMap(map);
    }


    public static Texture2D GetMaterialTexture(this ref Model model, int materialIndex, MaterialMapIndex map)
    {
        return model.GetMaterial(materialIndex).GetTexture(map);
    }

    public static Color GetMaterialColor(this ref Model model, int materialIndex, MaterialMapIndex map)
    {
        return model.GetMaterial(materialIndex).GetColor(map);
    }

    public static float GetMaterialValue(this ref Model model, int materialIndex, MaterialMapIndex map)
    {
        return model.GetMaterial(materialIndex).GetValue(map);
    }

    public static Shader GetMaterialShader(this ref Model model, int materialIndex)
    {
        return model.GetMaterial(materialIndex).Shader;
    }


    public static void SetMaterialTexture(this ref Model model, int materialIndex, MaterialMapIndex map,
        Texture2D texture)
    {
        var material = model.GetMaterial(materialIndex);
        material.SetTexture(map, texture);
    }

    public static void SetMaterialColor(this ref Model model, int materialIndex, MaterialMapIndex map, Color color)
    {
        var material = model.GetMaterial(materialIndex);
        material.SetColor(map, color);
    }

    public static void SetMaterialValue(this ref Model model, int materialIndex, MaterialMapIndex map, float value)
    {
        var material = model.GetMaterial(materialIndex);
        material.SetValue(map, value);
    }

    public static void SetMaterialShader(this ref Model model, int materialIndex, Shader shader)
    {
        var material = model.GetMaterial(materialIndex);
        material.Shader = shader;
    }
}