using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class RectangleEx
{
    /// <summary>
    /// Set rectangle values from 2d position and 2d size vectors
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="position"></param>
    /// <param name="size"></param>
    /// <returns></returns>
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
    /// <param name="position"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static Rectangle FromVector(Vector2 position, Vector2 size)
    {
        Rectangle rectangle = new Rectangle();
        rectangle.FromVector(position, size);
        return rectangle;
    }
}