namespace Raylib_cs.Extensions;

public static partial class SoundEx
{
    /// <summary>
    /// Checks if a sound is ready
    /// </summary>
    public static bool IsReady(this Sound sound) => Raylib.IsSoundReady(sound);
    
    /// <summary>
    /// Unload sound
    /// </summary>
    public static void Unload(this Sound sound) => Raylib.UnloadSound(sound);

    
    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    public static unsafe void Update<T>(this Sound sound, ReadOnlySpan<T> data) where T : unmanaged
    { fixed (T* ptr = data) Raylib.UpdateSound(sound, ptr, data.Length); }
    
    /// <summary>
    /// Play a sound
    /// </summary>
    public static void Play(this Sound sound)
        => Raylib.PlaySound(sound);
    
    /// <summary>
    /// Stop playing a sound
    /// </summary>
    public static void Stop(this Sound sound)
        => Raylib.StopSound(sound);
    
    /// <summary>
    /// Pause a sound
    /// </summary>
    public static void Pause(this Sound sound)
        => Raylib.PauseSound(sound);
    
    /// <summary>
    /// Resume a paused sound
    /// </summary>
    public static void Resume(this Sound sound)
        => Raylib.ResumeSound(sound);
    
    /// <summary>
    /// Check if a sound is currently playing
    /// </summary>
    public static bool IsPlaying(this Sound sound)
        => Raylib.IsSoundPlaying(sound);

    
    /// <summary>
    /// Set volume for a sound (1.0 is max level)
    /// </summary>
    public static void SetVolume(this Sound sound, float volume)
        => Raylib.SetSoundVolume(sound, volume);
    
    /// <summary>
    /// Set pitch for a sound (1.0 is base level)
    /// </summary>
    public static void SetPitch(this Sound sound, float pitch)
        => Raylib.SetSoundPitch(sound, pitch);
    
    /// <summary>
    /// Set pan for a sound (0.5 is center)
    /// </summary>
    public static void SetPan(this Sound sound, float pan)
        => Raylib.SetSoundPan(sound, pan);
}