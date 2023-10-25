namespace Raylib_cs.Extension.Core;

public static partial class VrStereoConfigEx
{
    public static void BeginMode(this VrStereoConfig config) => Raylib.BeginVrStereoMode(config);
    public static void EndMode(this VrStereoConfig config) => Raylib.EndVrStereoMode();
    public static void Unload(this VrStereoConfig config) => Raylib.UnloadVrStereoConfig(config);
}