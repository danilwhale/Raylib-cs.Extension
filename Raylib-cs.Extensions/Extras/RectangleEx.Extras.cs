using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class RectangleEx
{
    /// <summary>
    /// Set rectangle values from 2d position and 2d size vectors
    /// </summary>
    public static Rectangle FromVector(this ref Rectangle rectangle, Vector2 position, Vector2 size)
    {
        rectangle.x = position.X;
        rectangle.y = position.Y;
        rectangle.width = size.X;
        rectangle.height = size.Y;
        
        return rectangle;
    }
    
    /// <summary>
    /// Create rectangle from 2d position and 2d size vectors
    /// </summary>
    public static Rectangle FromVector(Vector2 position, Vector2 size)
    {
        Rectangle rectangle = new Rectangle();
        rectangle.FromVector(position, size);
        return rectangle;
    }

    public static Vector2 GetPosition(this Rectangle rectangle)
    {
        return new Vector2(rectangle.x, rectangle.y);
    }

    public static Vector2 GetSize(this Rectangle rectangle)
    {
        return new Vector2(rectangle.width, rectangle.height);
    }

    public static void SetPosition(this ref Rectangle rectangle, Vector2 position)
    {
        rectangle.x = position.X;
        rectangle.y = position.Y;
    }

    public static void SetSize(this ref Rectangle rectangle, Vector2 size)
    {
        rectangle.width = size.X;
        rectangle.height = size.Y;
    }
}