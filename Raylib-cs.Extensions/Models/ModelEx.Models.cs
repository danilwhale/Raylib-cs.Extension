using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ModelEx
{
    /// <summary>
    /// Check if a model is ready
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static bool IsReady(this Model model) => Raylib.IsModelReady(model);
    
    /// <summary>
    /// Unload model (including meshes) from memory (RAM and/or VRAM)
    /// </summary>
    /// <param name="model"></param>
    public static void Unload(this Model model) => Raylib.UnloadModel(model);

    
    /// <summary>
    /// Compute model bounding box limits (considers all meshes)
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static BoundingBox GetBoundingBox(this Model model) 
        => Raylib.GetModelBoundingBox(model);

    
    /// <summary>
    /// Draw a model (with texture if set)
    /// </summary>
    /// <param name="model"></param>
    /// <param name="position"></param>
    /// <param name="scale"></param>
    /// <param name="tint"></param>
    public static void Draw(this Model model, Vector3 position, float scale, Color tint)
        => Raylib.DrawModel(model, position, scale, tint);
    
    /// <summary>
    /// Draw a model with extended parameters
    /// </summary>
    /// <param name="model"></param>
    /// <param name="position"></param>
    /// <param name="rotationAxis"></param>
    /// <param name="rotationAngle"></param>
    /// <param name="scale"></param>
    /// <param name="tint"></param>
    public static void Draw(this Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
        => Raylib.DrawModelEx(model, position, rotationAxis, rotationAngle, scale, tint);
    
    /// <summary>
    /// Draw a model wires (with texture if set)
    /// </summary>
    /// <param name="model"></param>
    /// <param name="position"></param>
    /// <param name="scale"></param>
    /// <param name="tint"></param>
    public static void DrawWires(this Model model, Vector3 position, float scale, Color tint)
        => Raylib.DrawModelWires(model, position, scale, tint);
    
    /// <summary>
    /// Draw a model wires (with texture if set) with extended parameters
    /// </summary>
    /// <param name="model"></param>
    /// <param name="position"></param>
    /// <param name="rotationAxis"></param>
    /// <param name="rotationAngle"></param>
    /// <param name="scale"></param>
    /// <param name="tint"></param>
    public static void DrawWires(this Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
        => Raylib.DrawModelWiresEx(model, position, rotationAxis, rotationAngle, scale, tint);

    
    /// <summary>
    /// Set material for a mesh
    /// </summary>
    /// <param name="model"></param>
    /// <param name="meshId"></param>
    /// <param name="materialId"></param>
    public static void SetMeshMaterial(this ref Model model, int meshId, int materialId)
        => Raylib.SetModelMeshMaterial(ref model, meshId, materialId);

    
    /// <summary>
    /// Update model animation pose
    /// </summary>
    /// <param name="model"></param>
    /// <param name="animation"></param>
    /// <param name="frame"></param>
    public static void UpdateAnimation(this Model model, ModelAnimation animation, int frame)
        => Raylib.UpdateModelAnimation(model, animation, frame);
    
    /// <summary>
    /// Check model animation skeleton match
    /// </summary>
    /// <param name="model"></param>
    /// <param name="animation"></param>
    public static void IsAnimationValid(this Model model, ModelAnimation animation)
        => Raylib.IsModelAnimationValid(model, animation);
}