using System.Numerics;

namespace Raylib_cs.Extension;

public static partial class RectangleEx
{
    public static void Draw(this Rectangle rectangle, Color color) =>
        Raylib.DrawRectangleRec(rectangle, color);

    public static void Draw(this Rectangle rectangle, Vector2 origin, float rotation, Color color) =>
        Raylib.DrawRectanglePro(rectangle, origin, rotation, color);

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

    public static void DrawGradient(this Rectangle rectangle, Color color1, Color color2, Color color3,
        Color color4) => Raylib.DrawRectangleGradientEx(rectangle, color1, color2, color3, color4);

    public static void DrawLines(this Rectangle rectangle, Color color) => Raylib.DrawRectangleLines((int)rectangle.x,
        (int)rectangle.y, (int)rectangle.width, (int)rectangle.height, color);

    public static void DrawLines(this Rectangle rectangle, float thick, Color color) =>
        Raylib.DrawRectangleLinesEx(rectangle, thick, color);

    public static void DrawRounded(this Rectangle rectangle, float roundness, int segments, Color color) =>
        Raylib.DrawRectangleRounded(rectangle, roundness, segments, color);

    public static void DrawRoundedLines(this Rectangle rectangle, float roundness, int segments, float thick,
        Color color) => Raylib.DrawRectangleRoundedLines(rectangle, roundness, segments, thick, color);

    public static bool CheckCollisionRectangles(this Rectangle rectangle, Rectangle other) =>
        Raylib.CheckCollisionRecs(rectangle, other);

    public static bool CheckCollisionPoint(this Rectangle rectangle, Vector2 point) =>
        Raylib.CheckCollisionPointRec(point, rectangle);

    public static Rectangle GetCollisionRectangle(this Rectangle rectangle, Rectangle other) =>
        Raylib.GetCollisionRec(rectangle, other);
}