using System.Runtime.InteropServices;

namespace Raylib_cs.Extensions;

public static partial class AudioStreamEx
{
    public static bool IsReady(this AudioStream stream) => Raylib.IsAudioStreamReady(stream);
    public static void Unload(this AudioStream stream) => Raylib.UnloadAudioStream(stream);

    public static unsafe void Update<T>(this AudioStream stream, ReadOnlySpan<T> data) where T : unmanaged
    { fixed (T* ptr = data) Raylib.UpdateAudioStream(stream, ptr, data.Length); }

    
    public static bool IsProcessed(this AudioStream stream)
        => Raylib.IsAudioStreamProcessed(stream);

    public static bool IsPlaying(this AudioStream stream)
        => Raylib.IsAudioStreamPlaying(stream);

    
    public static void Play(this AudioStream stream)
        => Raylib.PlayAudioStream(stream);

    public static void Stop(this AudioStream stream)
        => Raylib.StopAudioStream(stream);

    public static void Pause(this AudioStream stream)
        => Raylib.PauseAudioStream(stream);

    public static void Resume(this AudioStream stream)
        => Raylib.ResumeAudioStream(stream);


    public static void SetVolume(this AudioStream stream, float volume)
        => Raylib.SetAudioStreamVolume(stream, volume);

    public static void SetPitch(this AudioStream stream, float pitch)
        => Raylib.SetAudioStreamPitch(stream, pitch);

    public static void SetPan(this AudioStream stream, float pan)
        => Raylib.SetAudioStreamPan(stream, pan);
    
    // i need to find workarounds to make AudioCallback as separate delegate...
    
    public static unsafe void SetCallback(this AudioStream stream, delegate* unmanaged[Cdecl]<void*, uint, void> callback)
        => Raylib.SetAudioStreamCallback(stream, callback);

    
    public static unsafe void AttachProcessor(this AudioStream stream, delegate* unmanaged[Cdecl]<void*, uint, void> processor)
        => Raylib.AttachAudioStreamProcessor(stream, processor);

    public static unsafe void DetachProcessor(this AudioStream stream, delegate* unmanaged[Cdecl]<void*, uint, void> processor)
        => Raylib.DetachAudioStreamProcessor(stream, processor);
}