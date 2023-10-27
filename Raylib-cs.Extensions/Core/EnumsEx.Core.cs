namespace Raylib_cs.Extensions;

public static partial class EnumsEx
{
    public static bool IsWindowState(this ConfigFlags flag) => Raylib.IsWindowState(flag);
    public static void SetWindowState(this ConfigFlags flags) => Raylib.SetWindowState(flags);
    public static void RemoveWindowState(this ConfigFlags flags) => Raylib.ClearWindowState(flags);
    public static void SetExitKey(this KeyboardKey key) => Raylib.SetExitKey(key);
}