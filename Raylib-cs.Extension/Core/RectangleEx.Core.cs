using System.Numerics;

namespace Raylib_cs.Extension.Core;

public static partial class RectangleEx
{
    public static void FromVector(this ref Rectangle rectangle, Vector2 position, Vector2 size)
    {
        rectangle.x = position.X;
        rectangle.y = position.Y;
        rectangle.width = size.X;
        rectangle.height = size.Y;
    }

    public static Rectangle FromVector(Vector2 position, Vector2 size)
    {
        Rectangle rectangle = new Rectangle();
        rectangle.FromVector(position, size);
        return rectangle;
    }
}