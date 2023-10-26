using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class RectangleEx
{
    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="color"></param>
    public static void Draw(this Rectangle rectangle, Color color) =>
        Raylib.DrawRectangleRec(rectangle, color);
    
    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="origin"></param>
    /// <param name="rotation"></param>
    /// <param name="color"></param>
    public static void Draw(this Rectangle rectangle, Vector2 origin, float rotation, Color color) =>
        Raylib.DrawRectanglePro(rectangle, origin, rotation, color);
    
    /// <summary>
    /// Draw a vertical/horizontal-gradient-filled rectangle
    /// </summary>
    public static void DrawGradient(this Rectangle rectangle, GradientDirection direction, Color color1,
        Color color2)
    {
        switch (direction)
        {
            case GradientDirection.Horizontal:
                Raylib.DrawRectangleGradientH((int)rectangle.x, (int)rectangle.y, (int)rectangle.width,
                    (int)rectangle.height, color1, color2);
                break;
            case GradientDirection.Vertical:
                Raylib.DrawRectangleGradientV((int)rectangle.x, (int)rectangle.y, (int)rectangle.width,
                    (int)rectangle.height, color1, color2);
                break;
        }
    }
    
    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    /// <param name="color1"></param>
    /// <param name="color2"></param>
    /// <param name="color3"></param>
    /// <param name="color4"></param>
    /// <param name="rectangle"></param>
    public static void DrawGradient(this Rectangle rectangle, Color color1, Color color2, Color color3,
        Color color4) => Raylib.DrawRectangleGradientEx(rectangle, color1, color2, color3, color4);

    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    public static void DrawLines(this Rectangle rectangle, Color color) => Raylib.DrawRectangleLines((int)rectangle.x,
        (int)rectangle.y, (int)rectangle.width, (int)rectangle.height, color);
    
    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    /// <param name="thick"></param>
    public static void DrawLines(this Rectangle rectangle, float thick, Color color) =>
        Raylib.DrawRectangleLinesEx(rectangle, thick, color);
    
    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    /// <param name="roundness"></param>
    /// <param name="segments"></param>
    public static void DrawRounded(this Rectangle rectangle, float roundness, int segments, Color color) =>
        Raylib.DrawRectangleRounded(rectangle, roundness, segments, color);
    
    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rectangle"></param>
    /// <param name="roundness"></param>
    /// <param name="segments"></param>
    /// <param name="thick"></param>
    public static void DrawRoundedLines(this Rectangle rectangle, float roundness, int segments, float thick,
        Color color) => Raylib.DrawRectangleRoundedLines(rectangle, roundness, segments, thick, color);
    
    /// <summary>
    /// Check collision between two rectangles
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static bool CheckCollisionRectangles(this Rectangle rectangle, Rectangle other) =>
        Raylib.CheckCollisionRecs(rectangle, other);
    
    /// <summary>
    /// Check if point is inside rectangle
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    public static bool CheckCollisionPoint(this Rectangle rectangle, Vector2 point) =>
        Raylib.CheckCollisionPointRec(point, rectangle);
    
    /// <summary>
    /// Check collision between circle and rectangle
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    public static bool CheckCollisionCircle(this Rectangle rectangle, Vector2 center, float radius)
        => Raylib.CheckCollisionCircleRec(center, radius, rectangle);
    
    /// <summary>
    /// Get collision rectangle for two rectangles collision    
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static Rectangle GetCollisionRectangle(this Rectangle rectangle, Rectangle other) =>
        Raylib.GetCollisionRec(rectangle, other);
}