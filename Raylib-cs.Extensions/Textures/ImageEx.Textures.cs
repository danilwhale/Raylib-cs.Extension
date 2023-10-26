using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ImageEx
{
    public static Texture2D LoadTexture(this Image image) => Raylib.LoadTextureFromImage(image);
    public static Texture2D LoadCubemap(this Image image, CubemapLayout layout) => Raylib.LoadTextureCubemap(image, layout);
    
    
    public static bool IsReady(this Image image)
        => Raylib.IsImageReady(image);

    public static void Unload(this Image image)
        => Raylib.UnloadImage(image);

    public static bool Export(this Image image, string path)
        => Raylib.ExportImage(image, path);

    public static bool ExportAsCode(this Image image, string path)
        => Raylib.ExportImageAsCode(image, path);


    public static Image Copy(this Image image)
        => Raylib.ImageCopy(image);

    public static Image FromImage(this Image image, Rectangle rectangle)
        => Raylib.ImageFromImage(image, rectangle);


    public static void Format(this ref Image image, PixelFormat newFormat)
        => Raylib.ImageFormat(ref image, newFormat);

    public static void ToPOT(this ref Image image, Color fill)
        => Raylib.ImageToPOT(ref image, fill);

    public static void Crop(this ref Image image, Rectangle crop)
        => Raylib.ImageCrop(ref image, crop);

    public static void AlphaCrop(this ref Image image, float threshold)
        => Raylib.ImageAlphaCrop(ref image, threshold);

    public static void AlphaClear(this ref Image image, Color color, float threshold)
        => Raylib.ImageAlphaClear(ref image, color, threshold);

    public static void AlphaMask(this ref Image image, Image alphaMask)
        => Raylib.ImageAlphaMask(ref image, alphaMask);

    public static void AlphaPremultiply(this ref Image image)
        => Raylib.ImageAlphaPremultiply(ref image);

    public static void BlurGaussian(this ref Image image, int blurSize)
        => Raylib.ImageBlurGaussian(ref image, blurSize);

    public static void Resize(this ref Image image, int newWidth, int newHeight)
        => Raylib.ImageResize(ref image, newWidth, newHeight);

    public static void ResizeNearest(this ref Image image, int newWidth, int newHeight)
        => Raylib.ImageResizeNN(ref image, newWidth, newHeight);

    public static void ResizeCanvas(this ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill)
        => Raylib.ImageResizeCanvas(ref image, newWidth, newHeight, offsetX, offsetY, fill);

    public static void Mipmaps(this ref Image image)
        => Raylib.ImageMipmaps(ref image);

    public static void Dither(this ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
        => Raylib.ImageDither(ref image, rBpp, gBpp, bBpp, aBpp);

    public static void FlipVertical(this ref Image image)
        => Raylib.ImageFlipVertical(ref image);

    public static void FlipHorizontal(this ref Image image)
        => Raylib.ImageFlipHorizontal(ref image);

    public static void Rotate(this ref Image image, int degrees)
        => throw new NotImplementedException("ImageRotate is not implemented in raylib 4.5");

    public static void RotateCW(this ref Image image)
        => Raylib.ImageRotateCW(ref image);

    public static void RotateCCW(this ref Image image)
        => Raylib.ImageRotateCCW(ref image);

    public static void ColorTint(this ref Image image, Color tint)
        => Raylib.ImageColorTint(ref image, tint);

    public static void ColorInverse(this ref Image image)
        => Raylib.ImageColorInvert(ref image);

    public static void ColorGrayscale(this ref Image image)
        => Raylib.ImageColorGrayscale(ref image);

    public static void ColorContrast(this ref Image image, float contrast)
        => Raylib.ImageColorContrast(ref image, contrast);

    public static void ColorBrightness(this ref Image image, int brightness)
        => Raylib.ImageColorBrightness(ref image, brightness);

    public static void ColorReplace(this ref Image image, Color color, Color replace)
        => Raylib.ImageColorReplace(ref image, color, replace);


    public static unsafe Color[] GetColors(this Image image)
    {
        RlMemoryHandle colorsHandle = new RlMemoryHandle(Raylib.LoadImageColors(image), image.width * image.height * sizeof(Color));

        Color[] colors = new Color[image.width * image.height];
        colorsHandle.CopyTo<Color>(colors);
        
        Raylib.UnloadImageColors(colorsHandle.AsPtr<Color>());
        return colors;
    }

    public static unsafe Color[] GetColorPalette(this Image image, int maxPaletteSize)
    {
        int colorCount = 0;
        RlMemoryHandle paletteHandle = new RlMemoryHandle(Raylib.LoadImagePalette(image, maxPaletteSize, &colorCount), colorCount);

        Color[] palette = new Color[colorCount];
        paletteHandle.CopyTo<Color>(palette);
        
        Raylib.UnloadImagePalette(paletteHandle.AsPtr<Color>());
        return palette;
    }

    public static Rectangle GetAlphaBorder(this Image image, float threshold)
        => Raylib.GetImageAlphaBorder(image, threshold);

    public static Color GetColor(this Image image, int x, int y)
        => Raylib.GetImageColor(image, x, y);


    public static void ClearBackground(this ref Image dst, Color color)
        => Raylib.ImageClearBackground(ref dst, color);

    public static void DrawPixel(this ref Image dst, int x, int y, Color color)
        => Raylib.ImageDrawPixel(ref dst, x, y, color);

    public static void DrawPixel(this ref Image dst, Vector2 position, Color color)
        => Raylib.ImageDrawPixelV(ref dst, position, color);

    public static void DrawLine(this ref Image dst, int startX, int startY, int endX, int endY, Color color)
        => Raylib.ImageDrawLine(ref dst, startX, startY, endX, endY, color);

    public static void DrawLine(this ref Image dst, Vector2 start, Vector2 end, Color color)
        => Raylib.ImageDrawLineV(ref dst, start, end, color);

    public static void DrawCircle(this ref Image dst, int centerX, int centerY, int radius, Color color)
        => Raylib.ImageDrawCircle(ref dst, centerX, centerY, radius, color);

    public static void DrawCircle(this ref Image dst, Vector2 center, int radius, Color color)
        => Raylib.ImageDrawCircleV(ref dst, center, radius, color);
    
    public static unsafe void DrawCircleLines(this ref Image dst, int centerX, int centerY, int radius, Color color)
    { fixed (Image* dstPtr = &dst) Raylib.ImageDrawCircleLines(dstPtr, centerX, centerY, radius, color); }

    public static unsafe void DrawCircleLines(this ref Image dst, Vector2 center, int radius, Color color)
    { fixed (Image* dstPtr = &dst) Raylib.ImageDrawCircleLinesV(dstPtr, center, radius, color); }

    public static void DrawRectangle(this ref Image dst, int x, int y, int width, int height, Color color)
        => Raylib.ImageDrawRectangle(ref dst, x, y, width, height, color);

    public static void DrawRectangle(this ref Image dst, Vector2 position, Vector2 size, Color color)
        => Raylib.ImageDrawRectangleV(ref dst, position, size, color);

    public static void DrawRectangle(this ref Image dst, Rectangle rectangle, Color color)
        => Raylib.ImageDrawRectangleRec(ref dst, rectangle, color);

    public static void DrawRectangleLines(this ref Image dst, Rectangle rectangle, int thick, Color color)
        => Raylib.ImageDrawRectangleLines(ref dst, rectangle, thick, color);

    public static void DrawImage(this ref Image dst, Image src, Rectangle srcRect, Rectangle dstRect, Color tint)
        => Raylib.ImageDraw(ref dst, src, srcRect, dstRect, tint);

    public static void DrawText(this ref Image dst, string text, int x, int y, int fontSize, Color color)
        => Raylib.ImageDrawText(ref dst, text, x, y, fontSize, color);
    
    // thank you raylib-cs for using int instead of float as fontSize argument ❤️❤️❤️
    public static void DrawText(this ref Image dst, Font font, string text, Vector2 position, int fontSize, float spacing, Color tint)
        => Raylib.ImageDrawTextEx(ref dst, font, text, position, fontSize, spacing, tint);
}