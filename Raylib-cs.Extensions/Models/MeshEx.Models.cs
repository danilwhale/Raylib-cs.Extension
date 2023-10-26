using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class MeshEx
{
    public static void Upload(this ref Mesh mesh, bool dynamic = false)
        => Raylib.UploadMesh(ref mesh, dynamic);

    public static unsafe void UpdateBuffer<T>(this Mesh mesh, int index, ReadOnlySpan<T> data, int offset) where T : unmanaged
    { fixed (T* ptr = data) Raylib.UpdateMeshBuffer(mesh, index, ptr, data.Length, offset); }

    public static unsafe void Unload(this Mesh mesh)
        => Raylib.UnloadMesh(&mesh);

    public static void Draw(this Mesh mesh, Material material, Matrix4x4 transform, bool transposeTransform = true)
        => Raylib.DrawMesh(mesh, material, transposeTransform ? Matrix4x4.Transpose(transform) : transform);

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

    public static void Export(this Mesh mesh, string path)
        => Raylib.ExportMesh(mesh, path);

    public static BoundingBox GetBoundingBox(this Mesh mesh)
        => Raylib.GetMeshBoundingBox(mesh);

    public static void GenerateTangents(this ref Mesh mesh)
        => Raylib.GenMeshTangents(ref mesh);
}