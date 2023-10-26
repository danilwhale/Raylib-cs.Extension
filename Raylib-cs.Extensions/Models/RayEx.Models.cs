using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class RayEx
{
    /// <summary>
    /// Draw a ray line
    /// </summary>
    public static void Draw(this Ray ray, Color color)
        => color.DrawRay(ray);
    
    /// <summary>
    /// Get collision info between ray and sphere
    /// </summary>
    public static RayCollision GetRayCollisionSphere(this Ray ray, Vector3 center, float radius)
        => Raylib.GetRayCollisionSphere(ray, center, radius);
    
    /// <summary>
    /// Get collision info between ray and box
    /// </summary>
    public static RayCollision GetRayCollisionBox(this Ray ray, BoundingBox box)
        => Raylib.GetRayCollisionBox(ray, box);
    
    /// <summary>
    /// Get collision info between ray and mesh
    /// </summary>
    public static RayCollision GetRayCollisionMesh(this Ray ray, Mesh mesh, Matrix4x4 transform, bool transposeTransform = true)
        => Raylib.GetRayCollisionMesh(ray, mesh, transposeTransform ? Matrix4x4.Transpose(transform) : transform);
    
    /// <summary>
    /// Get collision info between ray and triangle
    /// </summary>
    public static RayCollision GetRayCollisionTriangle(this Ray ray, Vector3 v1, Vector3 v2, Vector3 v3)
        => Raylib.GetRayCollisionTriangle(ray, v1, v2, v3);
    
    /// <summary>
    /// Get collision info between ray and quad
    /// </summary>
    public static RayCollision GetRayCollisionQuad(this Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
        => Raylib.GetRayCollisionQuad(ray, p1, p2, p3, p4);
}