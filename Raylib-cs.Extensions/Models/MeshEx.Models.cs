using System.Numerics;

namespace Raylib_cs.Extensions;

public static class MeshEx
{
    /// <summary>
    ///     Load model from generated mesh (default material)
    /// </summary>
    public static Model LoadModel(this Mesh mesh)
    {
        return Raylib.LoadModelFromMesh(mesh);
    }

    /// <summary>
    ///     Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    public static void Upload(this ref Mesh mesh, bool dynamic = false)
    {
        Raylib.UploadMesh(ref mesh, dynamic);
    }

    /// <summary>
    ///     Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    public static unsafe void UpdateBuffer<T>(this Mesh mesh, int index, ReadOnlySpan<T> data, int offset)
        where T : unmanaged
    {
        fixed (T* ptr = data)
        {
            Raylib.UpdateMeshBuffer(mesh, index, ptr, data.Length, offset);
        }
    }

    /// <summary>
    ///     Unload mesh data from CPU and GPU
    /// </summary>
    public static unsafe void Unload(this Mesh mesh)
    {
        Raylib.UnloadMesh(&mesh);
    }

    /// <summary>
    ///     Draw a 3d mesh with material and transform
    /// </summary>
    public static void Draw(this Mesh mesh, Material material, Matrix4x4 transform, bool transposeTransform = true)
    {
        Raylib.DrawMesh(mesh, material, transposeTransform ? Matrix4x4.Transpose(transform) : transform);
    }

    /// <summary>
    ///     Draw multiple mesh instances with material and different transforms
    /// </summary>
    public static void DrawInstanced(this Mesh mesh, Material material, Matrix4x4[] transforms,
        bool transposeTransforms = true)
    {
        if (transposeTransforms)
            for (var i = 0; i < transforms.Length; i++)
                transforms[i] = Matrix4x4.Transpose(transforms[i]);

        Raylib.DrawMeshInstanced(mesh, material, transforms, transforms.Length);
    }

    /// <summary>
    ///     Export mesh data to file, returns true on success
    /// </summary>
    public static bool Export(this Mesh mesh, string path)
    {
        return Raylib.ExportMesh(mesh, path);
    }

    /// <summary>
    ///     Compute mesh bounding box limits
    /// </summary>
    public static BoundingBox GetBoundingBox(this Mesh mesh)
    {
        return Raylib.GetMeshBoundingBox(mesh);
    }

    /// <summary>
    ///     Compute mesh tangents
    /// </summary>
    public static void GenerateTangents(this ref Mesh mesh)
    {
        Raylib.GenMeshTangents(ref mesh);
    }
}