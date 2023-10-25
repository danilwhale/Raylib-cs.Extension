using System.Numerics;

namespace Raylib_cs.Extension;

public static partial class ColorEx
{
    public static void DrawPixel(this Color color, int x, int y) => Raylib.DrawPixel(x, y, color);
    public static void DrawPixel(this Color color, Vector2 position) => Raylib.DrawPixelV(position, color);

    public static void DrawLine(this Color color, int startX, int startY, int endX, int endY) =>
        Raylib.DrawLine(startX, startY, endX, endY, color);

    public static void DrawLine(this Color color, Vector2 start, Vector2 end) => Raylib.DrawLineV(start, end, color);

    public static void DrawLine(this Color color, Vector2 start, Vector2 end, float thick) =>
        Raylib.DrawLineEx(start, end, thick, color);

    public static void DrawLineBezier(this Color color, Vector2 start, Vector2 end, float thick) =>
        Raylib.DrawLineBezier(start, end, thick, color);

    public static void DrawLineBezierQuad(this Color color, Vector2 start, Vector2 end, Vector2 control, float thick) =>
        Raylib.DrawLineBezierQuad(start, end, control, thick, color);

    public static void DrawLineBezierCubic(this Color color, Vector2 start, Vector2 end, Vector2 startControl,
        Vector2 endControl, float thick) =>
        Raylib.DrawLineBezierCubic(start, end, startControl, endControl, thick, color);

    public static void DrawLineStrip(this Color color, params Vector2[] points) =>
        Raylib.DrawLineStrip(points, points.Length, color);

    public static void DrawCircle(this Color color, int centerX, int centerY, float radius) =>
        Raylib.DrawCircle(centerX, centerY, radius, color);

    public static void DrawCircle(this Color color, Vector2 center, float radius) =>
        Raylib.DrawCircleV(center, radius, color);

    public static void DrawCircleSector(this Color color, Vector2 center, float radius, float startAngle,
        float endAngle, int segments) =>
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);

    public static void DrawCircleSectorLines(this Color color, Vector2 center, float radius, float startAngle,
        float endAngle, int segments) =>
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);

    public static void DrawCircleGradient(this Color color1, Color color2, int centerX, int centerY, float radius) =>
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);

    public static void DrawCircleGradient(this Color color1, Color color2, Vector2 center, float radius) =>
        DrawCircleGradient(color1, color2, (int)center.X, (int)center.Y, radius);

    public static void DrawEllipse(this Color color, int centerX, int centerY, float radiusX, float radiusY) =>
        Raylib.DrawEllipse(centerX, centerY, radiusX, radiusY, color);

    public static void DrawEllipse(this Color color, Vector2 center, Vector2 radius) =>
        DrawEllipse(color, (int)center.X, (int)center.Y, radius.X, radius.Y);

    public static void DrawEllipseLines(this Color color, int centerX, int centerY, float radiusX, float radiusY) =>
        Raylib.DrawEllipseLines(centerX, centerY, radiusX, radiusY, color);

    public static void DrawEllipseLines(this Color color, Vector2 center, Vector2 radius) =>
        DrawEllipseLines(color, (int)center.X, (int)center.Y, radius.X, radius.Y);

    public static void DrawRing(this Color color, Vector2 center, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);

    public static void DrawRingLines(this Color color, Vector2 center, float innerRadius, float outerRadius,
        float startAngle, float endAngle, int segments) =>
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);

    public static void DrawRectangle(this Color color, int x, int y, int width, int height) =>
        Raylib.DrawRectangle(x, y, width, height, color);

    public static void DrawRectangle(this Color color, Vector2 position, Vector2 size) =>
        Raylib.DrawRectangleV(position, size, color);

    public static void DrawRectangle(this Color color, Rectangle rectangle) =>
        Raylib.DrawRectangleRec(rectangle, color);

    public static void DrawRectangle(this Color color, Rectangle rectangle, Vector2 origin, float rotation) =>
        Raylib.DrawRectanglePro(rectangle, origin, rotation, color);

    public static void DrawRectangleGradient(this Color color1, Color color2, GradientDirection direction, int x, int y,
        int width, int height) =>
        new Rectangle(x, y, width, height).DrawGradient(direction, color1, color2);

    public static void DrawRectangleGradient(this Color color1, Color color2, Color color3, Color color4,
        Rectangle rectangle) =>
        rectangle.DrawGradient(color1, color2, color3, color4);

    public static void DrawRectangleLines(this Color color, int x, int y, int width, int height) =>
        Raylib.DrawRectangleLines(x, y, width, height, color);

    public static void DrawRectangleLines(this Color color, Rectangle rectangle, float thick) =>
        rectangle.DrawLines(thick, color);

    public static void DrawRectangleRounded(this Color color, Rectangle rectangle, float roundness, int segments) =>
        Raylib.DrawRectangleRounded(rectangle, roundness, segments, color);

    public static void DrawRectangleRoundedLines(this Color color, Rectangle rectangle, float roundness, int segments,
        float thick) => Raylib.DrawRectangleRoundedLines(rectangle, roundness, segments, thick, color);

    public static void DrawTriangle(this Color color, Vector2 v1, Vector2 v2, Vector2 v3) =>
        Raylib.DrawTriangle(v1, v2, v3, color);

    public static void DrawTriangleLines(this Color color, Vector2 v1, Vector2 v2, Vector2 v3) =>
        Raylib.DrawTriangleLines(v1, v2, v3, color);

    public static void DrawTriangleFan(this Color color, params Vector2[] points) =>
        Raylib.DrawTriangleFan(points, points.Length, color);

    public static void DrawTriangleStrip(this Color color, params Vector2[] points) =>
        Raylib.DrawTriangleStrip(points, points.Length, color);

    public static void DrawPoly(this Color color, Vector2 center, int sides, float radius, float rotation) =>
        Raylib.DrawPoly(center, sides, radius, rotation, color);

    public static void DrawPolyLines(this Color color, Vector2 center, int sides, float radius, float rotation) =>
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);

    public static void DrawPolyLines(this Color color, Vector2 center, int sides, float radius, float rotation,
        float thick) =>
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, thick, color);
}