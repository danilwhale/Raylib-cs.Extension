using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class BoundingBoxEx
{
    public static void Draw(this BoundingBox box, Color color)
        => Raylib.DrawBoundingBox(box, color);

    public static bool CheckCollisionBox(this BoundingBox box1, BoundingBox box2)
        => Raylib.CheckCollisionBoxes(box1, box2);

    public static bool CheckCollisionSphere(this BoundingBox box, Vector3 center, float radius)
        => Raylib.CheckCollisionBoxSphere(box, center, radius);
}