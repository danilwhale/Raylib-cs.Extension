using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class BoundingBoxEx
{
    /// <summary>
    /// Draw bounding box (wires)
    /// </summary>
    /// <param name="box"></param>
    /// <param name="color"></param>
    public static void Draw(this BoundingBox box, Color color)
        => Raylib.DrawBoundingBox(box, color);
    
    /// <summary>
    /// Check collision between two bounding boxes
    /// </summary>
    /// <param name="box1"></param>
    /// <param name="box2"></param>
    /// <returns></returns>
    public static bool CheckCollisionBox(this BoundingBox box1, BoundingBox box2)
        => Raylib.CheckCollisionBoxes(box1, box2);
    
    /// <summary>
    /// Check collision between box and sphere
    /// </summary>
    /// <param name="box"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    public static bool CheckCollisionSphere(this BoundingBox box, Vector3 center, float radius)
        => Raylib.CheckCollisionBoxSphere(box, center, radius);
}