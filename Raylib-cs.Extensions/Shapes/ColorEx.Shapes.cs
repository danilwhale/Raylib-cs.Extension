using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    /// <summary>
    /// Draw a pixel
    /// </summary>
    /// <param name="color"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public static void DrawPixel(this Color color, int x, int y) => Raylib.DrawPixel(x, y, color);
    
    /// <summary>
    /// Draw a pixel (Vector version)   
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    public static void DrawPixel(this Color color, Vector2 position) => Raylib.DrawPixelV(position, color);
    
    /// <summary>
    /// Draw a line
    /// </summary>
    /// <param name="color"></param>
    /// <param name="startX"></param>
    /// <param name="startY"></param>
    /// <param name="endX"></param>
    /// <param name="endY"></param>
    public static void DrawLine(this Color color, int startX, int startY, int endX, int endY) =>
        Raylib.DrawLine(startX, startY, endX, endY, color);
    
    /// <summary>
    /// Draw a line (Vector version)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public static void DrawLine(this Color color, Vector2 start, Vector2 end) => Raylib.DrawLineV(start, end, color);
    
    /// <summary>
    /// Draw a line defining thickness
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="thick"></param>
    public static void DrawLine(this Color color, Vector2 start, Vector2 end, float thick) =>
        Raylib.DrawLineEx(start, end, thick, color);
    
    /// <summary>
    /// Draw a line using cubic-bezier curves in-out
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="thick"></param>
    public static void DrawLineBezier(this Color color, Vector2 start, Vector2 end, float thick) =>
        Raylib.DrawLineBezier(start, end, thick, color);

    /// <summary>
    /// Draw line using quadratic bezier curves with a control point
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="control"></param>
    /// <param name="thick"></param>
    public static void DrawLineBezierQuad(this Color color, Vector2 start, Vector2 end, Vector2 control, float thick) =>
        Raylib.DrawLineBezierQuad(start, end, control, thick, color);
    
    /// <summary>
    /// Draw line using cubic bezier curves with 2 control points
    /// </summary>
    /// <param name="color"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="startControl"></param>
    /// <param name="endControl"></param>
    /// <param name="thick"></param>
    public static void DrawLineBezierCubic(this Color color, Vector2 start, Vector2 end, Vector2 startControl,
        Vector2 endControl, float thick) =>
        Raylib.DrawLineBezierCubic(start, end, startControl, endControl, thick, color);
    
    /// <summary>
    /// Draw lines sequence
    /// </summary>
    /// <param name="color"></param>
    /// <param name="points"></param>
    public static void DrawLineStrip(this Color color, params Vector2[] points) =>
        Raylib.DrawLineStrip(points, points.Length, color);
    
    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    /// <param name="color"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="radius"></param>
    public static void DrawCircle(this Color color, int centerX, int centerY, float radius) =>
        Raylib.DrawCircle(centerX, centerY, radius, color);
    
    /// <summary>
    /// Draw a color-filled circle (Vector version)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    public static void DrawCircle(this Color color, Vector2 center, float radius) =>
        Raylib.DrawCircleV(center, radius, color);

    /// <summary>
    /// Draw circle outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="radius"></param>
    public static void DrawCircleLines(this Color color, int centerX, int centerY, float radius)
        => Raylib.DrawCircleLines(centerX, centerY, radius, color);
    
    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    public static void DrawCircleSector(this Color color, Vector2 center, float radius, float startAngle,
        float endAngle, int segments) =>
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);
    
    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="startAngle"></param>
    /// <param name="endAngle"></param>
    /// <param name="segments"></param>
    public static void DrawCircleSectorLines(this Color color, Vector2 center, float radius, float startAngle,
        float endAngle, int segments) =>
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);
    
    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    /// <param name="color1"></param>
    /// <param name="color2"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="radius"></param>
    public static void DrawCircleGradient(this Color color1, Color color2, int centerX, int centerY, float radius) =>
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);

    public static void DrawCircleGradient(this Color color1, Color color2, Vector2 center, float radius) =>
        DrawCircleGradient(color1, color2, (int)center.X, (int)center.Y, radius);
    
    /// <summary>
    /// Draw ellipse
    /// </summary>
    /// <param name="color"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="radiusX"></param>
    /// <param name="radiusY"></param>
    public static void DrawEllipse(this Color color, int centerX, int centerY, float radiusX, float radiusY) =>
        Raylib.DrawEllipse(centerX, centerY, radiusX, radiusY, color);

    public static void DrawEllipse(this Color color, Vector2 center, Vector2 radius) =>
        DrawEllipse(color, (int)center.X, (int)center.Y, radius.X, radius.Y);
    
    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="radiusX"></param>
    /// <param name="radiusY"></param>
    public static void DrawEllipseLines(this Color color, int centerX, int centerY, float radiusX, float radiusY) =>
        Raylib.DrawEllipseLines(centerX, centerY, radiusX, radiusY, color);

    public static void DrawEllipseLines(this Color color, Vector2 center, Vector2 radius) =>
        DrawEllipseLines(color, (int)center.X, (int)center.Y, radius.X, radius.Y);
    
    /// <summary>
    /// Draw ring
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="innerRadius"></param>
    /// <param name="outerRadius"></param>
    /// <param name="startAngle"></param>
    /// <param name="endAngle"></param>
    /// <param name="segments"></param>
    public static void DrawRing(this Color color, Vector2 center, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    
    /// <summary>
    /// Draw ring outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="innerRadius"></param>
    /// <param name="outerRadius"></param>
    /// <param name="startAngle"></param>
    /// <param name="endAngle"></param>
    /// <param name="segments"></param>
    public static void DrawRingLines(this Color color, Vector2 center, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    
    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    /// <param name="color"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public static void DrawRectangle(this Color color, int x, int y, int width, int height) =>
        Raylib.DrawRectangle(x, y, width, height, color);
    
    /// <summary>
    /// Draw a color-filled rectangle (Vector version)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="position"></param>
    /// <param name="size"></param>
    public static void DrawRectangle(this Color color, Vector2 position, Vector2 size) =>
        Raylib.DrawRectangleV(position, size, color);
    
    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    public static void DrawRectangle(this Color color, Rectangle rectangle) =>
        Raylib.DrawRectangleRec(rectangle, color);
    
    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    /// <param name="origin"></param>
    /// <param name="rotation"></param>
    public static void DrawRectangle(this Color color, Rectangle rectangle, Vector2 origin, float rotation) =>
        Raylib.DrawRectanglePro(rectangle, origin, rotation, color);
    
    /// <summary>
    /// Draw a vertical/horizontal-gradient-filled rectangle
    /// </summary>
    /// <param name="color1"></param>
    /// <param name="color2"></param>
    /// <param name="direction"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public static void DrawRectangleGradient(this Color color1, Color color2, GradientDirection direction, int x, int y,
        int width, int height) =>
        new Rectangle(x, y, width, height).DrawGradient(direction, color1, color2);
    
    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    /// <param name="color1"></param>
    /// <param name="color2"></param>
    /// <param name="color3"></param>
    /// <param name="color4"></param>
    /// <param name="rectangle"></param>
    public static void DrawRectangleGradient(this Color color1, Color color2, Color color3, Color color4,
        Rectangle rectangle) =>
        rectangle.DrawGradient(color1, color2, color3, color4);
    
    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public static void DrawRectangleLines(this Color color, int x, int y, int width, int height) =>
        Raylib.DrawRectangleLines(x, y, width, height, color);
    
    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    /// <param name="thick"></param>
    public static void DrawRectangleLines(this Color color, Rectangle rectangle, float thick) =>
        rectangle.DrawLines(thick, color);
    
    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    /// <param name="roundness"></param>
    /// <param name="segments"></param>
    public static void DrawRectangleRounded(this Color color, Rectangle rectangle, float roundness, int segments) =>
        Raylib.DrawRectangleRounded(rectangle, roundness, segments, color);
    
    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    /// <param name="roundness"></param>
    /// <param name="segments"></param>
    /// <param name="thick"></param>
    public static void DrawRectangleRoundedLines(this Color color, Rectangle rectangle, float roundness, int segments,
        float thick) => Raylib.DrawRectangleRoundedLines(rectangle, roundness, segments, thick, color);
    
    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="v3"></param>
    public static void DrawTriangle(this Color color, Vector2 v1, Vector2 v2, Vector2 v3) =>
        Raylib.DrawTriangle(v1, v2, v3, color);
    
    /// <summary>
    /// Draw triangle outline (vertex in counter-clockwise order!)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="v3"></param>
    public static void DrawTriangleLines(this Color color, Vector2 v1, Vector2 v2, Vector2 v3) =>
        Raylib.DrawTriangleLines(v1, v2, v3, color);
    
    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="points"></param>
    public static void DrawTriangleFan(this Color color, params Vector2[] points) =>
        Raylib.DrawTriangleFan(points, points.Length, color);
    
    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    /// <param name="color"></param>
    /// <param name="points"></param>
    public static void DrawTriangleStrip(this Color color, params Vector2[] points) =>
        Raylib.DrawTriangleStrip(points, points.Length, color);
    
    /// <summary>
    /// Draw a regular polygon (Vector version)
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="sides"></param>
    /// <param name="radius"></param>
    /// <param name="rotation"></param>
    public static void DrawPoly(this Color color, Vector2 center, int sides, float radius, float rotation) =>
        Raylib.DrawPoly(center, sides, radius, rotation, color);
    
    /// <summary>
    /// Draw a polygon outline of n sides
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="sides"></param>
    /// <param name="radius"></param>
    /// <param name="rotation"></param>
    public static void DrawPolyLines(this Color color, Vector2 center, int sides, float radius, float rotation) =>
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);
    
    /// <summary>
    /// Draw a polygon outline of n sides with extended parameters
    /// </summary>
    /// <param name="color"></param>
    /// <param name="center"></param>
    /// <param name="sides"></param>
    /// <param name="radius"></param>
    /// <param name="rotation"></param>
    /// <param name="thick"></param>
    public static void DrawPolyLines(this Color color, Vector2 center, int sides, float radius, float rotation,
        float thick) =>
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, thick, color);
}