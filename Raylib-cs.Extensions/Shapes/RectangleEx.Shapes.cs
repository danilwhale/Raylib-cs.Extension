using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class RectangleEx
{
    /// <summary>
    ///     Draw a color-filled rectangle
    /// </summary>
    public static void Draw(this Rectangle rectangle, Color color)
    {
        Raylib.DrawRectangleRec(rectangle, color);
    }

    /// <summary>
    ///     Draw a color-filled rectangle with pro parameters
    /// </summary>
    public static void Draw(this Rectangle rectangle, Vector2 origin, float rotation, Color color)
    {
        Raylib.DrawRectanglePro(rectangle, origin, rotation, color);
    }

    /// <summary>
    ///     Draw a gradient-filled rectangle
    /// </summary>
    public static void DrawGradient(this Rectangle rectangle, GradientDirection direction, Color color1,
        Color color2)
    {
        switch (direction)
        {
            case GradientDirection.Horizontal:
                Raylib.DrawRectangleGradientH((int)rectangle.X, (int)rectangle.Y, (int)rectangle.Width,
                    (int)rectangle.Height, color1, color2);
                break;
            case GradientDirection.Vertical:
                Raylib.DrawRectangleGradientV((int)rectangle.X, (int)rectangle.Y, (int)rectangle.Width,
                    (int)rectangle.Height, color1, color2);
                break;
        }
    }

    /// <summary>
    ///     Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    public static void DrawGradient(this Rectangle rectangle, Color color1, Color color2, Color color3,
        Color color4)
    {
        Raylib.DrawRectangleGradientEx(rectangle, color1, color2, color3, color4);
    }

    /// <summary>
    ///     Draw rectangle outline
    /// </summary>
    public static void DrawLines(this Rectangle rectangle, Color color)
    {
        Raylib.DrawRectangleLines((int)rectangle.X,
            (int)rectangle.Y, (int)rectangle.Width, (int)rectangle.Height, color);
    }

    /// <summary>
    ///     Draw rectangle outline with extended parameters
    /// </summary>
    public static void DrawLines(this Rectangle rectangle, float thick, Color color)
    {
        Raylib.DrawRectangleLinesEx(rectangle, thick, color);
    }

    /// <summary>
    ///     Draw rectangle with rounded edges
    /// </summary>
    public static void DrawRounded(this Rectangle rectangle, float roundness, int segments, Color color)
    {
        Raylib.DrawRectangleRounded(rectangle, roundness, segments, color);
    }

    /// <summary>
    ///     Draw rectangle with rounded edges outline
    /// </summary>
    public static void DrawRoundedLines(this Rectangle rectangle, float roundness, int segments, float thick,
        Color color)
    {
        Raylib.DrawRectangleRoundedLines(rectangle, roundness, segments, thick, color);
    }

    /// <summary>
    ///     Check collision between two rectangles
    /// </summary>
    public static bool CheckCollisionRectangles(this Rectangle rectangle, Rectangle other)
    {
        return Raylib.CheckCollisionRecs(rectangle, other);
    }

    /// <summary>
    ///     Check if point is inside rectangle
    /// </summary>
    public static bool CheckCollisionPoint(this Rectangle rectangle, Vector2 point)
    {
        return Raylib.CheckCollisionPointRec(point, rectangle);
    }

    /// <summary>
    ///     Check collision between circle and rectangle
    /// </summary>
    public static bool CheckCollisionCircle(this Rectangle rectangle, Vector2 center, float radius)
    {
        return Raylib.CheckCollisionCircleRec(center, radius, rectangle);
    }

    /// <summary>
    ///     Get collision rectangle for two rectangles collision
    /// </summary>
    public static Rectangle GetCollisionRectangle(this Rectangle rectangle, Rectangle other)
    {
        return Raylib.GetCollisionRec(rectangle, other);
    }
}