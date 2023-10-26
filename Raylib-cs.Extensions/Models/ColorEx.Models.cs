using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    /// <summary>
    /// Draw a line in 3D world space
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public static void DrawLine3D(this Color color, Vector3 start, Vector3 end)
        => Raylib.DrawLine3D(start, end, color);
    
    /// <summary>
    /// Draw a point in 3D space, actually a small line
    /// </summary>
    /// <param name="color"></param>
    /// <param name="point"></param>
    public static void DrawPoint3D(this Color color, Vector3 point)
        => Raylib.DrawPoint3D(point, color);
    
    /// <summary>
    /// Draw a circle in 3D world space
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="rotationAxis"></param>
    /// <param name="rotationAngle"></param>
    public static void DrawCircle3D(this Color color, Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle)
        => Raylib.DrawCircle3D(center, radius, rotationAxis, rotationAngle, color);
    
    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="v3"></param>
    public static void DrawTriangle3D(this Color color, Vector3 v1, Vector3 v2, Vector3 v3)
        => Raylib.DrawTriangle3D(v1, v2, v3, color);
    
    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    /// <param name="color"></param>
    /// <param name="points"></param>
    public static void DrawTriangleStrip3D(this Color color, params Vector3[] points)
        => Raylib.DrawTriangleStrip3D(points, points.Length, color);
    
    /// <summary>
    /// Draw cube
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="length"></param>
    public static void DrawCube(this Color color, Vector3 position, float width, float height, float length)
        => Raylib.DrawCube(position, width, height, length, color);
    
    /// <summary>
    /// Draw cube (Vector version)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    /// <param name="size"></param>
    public static void DrawCube(this Color color, Vector3 position, Vector3 size)
        => Raylib.DrawCubeV(position, size, color);
    
    /// <summary>
    /// Draw cube wires
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="length"></param>
    public static void DrawCubeWires(this Color color, Vector3 position, float width, float height, float length)
        => Raylib.DrawCubeWires(position, width, height, length, color);
    
    /// <summary>
    /// Draw cube wires (Vector version)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    /// <param name="size"></param>
    public static void DrawCubeWires(this Color color, Vector3 position, Vector3 size)
        => Raylib.DrawCubeWiresV(position, size, color);
    
    /// <summary>
    /// Draw sphere
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    public static void DrawSphere(this Color color, Vector3 center, float radius)
        => Raylib.DrawSphere(center, radius, color);
    
    /// <summary>
    /// Draw sphere with extended parameters
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="rings"></param>
    /// <param name="slices"></param>
    public static void DrawSphere(this Color color, Vector3 center, float radius, int rings, int slices)
        => Raylib.DrawSphereEx(center, radius, rings, slices, color);
    
    /// <summary>
    /// Draw sphere wires
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="rings"></param>
    /// <param name="slices"></param>
    public static void DrawSphereWires(this Color color, Vector3 center, float radius, int rings, int slices)
        => Raylib.DrawSphereWires(center, radius, rings, slices, color);
    
    /// <summary>
    /// Draw a cylinder/cone
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    /// <param name="radiusTop"></param>
    /// <param name="radiusBottom"></param>
    /// <param name="height"></param>
    /// <param name="slices"></param>
    public static void DrawCylinder(this Color color, Vector3 position, float radiusTop, float radiusBottom, float height, int slices)
        => Raylib.DrawCylinder(position, radiusTop, radiusBottom, height, slices, color);
    
    /// <summary>
    /// Draw a cylinder with base at startPos and top at endPos
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="startRadius"></param>
    /// <param name="endRadius"></param>
    /// <param name="sides"></param>
    public static void DrawCylinder(this Color color, Vector3 start, Vector3 end, float startRadius, float endRadius, int sides)
        => Raylib.DrawCylinderEx(start, end, startRadius, endRadius, sides, color);
    
    /// <summary>
    /// Draw a cylinder/cone wires
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    /// <param name="radiusTop"></param>
    /// <param name="radiusBottom"></param>
    /// <param name="height"></param>
    /// <param name="slices"></param>
    public static void DrawCylinderWires(this Color color, Vector3 position, float radiusTop, float radiusBottom, float height, int slices)
        => Raylib.DrawCylinderWires(position, radiusTop, radiusBottom, height, slices, color);
    
    /// <summary>
    /// Draw a cylinder wires with base at startPos and top at endPos
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="startRadius"></param>
    /// <param name="endRadius"></param>
    /// <param name="sides"></param>
    public static void DrawCylinderWires(this Color color, Vector3 start, Vector3 end, float startRadius, float endRadius, int sides)
        => Raylib.DrawCylinderWiresEx(start, end, startRadius, endRadius, sides, color);
    
    /// <summary>
    /// Draw a capsule with the center of its sphere caps at startPos and endPos
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="radius"></param>
    /// <param name="slices"></param>
    /// <param name="rings"></param>
    public static void DrawCapsule(this Color color, Vector3 start, Vector3 end, float radius, int slices, int rings)
        => Raylib.DrawCapsule(start, end, radius, slices, rings, color);
    
    /// <summary>
    /// Draw capsule wireframe with the center of its sphere caps at startPos and endPos
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="radius"></param>
    /// <param name="slices"></param>
    /// <param name="rings"></param>
    public static void DrawCapsuleWires(this Color color, Vector3 start, Vector3 end, float radius, int slices, int rings)
        => Raylib.DrawCapsuleWires(start, end, radius, slices, rings, color);
    
    /// <summary>
    /// Draw a plane XZ
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="size"></param>
    public static void DrawPlane(this Color color, Vector3 center, Vector2 size)
        => Raylib.DrawPlane(center, size, color);
    
    /// <summary>
    /// Draw a ray line
    /// </summary>
    /// <param name="color"></param>
    /// <param name="ray"></param>
    public static void DrawRay(this Color color, Ray ray)
        => Raylib.DrawRay(ray, color);
    
    /// <summary>
    /// Draw bounding box (wires)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="box"></param>
    public static void DrawBoundingBox(this Color color, BoundingBox box)
        => Raylib.DrawBoundingBox(box, color);
}