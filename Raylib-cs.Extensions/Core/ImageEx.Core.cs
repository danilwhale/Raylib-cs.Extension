namespace Raylib_cs.Extensions;

public static partial class ImageEx
{
    public static void SetWindowIcon(this Image image)
    {
        Raylib.SetWindowIcon(image);
    }

    public static unsafe void SetWindowIcons(this Image[] images)
    {
        fixed (Image* icons = images)
        {
            Raylib.SetWindowIcons(icons, images.Length);
        }
    }
}