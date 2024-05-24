using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.Extensions;

public static unsafe partial class ImageEx
{
    // https://github.com/ChrisDill/Raylib-cs/issues/244 >>>
    [DllImport(Raylib.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* ExportImageToMemory(Image image, sbyte* fileType, int* fileSize);
    // <<<

    /// <summary>
    ///     Load texture from image data
    /// </summary>
    public static Texture2D LoadTexture(this Image image)
    {
        return Raylib.LoadTextureFromImage(image);
    }

    /// <summary>
    ///     Load cubemap from image, multiple image cubemap layouts supported
    /// </summary>
    public static Texture2D LoadCubemap(this Image image, CubemapLayout layout)
    {
        return Raylib.LoadTextureCubemap(image, layout);
    }

    /// <summary>
    ///     Check if an image is ready
    /// </summary>
    public static bool IsReady(this Image image)
    {
        return Raylib.IsImageReady(image);
    }

    /// <summary>
    ///     Unload image from CPU memory (RAM)
    /// </summary>
    public static void Unload(this Image image)
    {
        Raylib.UnloadImage(image);
    }

    /// <summary>
    ///     Export image data to file, returns true on success
    /// </summary>
    public static bool Export(this Image image, string path)
    {
        return Raylib.ExportImage(image, path);
    }

    /// <summary>
    ///     Export image to memory buffer
    /// </summary>
    public static byte[] ExportImageToMemory(this Image image, string fileType)
    {
        using var fileTypeBuffer = new Utf8Buffer(fileType);
        var size = 0;

        using var rlBytes = new RlMemoryHandle(ExportImageToMemory(image, fileTypeBuffer.AsPointer(), &size), size);
        var bytes = new byte[size];

        fixed (byte* pBytes = bytes)
        {
            Buffer.MemoryCopy(rlBytes.AsPtr<byte>(), pBytes, size, size);
        }

        return bytes;
    }

    /// <summary>
    ///     Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    public static bool ExportAsCode(this Image image, string path)
    {
        return Raylib.ExportImageAsCode(image, path);
    }

    /// <summary>
    ///     Create an image duplicate (useful for transformations)
    /// </summary>
    public static Image Copy(this Image image)
    {
        return Raylib.ImageCopy(image);
    }

    /// <summary>
    ///     Create an image from another image piece
    /// </summary>
    public static Image FromImage(this Image image, Rectangle rectangle)
    {
        return Raylib.ImageFromImage(image, rectangle);
    }


    /// <summary>
    ///     Convert image data to desired format
    /// </summary>
    public static void Format(this ref Image image, PixelFormat newFormat)
    {
        Raylib.ImageFormat(ref image, newFormat);
    }

    /// <summary>
    ///     Convert image to POT (power-of-two)
    /// </summary>
    public static void ToPOT(this ref Image image, Color fill)
    {
        Raylib.ImageToPOT(ref image, fill);
    }

    /// <summary>
    ///     Crop an image to a defined rectangle
    /// </summary>
    public static void Crop(this ref Image image, Rectangle crop)
    {
        Raylib.ImageCrop(ref image, crop);
    }

    /// <summary>
    ///     Crop image depending on alpha value
    /// </summary>
    public static void AlphaCrop(this ref Image image, float threshold)
    {
        Raylib.ImageAlphaCrop(ref image, threshold);
    }

    /// <summary>
    ///     Clear alpha channel to desired color
    /// </summary>
    public static void AlphaClear(this ref Image image, Color color, float threshold)
    {
        Raylib.ImageAlphaClear(ref image, color, threshold);
    }

    /// <summary>
    ///     Apply alpha mask to image
    /// </summary>
    public static void AlphaMask(this ref Image image, Image alphaMask)
    {
        Raylib.ImageAlphaMask(ref image, alphaMask);
    }

    /// <summary>
    ///     Premultiply alpha channel
    /// </summary>
    public static void AlphaPremultiply(this ref Image image)
    {
        Raylib.ImageAlphaPremultiply(ref image);
    }

    /// <summary>
    ///     Apply Gaussian blur using a box blur approximation
    /// </summary>
    public static void BlurGaussian(this ref Image image, int blurSize)
    {
        Raylib.ImageBlurGaussian(ref image, blurSize);
    }

    /// <summary>
    ///     Resize image (Bicubic scaling algorithm)
    /// </summary>
    public static void Resize(this ref Image image, int newWidth, int newHeight)
    {
        Raylib.ImageResize(ref image, newWidth, newHeight);
    }

    /// <summary>
    ///     Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    public static void ResizeNearest(this ref Image image, int newWidth, int newHeight)
    {
        Raylib.ImageResizeNN(ref image, newWidth, newHeight);
    }

    /// <summary>
    ///     Resize canvas and fill with color
    /// </summary>
    public static void ResizeCanvas(this ref Image image, int newWidth, int newHeight, int offsetX, int offsetY,
        Color fill)
    {
        Raylib.ImageResizeCanvas(ref image, newWidth, newHeight, offsetX, offsetY, fill);
    }

    /// <summary>
    ///     Compute all mipmap levels for a provided image
    /// </summary>
    public static void Mipmaps(this ref Image image)
    {
        Raylib.ImageMipmaps(ref image);
    }

    /// <summary>
    ///     Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    public static void Dither(this ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
    {
        Raylib.ImageDither(ref image, rBpp, gBpp, bBpp, aBpp);
    }

    /// <summary>
    ///     Flip image vertically
    /// </summary>
    public static void FlipVertical(this ref Image image)
    {
        Raylib.ImageFlipVertical(ref image);
    }

    /// <summary>
    ///     Flip image horizontally
    /// </summary>
    public static void FlipHorizontal(this ref Image image)
    {
        Raylib.ImageFlipHorizontal(ref image);
    }

    /// <summary>
    ///     Rotate image by input angle in degrees (-359 to 359)
    /// </summary>
    public static void Rotate(this ref Image image, int degrees)
    {
        Raylib.ImageRotate(ref image, degrees);
    }

    /// <summary>
    ///     Rotate image clockwise 90deg
    /// </summary>
    public static void RotateCW(this ref Image image)
    {
        Raylib.ImageRotateCW(ref image);
    }

    /// <summary>
    ///     Rotate image counter-clockwise 90deg
    /// </summary>
    public static void RotateCCW(this ref Image image)
    {
        Raylib.ImageRotateCCW(ref image);
    }

    /// <summary>
    ///     Modify image color: tint
    /// </summary>
    public static void ColorTint(this ref Image image, Color tint)
    {
        Raylib.ImageColorTint(ref image, tint);
    }

    /// <summary>
    ///     Modify image color: invert
    /// </summary>
    public static void ColorInverse(this ref Image image)
    {
        Raylib.ImageColorInvert(ref image);
    }

    /// <summary>
    ///     Modify image color: grayscale
    /// </summary>
    public static void ColorGrayscale(this ref Image image)
    {
        Raylib.ImageColorGrayscale(ref image);
    }

    /// <summary>
    ///     Modify image color: contrast (-100 to 100)
    /// </summary>
    public static void ColorContrast(this ref Image image, float contrast)
    {
        Raylib.ImageColorContrast(ref image, contrast);
    }

    /// <summary>
    ///     Modify image color: brightness (-255 to 255)
    /// </summary>
    public static void ColorBrightness(this ref Image image, int brightness)
    {
        Raylib.ImageColorBrightness(ref image, brightness);
    }

    /// <summary>
    ///     Modify image color: replace color
    /// </summary>
    public static void ColorReplace(this ref Image image, Color color, Color replace)
    {
        Raylib.ImageColorReplace(ref image, color, replace);
    }

    /// <summary>
    ///     Get color data from image as a Color array (RGBA - 32bit)
    ///     (replacement for Load/UnloadColors)
    /// </summary>
    public static Color[] GetColors(this Image image)
    {
        var colorsHandle =
            new RlMemoryHandle(Raylib.LoadImageColors(image), image.Width * image.Height * sizeof(Color));

        var colors = new Color[image.Width * image.Height];
        colorsHandle.CopyTo<Color>(colors);

        Raylib.UnloadImageColors(colorsHandle.AsPtr<Color>());
        return colors;
    }

    /// <summary>
    ///     Get colors palette from image as a Color array (RGBA - 32bit)
    ///     (replacement for Load/UnloadColors)
    /// </summary>
    public static Color[] GetColorPalette(this Image image, int maxPaletteSize)
    {
        var colorCount = 0;
        var paletteHandle = new RlMemoryHandle(Raylib.LoadImagePalette(image, maxPaletteSize, &colorCount), colorCount);

        var palette = new Color[colorCount];
        paletteHandle.CopyTo<Color>(palette);

        Raylib.UnloadImagePalette(paletteHandle.AsPtr<Color>());
        return palette;
    }

    /// <summary>
    ///     Get image alpha border rectangle
    /// </summary>
    public static Rectangle GetAlphaBorder(this Image image, float threshold)
    {
        return Raylib.GetImageAlphaBorder(image, threshold);
    }

    /// <summary>
    ///     Get image pixel color at (x, y) position
    /// </summary>
    public static Color GetColor(this Image image, int x, int y)
    {
        return Raylib.GetImageColor(image, x, y);
    }


    /// <summary>
    ///     Clear image background with given color
    /// </summary>
    public static void ClearBackground(this ref Image dst, Color color)
    {
        Raylib.ImageClearBackground(ref dst, color);
    }

    /// <summary>
    ///     Draw pixel within an image
    /// </summary>
    public static void DrawPixel(this ref Image dst, int x, int y, Color color)
    {
        Raylib.ImageDrawPixel(ref dst, x, y, color);
    }

    /// <summary>
    ///     Draw pixel within an image (Vector version)
    /// </summary>
    public static void DrawPixel(this ref Image dst, Vector2 position, Color color)
    {
        Raylib.ImageDrawPixelV(ref dst, position, color);
    }

    /// <summary>
    ///     Draw line within an image
    /// </summary>
    public static void DrawLine(this ref Image dst, int startX, int startY, int endX, int endY, Color color)
    {
        Raylib.ImageDrawLine(ref dst, startX, startY, endX, endY, color);
    }

    /// <summary>
    ///     Draw line within an image (Vector version)
    /// </summary>
    public static void DrawLine(this ref Image dst, Vector2 start, Vector2 end, Color color)
    {
        Raylib.ImageDrawLineV(ref dst, start, end, color);
    }

    /// <summary>
    ///     Draw a filled circle within an image
    /// </summary>
    public static void DrawCircle(this ref Image dst, int centerX, int centerY, int radius, Color color)
    {
        Raylib.ImageDrawCircle(ref dst, centerX, centerY, radius, color);
    }

    /// <summary>
    ///     Draw a filled circle within an image (Vector version)
    /// </summary>
    public static void DrawCircle(this ref Image dst, Vector2 center, int radius, Color color)
    {
        Raylib.ImageDrawCircleV(ref dst, center, radius, color);
    }

    /// <summary>
    ///     Draw circle outline within an image
    /// </summary>
    public static void DrawCircleLines(this ref Image dst, int centerX, int centerY, int radius, Color color)
    {
        fixed (Image* dstPtr = &dst)
        {
            Raylib.ImageDrawCircleLines(dstPtr, centerX, centerY, radius, color);
        }
    }

    /// <summary>
    ///     Draw circle outline within an image (Vector version)
    /// </summary>
    public static void DrawCircleLines(this ref Image dst, Vector2 center, int radius, Color color)
    {
        fixed (Image* dstPtr = &dst)
        {
            Raylib.ImageDrawCircleLinesV(dstPtr, center, radius, color);
        }
    }

    /// <summary>
    ///     Draw rectangle within an image
    /// </summary>
    public static void DrawRectangle(this ref Image dst, int x, int y, int width, int height, Color color)
    {
        Raylib.ImageDrawRectangle(ref dst, x, y, width, height, color);
    }

    /// <summary>
    ///     Draw rectangle within an image (Vector version)
    /// </summary>
    public static void DrawRectangle(this ref Image dst, Vector2 position, Vector2 size, Color color)
    {
        Raylib.ImageDrawRectangleV(ref dst, position, size, color);
    }

    /// <summary>
    ///     Draw rectangle within an image
    /// </summary>
    public static void DrawRectangle(this ref Image dst, Rectangle rectangle, Color color)
    {
        Raylib.ImageDrawRectangleRec(ref dst, rectangle, color);
    }

    /// <summary>
    ///     Draw rectangle lines within an image
    /// </summary>
    public static void DrawRectangleLines(this ref Image dst, Rectangle rectangle, int thick, Color color)
    {
        Raylib.ImageDrawRectangleLines(ref dst, rectangle, thick, color);
    }

    /// <summary>
    ///     Draw a source image within a destination image (tint applied to source)
    /// </summary>
    public static void DrawImage(this ref Image dst, Image src, Rectangle srcRect, Rectangle dstRect, Color tint)
    {
        Raylib.ImageDraw(ref dst, src, srcRect, dstRect, tint);
    }

    /// <summary>
    ///     Draw text (using default font) within an image (destination)
    /// </summary>
    public static void DrawText(this ref Image dst, string text, int x, int y, int fontSize, Color color)
    {
        Raylib.ImageDrawText(ref dst, text, x, y, fontSize, color);
    }

    // thank you raylib-cs for using int instead of float as fontSize argument ❤️❤️❤️
    /// <summary>
    ///     Draw text (custom sprite font) within an image (destination)
    /// </summary>
    public static void DrawText(this ref Image dst, Font font, string text, Vector2 position, int fontSize,
        float spacing, Color tint)
    {
        Raylib.ImageDrawTextEx(ref dst, font, text, position, fontSize, spacing, tint);
    }
}