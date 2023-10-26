namespace Raylib_cs.Extensions;

public static partial class VrDeviceInfoEx
{
    /// <summary>
    /// Load VR stereo config for VR simulator device parameters
    /// </summary>
    public static VrStereoConfig LoadConfig(this VrDeviceInfo device) => Raylib.LoadVrStereoConfig(device);
}