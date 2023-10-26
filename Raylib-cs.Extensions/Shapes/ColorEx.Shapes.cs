using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ColorEx
{
    /// <summary>
    /// Draw a pixel
    /// </summary>
    public static void DrawPixel(this Color color, int x, int y) => Raylib.DrawPixel(x, y, color);
    
    /// <summary>
    /// Draw a pixel
    /// </summary>
    public static void DrawPixel(this Color color, float x, float y) => color.DrawPixel(new Vector2(x, y));
    
    /// <summary>
    /// Draw a pixel (Vector version)   
    /// </summary>
    public static void DrawPixel(this Color color, Vector2 position) => Raylib.DrawPixelV(position, color);
    
    /// <summary>
    /// Draw a line
    /// </summary>
    public static void DrawLine(this Color color, int startX, int startY, int endX, int endY) =>
        Raylib.DrawLine(startX, startY, endX, endY, color);

    /// <summary>
    /// Draw a line
    /// </summary>
    public static void DrawLine(this Color color, float startX, float startY, float endX, float endY) =>
        color.DrawLine(new Vector2(startX, startY), new Vector2(endX, endY));
    
    /// <summary>
    /// Draw a line (Vector version)
    /// </summary>
    public static void DrawLine(this Color color, Vector2 start, Vector2 end) => Raylib.DrawLineV(start, end, color);
    
    /// <summary>
    /// Draw a line defining thickness
    /// </summary>
    public static void DrawLine(this Color color, Vector2 start, Vector2 end, float thick) =>
        Raylib.DrawLineEx(start, end, thick, color);
    
    /// <summary>
    /// Draw a line using cubic-bezier curves in-out
    /// </summary>
    public static void DrawLineBezier(this Color color, Vector2 start, Vector2 end, float thick) =>
        Raylib.DrawLineBezier(start, end, thick, color);

    /// <summary>
    /// Draw line using quadratic bezier curves with a control point
    /// </summary>
    public static void DrawLineBezierQuad(this Color color, Vector2 start, Vector2 end, Vector2 control, float thick) =>
        Raylib.DrawLineBezierQuad(start, end, control, thick, color);
    
    /// <summary>
    /// Draw line using cubic bezier curves with 2 control points
    /// </summary>
    public static void DrawLineBezierCubic(this Color color, Vector2 start, Vector2 end, Vector2 startControl,
        Vector2 endControl, float thick) =>
        Raylib.DrawLineBezierCubic(start, end, startControl, endControl, thick, color);
    
    /// <summary>
    /// Draw lines sequence
    /// </summary>
    public static void DrawLineStrip(this Color color, params Vector2[] points) =>
        Raylib.DrawLineStrip(points, points.Length, color);
    
    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    public static void DrawCircle(this Color color, int centerX, int centerY, float radius) =>
        Raylib.DrawCircle(centerX, centerY, radius, color);

    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    public static void DrawCircle(this Color color, float centerX, float centerY, float radius) =>
        color.DrawCircle(new Vector2(centerX, centerY), radius);
    
    /// <summary>
    /// Draw a color-filled circle (Vector version)
    /// </summary>
    public static void DrawCircle(this Color color, Vector2 center, float radius) =>
        Raylib.DrawCircleV(center, radius, color);

    /// <summary>
    /// Draw circle outline
    /// </summary>
    public static void DrawCircleLines(this Color color, int centerX, int centerY, float radius)
        => Raylib.DrawCircleLines(centerX, centerY, radius, color);

    /// <summary>
    /// Draw circle outline
    /// </summary>
    public static void DrawCircleLines(this Color color, float centerX, float centerY, float radius)
        => color.DrawCircleLines(new Vector2(centerX, centerY), radius);
    
    /// <summary>
    /// Draw circle outline
    /// </summary>
    public static void DrawCircleLines(this Color color, Vector2 center, float radius)
        => Raylib.DrawCircleLines((int)center.X, (int)center.Y, radius, color);

    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    public static void DrawCircleSector(this Color color, float centerX, float centerY, float radius, float startAngle,
        float endAngle, int segments) =>
        color.DrawCircleSector(new Vector2(centerX, centerY), radius, startAngle, endAngle, segments);
    
    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    public static void DrawCircleSector(this Color color, Vector2 center, float radius, float startAngle,
        float endAngle, int segments) =>
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);

    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    public static void DrawCircleSectorLines(this Color color, float centerX, float centerY, float radius, float startAngle,
        float endAngle, int segments) =>
        color.DrawCircleSectorLines(new Vector2(centerX, centerY), radius, startAngle, endAngle, segments);
    
    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    public static void DrawCircleSectorLines(this Color color, Vector2 center, float radius, float startAngle,
        float endAngle, int segments) =>
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);
    
    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    public static void DrawCircleGradient(this Color color1, Color color2, int centerX, int centerY, float radius) =>
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);
    
    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    public static void DrawCircleGradient(this Color color1, Color color2, float centerX, float centerY, float radius) =>
        Raylib.DrawCircleGradient((int)centerX, (int)centerY, radius, color1, color2);

    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    public static void DrawCircleGradient(this Color color1, Color color2, Vector2 center, float radius) =>
        DrawCircleGradient(color1, color2, center.X, center.Y, radius);
    
    /// <summary>
    /// Draw ellipse
    /// </summary>
    public static void DrawEllipse(this Color color, int centerX, int centerY, float radiusX, float radiusY) =>
        Raylib.DrawEllipse(centerX, centerY, radiusX, radiusY, color);

    /// <summary>
    /// Draw ellipse
    /// </summary>
    public static void DrawEllipse(this Color color, float centerX, float centerY, float radiusX, float radiusY) =>
        color.DrawEllipse(new Vector2(centerX, centerY), new Vector2(radiusX, radiusY));

    /// <summary>
    /// Draw ellipse
    /// </summary>
    public static void DrawEllipse(this Color color, Vector2 center, Vector2 radius) =>
        DrawEllipse(color, (int)center.X, (int)center.Y, radius.X, radius.Y);
    
    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    public static void DrawEllipseLines(this Color color, int centerX, int centerY, float radiusX, float radiusY) =>
        Raylib.DrawEllipseLines(centerX, centerY, radiusX, radiusY, color);

    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    public static void DrawEllipseLines(this Color color, float centerX, float centerY, float radiusX, float radiusY) =>
        color.DrawEllipseLines((int)centerX, (int)centerY, radiusX, radiusY);
    
    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    public static void DrawEllipseLines(this Color color, Vector2 center, Vector2 radius) =>
        DrawEllipseLines(color, (int)center.X, (int)center.Y, radius.X, radius.Y);

    /// <summary>
    /// Draw ring
    /// </summary>
    public static void DrawRing(this Color color, float centerX, float centerY, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        color.DrawRing(new Vector2(centerX, centerY), innerRadius, outerRadius, startAngle, endAngle, segments);
    
    /// <summary>
    /// Draw ring
    /// </summary>
    public static void DrawRing(this Color color, Vector2 center, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);

    /// <summary>
    /// Draw ring outline
    /// </summary>
    public static void DrawRingLines(this Color color, float centerX, float centerY, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        color.DrawRingLines(new Vector2(centerX, centerY), innerRadius, outerRadius, startAngle, endAngle, segments);
    
    /// <summary>
    /// Draw ring outline
    /// </summary>
    public static void DrawRingLines(this Color color, Vector2 center, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    
    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangle(this Color color, int x, int y, int width, int height) =>
        Raylib.DrawRectangle(x, y, width, height, color);

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangle(this Color color, float x, float y, float width, float height) =>
        color.DrawRectangle(new Rectangle(x, y, width, height));
    
    /// <summary>
    /// Draw a color-filled rectangle (Vector version)
    /// </summary>
    public static void DrawRectangle(this Color color, Vector2 position, Vector2 size) =>
        Raylib.DrawRectangleV(position, size, color);
    
    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangle(this Color color, Rectangle rectangle) =>
        Raylib.DrawRectangleRec(rectangle, color);
    
    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    public static void DrawRectangle(this Color color, Rectangle rectangle, Vector2 origin, float rotation) =>
        Raylib.DrawRectanglePro(rectangle, origin, rotation, color);
    
    /// <summary>
    /// Draw a gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradient(this Color color1, Color color2, GradientDirection direction, int x, int y,
        int width, int height) =>
        new Rectangle(x, y, width, height).DrawGradient(direction, color1, color2);
    
    /// <summary>
    /// Draw a gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradient(this Color color1, Color color2, GradientDirection direction, float x, float y,
        float width, float height) =>
        new Rectangle(x, y, width, height).DrawGradient(direction, color1, color2);
    
    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    public static void DrawRectangleGradient(this Color color1, Color color2, Color color3, Color color4,
        Rectangle rectangle) =>
        rectangle.DrawGradient(color1, color2, color3, color4);
    
    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    public static void DrawRectangleLines(this Color color, int x, int y, int width, int height) =>
        Raylib.DrawRectangleLines(x, y, width, height, color);

    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    public static void DrawRectangleLines(this Color color, float x, float y, float width, float height) =>
        color.DrawRectangleLines(new Rectangle(x, y, width, height), 1);
    
    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    public static void DrawRectangleLines(this Color color, Rectangle rectangle, float thick) =>
        rectangle.DrawLines(thick, color);
    
    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    public static void DrawRectangleRounded(this Color color, Rectangle rectangle, float roundness, int segments) =>
        Raylib.DrawRectangleRounded(rectangle, roundness, segments, color);
    
    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    public static void DrawRectangleRoundedLines(this Color color, Rectangle rectangle, float roundness, int segments,
        float thick) => Raylib.DrawRectangleRoundedLines(rectangle, roundness, segments, thick, color);
    
    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangle(this Color color, Vector2 v1, Vector2 v2, Vector2 v3) =>
        Raylib.DrawTriangle(v1, v2, v3, color);
    
    /// <summary>
    /// Draw triangle outline (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangleLines(this Color color, Vector2 v1, Vector2 v2, Vector2 v3) =>
        Raylib.DrawTriangleLines(v1, v2, v3, color);
    
    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    public static void DrawTriangleFan(this Color color, params Vector2[] points) =>
        Raylib.DrawTriangleFan(points, points.Length, color);
    
    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip(this Color color, params Vector2[] points) =>
        Raylib.DrawTriangleStrip(points, points.Length, color);
    
    /// <summary>
    /// Draw a regular polygon (Vector version)
    /// </summary>
    public static void DrawPoly(this Color color, Vector2 center, int sides, float radius, float rotation) =>
        Raylib.DrawPoly(center, sides, radius, rotation, color);
    
    /// <summary>
    /// Draw a polygon outline of n sides
    /// </summary>
    public static void DrawPolyLines(this Color color, Vector2 center, int sides, float radius, float rotation) =>
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);
    
    /// <summary>
    /// Draw a polygon outline of n sides with extended parameters
    /// </summary>
    public static void DrawPolyLines(this Color color, Vector2 center, int sides, float radius, float rotation,
        float thick) =>
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, thick, color);
}