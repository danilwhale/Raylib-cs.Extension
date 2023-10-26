using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class RayEx
{
    /// <summary>
    /// Draw a ray line
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="color"></param>
    public static void Draw(this Ray ray, Color color)
        => color.DrawRay(ray);
    
    /// <summary>
    /// Get collision info between ray and sphere
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    public static RayCollision GetRayCollisionSphere(this Ray ray, Vector3 center, float radius)
        => Raylib.GetRayCollisionSphere(ray, center, radius);
    
    /// <summary>
    /// Get collision info between ray and box
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="box"></param>
    /// <returns></returns>
    public static RayCollision GetRayCollisionBox(this Ray ray, BoundingBox box)
        => Raylib.GetRayCollisionBox(ray, box);
    
    /// <summary>
    /// Get collision info between ray and mesh
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="mesh"></param>
    /// <param name="transform"></param>
    /// <param name="transposeTransform"></param>
    /// <returns></returns>
    public static RayCollision GetRayCollisionMesh(this Ray ray, Mesh mesh, Matrix4x4 transform, bool transposeTransform = true)
        => Raylib.GetRayCollisionMesh(ray, mesh, transposeTransform ? Matrix4x4.Transpose(transform) : transform);
    
    /// <summary>
    /// Get collision info between ray and triangle
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="v3"></param>
    /// <returns></returns>
    public static RayCollision GetRayCollisionTriangle(this Ray ray, Vector3 v1, Vector3 v2, Vector3 v3)
        => Raylib.GetRayCollisionTriangle(ray, v1, v2, v3);
    
    /// <summary>
    /// Get collision info between ray and quad
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <returns></returns>
    public static RayCollision GetRayCollisionQuad(this Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
        => Raylib.GetRayCollisionQuad(ray, p1, p2, p3, p4);
}