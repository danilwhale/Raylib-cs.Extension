using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class MeshEx
{
    /// <summary>
    /// Load model from generated mesh (default material)
    /// </summary>
    /// <param name="mesh"></param>
    /// <returns></returns>
    public static Model LoadModel(this Mesh mesh) => Raylib.LoadModelFromMesh(mesh);
        
    /// <summary>
    /// Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="dynamic"></param>
    public static void Upload(this ref Mesh mesh, bool dynamic = false)
        => Raylib.UploadMesh(ref mesh, dynamic);
    
    /// <summary>
    /// Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="index"></param>
    /// <param name="data"></param>
    /// <param name="offset"></param>
    /// <typeparam name="T"></typeparam>
    public static unsafe void UpdateBuffer<T>(this Mesh mesh, int index, ReadOnlySpan<T> data, int offset) where T : unmanaged
    { fixed (T* ptr = data) Raylib.UpdateMeshBuffer(mesh, index, ptr, data.Length, offset); }
    
    /// <summary>
    /// Unload mesh data from CPU and GPU
    /// </summary>
    /// <param name="mesh"></param>
    public static unsafe void Unload(this Mesh mesh)
        => Raylib.UnloadMesh(&mesh);
    
    /// <summary>
    /// Draw a 3d mesh with material and transform
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="material"></param>
    /// <param name="transform"></param>
    /// <param name="transposeTransform"></param>
    public static void Draw(this Mesh mesh, Material material, Matrix4x4 transform, bool transposeTransform = true)
        => Raylib.DrawMesh(mesh, material, transposeTransform ? Matrix4x4.Transpose(transform) : transform);
    
    /// <summary>
    /// Draw multiple mesh instances with material and different transforms
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="material"></param>
    /// <param name="transforms"></param>
    /// <param name="transposeTransforms"></param>
    public static void DrawInstanced(this Mesh mesh, Material material, Matrix4x4[] transforms, bool transposeTransforms = true)
    {
        if (transposeTransforms)
        {
            for (int i = 0; i < transforms.Length; i++)
            {
                transforms[i] = Matrix4x4.Transpose(transforms[i]);
            }
        }
        
        Raylib.DrawMeshInstanced(mesh, material, transforms, transforms.Length);
    }
    
    /// <summary>
    /// Export mesh data to file, returns true on success
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="path"></param>
    public static bool Export(this Mesh mesh, string path)
        => Raylib.ExportMesh(mesh, path);
    
    /// <summary>
    /// Compute mesh bounding box limits
    /// </summary>
    /// <param name="mesh"></param>
    /// <returns></returns>
    public static BoundingBox GetBoundingBox(this Mesh mesh)
        => Raylib.GetMeshBoundingBox(mesh);
    
    /// <summary>
    /// Compute mesh tangents 
    /// </summary>
    /// <param name="mesh"></param>
    public static void GenerateTangents(this ref Mesh mesh)
        => Raylib.GenMeshTangents(ref mesh);
}