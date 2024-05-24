namespace Raylib_cs.Extensions;

public static class VrDeviceInfoEx
{
    /// <summary>
    ///     Load VR stereo config for VR simulator device parameters
    /// </summary>
    public static VrStereoConfig LoadConfig(this VrDeviceInfo device)
    {
        return Raylib.LoadVrStereoConfig(device);
    }
}