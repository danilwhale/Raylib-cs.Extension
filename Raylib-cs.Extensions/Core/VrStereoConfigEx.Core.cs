namespace Raylib_cs.Extensions;

public static partial class VrStereoConfigEx
{
    /// <summary>
    /// Begin stereo rendering (requires VR simulator)
    /// </summary>
    public static void BeginMode(this VrStereoConfig config) => Raylib.BeginVrStereoMode(config);
    
    /// <summary>
    /// End stereo rendering (requires VR simulator)
    /// </summary>
    public static void EndMode(this VrStereoConfig config) => Raylib.EndVrStereoMode();
    
    /// <summary>
    /// Unload VR stereo config
    /// </summary>
    public static void Unload(this VrStereoConfig config) => Raylib.UnloadVrStereoConfig(config);
}