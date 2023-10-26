using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ImageEx
{
    /// <summary>
    /// Load texture from image data
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static Texture2D LoadTexture(this Image image) => Raylib.LoadTextureFromImage(image);
    
    /// <summary>
    /// Load cubemap from image, multiple image cubemap layouts supported
    /// </summary>
    /// <param name="image"></param>
    /// <param name="layout"></param>
    /// <returns></returns>
    public static Texture2D LoadCubemap(this Image image, CubemapLayout layout) => Raylib.LoadTextureCubemap(image, layout);
    
    /// <summary>
    /// Check if an image is ready
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static bool IsReady(this Image image)
        => Raylib.IsImageReady(image);
    
    /// <summary>
    /// Unload image from CPU memory (RAM)
    /// </summary>
    /// <param name="image"></param>
    public static void Unload(this Image image)
        => Raylib.UnloadImage(image);
    
    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    /// <param name="image"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool Export(this Image image, string path)
        => Raylib.ExportImage(image, path);
    
    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    /// <param name="image"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool ExportAsCode(this Image image, string path)
        => Raylib.ExportImageAsCode(image, path);

    /// <summary>
    /// Create an image duplicate (useful for transformations)
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static Image Copy(this Image image)
        => Raylib.ImageCopy(image);
    
    /// <summary>
    /// Create an image from another image piece
    /// </summary>
    /// <param name="image"></param>
    /// <param name="rectangle"></param>
    /// <returns></returns>
    public static Image FromImage(this Image image, Rectangle rectangle)
        => Raylib.ImageFromImage(image, rectangle);

    
    /// <summary>
    /// Convert image data to desired format
    /// </summary>
    /// <param name="image"></param>
    /// <param name="newFormat"></param>
    public static void Format(this ref Image image, PixelFormat newFormat)
        => Raylib.ImageFormat(ref image, newFormat);
    
    /// <summary>
    /// Convert image to POT (power-of-two)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="fill"></param>
    public static void ToPOT(this ref Image image, Color fill)
        => Raylib.ImageToPOT(ref image, fill);
    
    /// <summary>
    /// Crop an image to a defined rectangle
    /// </summary>
    /// <param name="image"></param>
    /// <param name="crop"></param>
    public static void Crop(this ref Image image, Rectangle crop)
        => Raylib.ImageCrop(ref image, crop);
    
    /// <summary>
    /// Crop image depending on alpha value
    /// </summary>
    /// <param name="image"></param>
    /// <param name="threshold"></param>
    public static void AlphaCrop(this ref Image image, float threshold)
        => Raylib.ImageAlphaCrop(ref image, threshold);
    
    /// <summary>
    /// Clear alpha channel to desired color
    /// </summary>
    /// <param name="image"></param>
    /// <param name="color"></param>
    /// <param name="threshold"></param>
    public static void AlphaClear(this ref Image image, Color color, float threshold)
        => Raylib.ImageAlphaClear(ref image, color, threshold);

    /// <summary>
    /// Apply alpha mask to image
    /// </summary>
    /// <param name="image"></param>
    /// <param name="alphaMask"></param>
    public static void AlphaMask(this ref Image image, Image alphaMask)
        => Raylib.ImageAlphaMask(ref image, alphaMask);
    
    /// <summary>
    /// Premultiply alpha channel
    /// </summary>
    /// <param name="image"></param>
    public static void AlphaPremultiply(this ref Image image)
        => Raylib.ImageAlphaPremultiply(ref image);
    
    /// <summary>
    /// Apply Gaussian blur using a box blur approximation
    /// </summary>
    /// <param name="image"></param>
    /// <param name="blurSize"></param>
    public static void BlurGaussian(this ref Image image, int blurSize)
        => Raylib.ImageBlurGaussian(ref image, blurSize);
    
    /// <summary>
    /// Resize image (Bicubic scaling algorithm)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="newWidth"></param>
    /// <param name="newHeight"></param>
    public static void Resize(this ref Image image, int newWidth, int newHeight)
        => Raylib.ImageResize(ref image, newWidth, newHeight);
    
    /// <summary>
    /// Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="newWidth"></param>
    /// <param name="newHeight"></param>
    public static void ResizeNearest(this ref Image image, int newWidth, int newHeight)
        => Raylib.ImageResizeNN(ref image, newWidth, newHeight);
    
    /// <summary>
    /// Resize canvas and fill with color
    /// </summary>
    /// <param name="image"></param>
    /// <param name="newWidth"></param>
    /// <param name="newHeight"></param>
    /// <param name="offsetX"></param>
    /// <param name="offsetY"></param>
    /// <param name="fill"></param>
    public static void ResizeCanvas(this ref Image image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill)
        => Raylib.ImageResizeCanvas(ref image, newWidth, newHeight, offsetX, offsetY, fill);
    
    /// <summary>
    /// Compute all mipmap levels for a provided image
    /// </summary>
    /// <param name="image"></param>
    public static void Mipmaps(this ref Image image)
        => Raylib.ImageMipmaps(ref image);
    
    /// <summary>
    /// Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="rBpp"></param>
    /// <param name="gBpp"></param>
    /// <param name="bBpp"></param>
    /// <param name="aBpp"></param>
    public static void Dither(this ref Image image, int rBpp, int gBpp, int bBpp, int aBpp)
        => Raylib.ImageDither(ref image, rBpp, gBpp, bBpp, aBpp);
    
    /// <summary>
    /// Flip image vertically
    /// </summary>
    /// <param name="image"></param>
    public static void FlipVertical(this ref Image image)
        => Raylib.ImageFlipVertical(ref image);
    
    /// <summary>
    /// Flip image horizontally
    /// </summary>
    /// <param name="image"></param>
    public static void FlipHorizontal(this ref Image image)
        => Raylib.ImageFlipHorizontal(ref image);
    
    /// <summary>
    /// NOT IMPLEMENTED ON RAYLIB-CS (raylib 4.5) <br/>
    /// WILL THROW NotImplementedException <br/>
    /// ---- <br/>
    /// Rotate image by input angle in degrees (-359 to 359) 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="degrees"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void Rotate(this ref Image image, int degrees)
        => throw new NotImplementedException("ImageRotate is not implemented in raylib 4.5");
    
    /// <summary>
    /// Rotate image clockwise 90deg
    /// </summary>
    /// <param name="image"></param>
    public static void RotateCW(this ref Image image)
        => Raylib.ImageRotateCW(ref image);
    
    /// <summary>
    /// Rotate image counter-clockwise 90deg
    /// </summary>
    /// <param name="image"></param>
    public static void RotateCCW(this ref Image image)
        => Raylib.ImageRotateCCW(ref image);
    
    /// <summary>
    /// Modify image color: tint
    /// </summary>
    /// <param name="image"></param>
    /// <param name="tint"></param>
    public static void ColorTint(this ref Image image, Color tint)
        => Raylib.ImageColorTint(ref image, tint);

    /// <summary>
    /// Modify image color: invert
    /// </summary>
    /// <param name="image"></param>
    public static void ColorInverse(this ref Image image)
        => Raylib.ImageColorInvert(ref image);
    
    /// <summary>
    /// Modify image color: grayscale
    /// </summary>
    /// <param name="image"></param>
    public static void ColorGrayscale(this ref Image image)
        => Raylib.ImageColorGrayscale(ref image);
    
    /// <summary>
    /// Modify image color: contrast (-100 to 100)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="contrast"></param>
    public static void ColorContrast(this ref Image image, float contrast)
        => Raylib.ImageColorContrast(ref image, contrast);
    
    /// <summary>
    /// Modify image color: brightness (-255 to 255)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="brightness"></param>
    public static void ColorBrightness(this ref Image image, int brightness)
        => Raylib.ImageColorBrightness(ref image, brightness);
    
    /// <summary>
    /// Modify image color: replace color
    /// </summary>
    /// <param name="image"></param>
    /// <param name="color"></param>
    /// <param name="replace"></param>
    public static void ColorReplace(this ref Image image, Color color, Color replace)
        => Raylib.ImageColorReplace(ref image, color, replace);

    /// <summary>
    /// Get color data from image as a Color array (RGBA - 32bit)
    /// (replacement for Load/UnloadColors)
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static unsafe Color[] GetColors(this Image image)
    {
        RlMemoryHandle colorsHandle = new RlMemoryHandle(Raylib.LoadImageColors(image), image.width * image.height * sizeof(Color));

        Color[] colors = new Color[image.width * image.height];
        colorsHandle.CopyTo<Color>(colors);
        
        Raylib.UnloadImageColors(colorsHandle.AsPtr<Color>());
        return colors;
    }
    
    /// <summary>
    /// Get colors palette from image as a Color array (RGBA - 32bit)
    /// (replacement for Load/UnloadColors)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="maxPaletteSize"></param>
    /// <returns></returns>
    public static unsafe Color[] GetColorPalette(this Image image, int maxPaletteSize)
    {
        int colorCount = 0;
        RlMemoryHandle paletteHandle = new RlMemoryHandle(Raylib.LoadImagePalette(image, maxPaletteSize, &colorCount), colorCount);

        Color[] palette = new Color[colorCount];
        paletteHandle.CopyTo<Color>(palette);
        
        Raylib.UnloadImagePalette(paletteHandle.AsPtr<Color>());
        return palette;
    }
    
    /// <summary>
    /// Get image alpha border rectangle
    /// </summary>
    /// <param name="image"></param>
    /// <param name="threshold"></param>
    /// <returns></returns>
    public static Rectangle GetAlphaBorder(this Image image, float threshold)
        => Raylib.GetImageAlphaBorder(image, threshold);
    
    /// <summary>
    /// Get image pixel color at (x, y) position
    /// </summary>
    /// <param name="image"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static Color GetColor(this Image image, int x, int y)
        => Raylib.GetImageColor(image, x, y);

    
    /// <summary>
    /// Clear image background with given color
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="color"></param>
    public static void ClearBackground(this ref Image dst, Color color)
        => Raylib.ImageClearBackground(ref dst, color);
    
    /// <summary>
    /// Draw pixel within an image
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    public static void DrawPixel(this ref Image dst, int x, int y, Color color)
        => Raylib.ImageDrawPixel(ref dst, x, y, color);
    
    /// <summary>
    /// Draw pixel within an image (Vector version)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="position"></param>
    /// <param name="color"></param>
    public static void DrawPixel(this ref Image dst, Vector2 position, Color color)
        => Raylib.ImageDrawPixelV(ref dst, position, color);
    
    /// <summary>
    /// Draw line within an image
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="startX"></param>
    /// <param name="startY"></param>
    /// <param name="endX"></param>
    /// <param name="endY"></param>
    /// <param name="color"></param>
    public static void DrawLine(this ref Image dst, int startX, int startY, int endX, int endY, Color color)
        => Raylib.ImageDrawLine(ref dst, startX, startY, endX, endY, color);
    
    /// <summary>
    /// Draw line within an image (Vector version)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="color"></param>
    public static void DrawLine(this ref Image dst, Vector2 start, Vector2 end, Color color)
        => Raylib.ImageDrawLineV(ref dst, start, end, color);
    
    /// <summary>
    /// Draw a filled circle within an image
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="radius"></param>
    /// <param name="color"></param>
    public static void DrawCircle(this ref Image dst, int centerX, int centerY, int radius, Color color)
        => Raylib.ImageDrawCircle(ref dst, centerX, centerY, radius, color);
    
    /// <summary>
    /// Draw a filled circle within an image (Vector version)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="color"></param>
    public static void DrawCircle(this ref Image dst, Vector2 center, int radius, Color color)
        => Raylib.ImageDrawCircleV(ref dst, center, radius, color);
    
    /// <summary>
    /// Draw circle outline within an image
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="centerX"></param>
    /// <param name="centerY"></param>
    /// <param name="radius"></param>
    /// <param name="color"></param>
    public static unsafe void DrawCircleLines(this ref Image dst, int centerX, int centerY, int radius, Color color)
    { fixed (Image* dstPtr = &dst) Raylib.ImageDrawCircleLines(dstPtr, centerX, centerY, radius, color); }
    
    /// <summary>
    /// Draw circle outline within an image (Vector version)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="color"></param>
    public static unsafe void DrawCircleLines(this ref Image dst, Vector2 center, int radius, Color color)
    { fixed (Image* dstPtr = &dst) Raylib.ImageDrawCircleLinesV(dstPtr, center, radius, color); }
    
    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="color"></param>
    public static void DrawRectangle(this ref Image dst, int x, int y, int width, int height, Color color)
        => Raylib.ImageDrawRectangle(ref dst, x, y, width, height, color);
    
    /// <summary>
    /// Draw rectangle within an image (Vector version)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="position"></param>
    /// <param name="size"></param>
    /// <param name="color"></param>
    public static void DrawRectangle(this ref Image dst, Vector2 position, Vector2 size, Color color)
        => Raylib.ImageDrawRectangleV(ref dst, position, size, color);
    
    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="rectangle"></param>
    /// <param name="color"></param>
    public static void DrawRectangle(this ref Image dst, Rectangle rectangle, Color color)
        => Raylib.ImageDrawRectangleRec(ref dst, rectangle, color);
    
    /// <summary>
    /// Draw rectangle lines within an image
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="rectangle"></param>
    /// <param name="thick"></param>
    /// <param name="color"></param>
    public static void DrawRectangleLines(this ref Image dst, Rectangle rectangle, int thick, Color color)
        => Raylib.ImageDrawRectangleLines(ref dst, rectangle, thick, color);
    
    /// <summary>
    /// Draw a source image within a destination image (tint applied to source)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="src"></param>
    /// <param name="srcRect"></param>
    /// <param name="dstRect"></param>
    /// <param name="tint"></param>
    public static void DrawImage(this ref Image dst, Image src, Rectangle srcRect, Rectangle dstRect, Color tint)
        => Raylib.ImageDraw(ref dst, src, srcRect, dstRect, tint);
    
    /// <summary>
    /// Draw text (using default font) within an image (destination)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="text"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="fontSize"></param>
    /// <param name="color"></param>
    public static void DrawText(this ref Image dst, string text, int x, int y, int fontSize, Color color)
        => Raylib.ImageDrawText(ref dst, text, x, y, fontSize, color);
    
    // thank you raylib-cs for using int instead of float as fontSize argument ❤️❤️❤️
    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="font"></param>
    /// <param name="text"></param>
    /// <param name="position"></param>
    /// <param name="fontSize"></param>
    /// <param name="spacing"></param>
    /// <param name="tint"></param>
    public static void DrawText(this ref Image dst, Font font, string text, Vector2 position, int fontSize, float spacing, Color tint)
        => Raylib.ImageDrawTextEx(ref dst, font, text, position, fontSize, spacing, tint);
}