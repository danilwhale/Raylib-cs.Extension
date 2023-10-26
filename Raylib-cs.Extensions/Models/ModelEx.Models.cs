using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ModelEx
{
    public static bool IsReady(this Model model) => Raylib.IsModelReady(model);
    public static void Unload(this Model model) => Raylib.UnloadModel(model);

    
    public static BoundingBox GetBoundingBox(this Model model) 
        => Raylib.GetModelBoundingBox(model);


    public static void Draw(this Model model, Vector3 position, float scale, Color tint)
        => Raylib.DrawModel(model, position, scale, tint);

    public static void Draw(this Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
        => Raylib.DrawModelEx(model, position, rotationAxis, rotationAngle, scale, tint);
    
    public static void DrawWires(this Model model, Vector3 position, float scale, Color tint)
        => Raylib.DrawModelWires(model, position, scale, tint);

    public static void DrawWires(this Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
        => Raylib.DrawModelWiresEx(model, position, rotationAxis, rotationAngle, scale, tint);


    public static void SetMeshMaterial(this ref Model model, int meshId, int materialId)
        => Raylib.SetModelMeshMaterial(ref model, meshId, materialId);


    public static void UpdateAnimation(this Model model, ModelAnimation animation, int frame)
        => Raylib.UpdateModelAnimation(model, animation, frame);

    public static void IsAnimationValid(this Model model, ModelAnimation animation)
        => Raylib.IsModelAnimationValid(model, animation);
}