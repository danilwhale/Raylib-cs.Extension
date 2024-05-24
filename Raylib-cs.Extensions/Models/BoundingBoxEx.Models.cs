using System.Numerics;

namespace Raylib_cs.Extensions;

public static class BoundingBoxEx
{
    /// <summary>
    ///     Draw bounding box (wires)
    /// </summary>
    public static void Draw(this BoundingBox box, Color color)
    {
        Raylib.DrawBoundingBox(box, color);
    }

    /// <summary>
    ///     Check collision between two bounding boxes
    /// </summary>
    public static bool CheckCollisionBox(this BoundingBox box1, BoundingBox box2)
    {
        return Raylib.CheckCollisionBoxes(box1, box2);
    }

    /// <summary>
    ///     Check collision between box and sphere
    /// </summary>
    public static bool CheckCollisionSphere(this BoundingBox box, Vector3 center, float radius)
    {
        return Raylib.CheckCollisionBoxSphere(box, center, radius);
    }
}