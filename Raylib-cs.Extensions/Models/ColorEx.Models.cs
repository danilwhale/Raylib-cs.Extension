using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    public static void DrawLine3D(this Color color, Vector3 start, Vector3 end)
        => Raylib.DrawLine3D(start, end, color);

    public static void DrawPoint3D(this Color color, Vector3 point)
        => Raylib.DrawPoint3D(point, color);

    public static void DrawCircle3D(this Color color, Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle)
        => Raylib.DrawCircle3D(center, radius, rotationAxis, rotationAngle, color);

    public static void DrawTriangle3D(this Color color, Vector3 v1, Vector3 v2, Vector3 v3)
        => Raylib.DrawTriangle3D(v1, v2, v3, color);

    public static void DrawTriangleStrip3D(this Color color, params Vector3[] points)
        => Raylib.DrawTriangleStrip3D(points, points.Length, color);

    public static void DrawCube(this Color color, Vector3 position, float width, float height, float length)
        => Raylib.DrawCube(position, width, height, length, color);

    public static void DrawCube(this Color color, Vector3 position, Vector3 size)
        => Raylib.DrawCubeV(position, size, color);
    
    public static void DrawCubeWires(this Color color, Vector3 position, float width, float height, float length)
        => Raylib.DrawCubeWires(position, width, height, length, color);

    public static void DrawCubeWires(this Color color, Vector3 position, Vector3 size)
        => Raylib.DrawCubeWiresV(position, size, color);

    public static void DrawSphere(this Color color, Vector3 center, float radius)
        => Raylib.DrawSphere(center, radius, color);

    public static void DrawSphere(this Color color, Vector3 center, float radius, int rings, int slices)
        => Raylib.DrawSphereEx(center, radius, rings, slices, color);
    
    public static void DrawSphereWires(this Color color, Vector3 center, float radius, int rings, int slices)
        => Raylib.DrawSphereWires(center, radius, rings, slices, color);

    public static void DrawCylinder(this Color color, Vector3 position, float radiusTop, float radiusBottom, float height, int slices)
        => Raylib.DrawCylinder(position, radiusTop, radiusBottom, height, slices, color);

    public static void DrawCylinder(this Color color, Vector3 start, Vector3 end, float startRadius, float endRadius, int sides)
        => Raylib.DrawCylinderEx(start, end, startRadius, endRadius, sides, color);
    
    public static void DrawCylinderWires(this Color color, Vector3 position, float radiusTop, float radiusBottom, float height, int slices)
        => Raylib.DrawCylinderWires(position, radiusTop, radiusBottom, height, slices, color);

    public static void DrawCylinderWires(this Color color, Vector3 start, Vector3 end, float startRadius, float endRadius, int sides)
        => Raylib.DrawCylinderWiresEx(start, end, startRadius, endRadius, sides, color);

    public static void DrawCapsule(this Color color, Vector3 start, Vector3 end, float radius, int slices, int rings)
        => Raylib.DrawCapsule(start, end, radius, slices, rings, color);
    
    public static void DrawCapsuleWires(this Color color, Vector3 start, Vector3 end, float radius, int slices, int rings)
        => Raylib.DrawCapsuleWires(start, end, radius, slices, rings, color);

    public static void DrawPlane(this Color color, Vector3 center, Vector2 size)
        => Raylib.DrawPlane(center, size, color);

    public static void DrawRay(this Color color, Ray ray)
        => Raylib.DrawRay(ray, color);

    public static void DrawBoundingBox(this Color color, BoundingBox box)
        => Raylib.DrawBoundingBox(box, color);
}