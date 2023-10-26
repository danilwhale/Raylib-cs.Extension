namespace Raylib_cs.Extensions;

public static partial class SoundEx
{
    public static bool IsReady(this Sound sound) => Raylib.IsSoundReady(sound);
    public static void Unload(this Sound sound) => Raylib.UnloadSound(sound);


    public static unsafe void Update<T>(this Sound sound, ReadOnlySpan<T> data) where T : unmanaged
    { fixed (T* ptr = data) Raylib.UpdateSound(sound, ptr, data.Length); }

    public static void Play(this Sound sound)
        => Raylib.PlaySound(sound);

    public static void Stop(this Sound sound)
        => Raylib.StopSound(sound);

    public static void Pause(this Sound sound)
        => Raylib.PauseSound(sound);

    public static void Resume(this Sound sound)
        => Raylib.ResumeSound(sound);

    public static bool IsPlaying(this Sound sound)
        => Raylib.IsSoundPlaying(sound);


    public static void SetVolume(this Sound sound, float volume)
        => Raylib.SetSoundVolume(sound, volume);

    public static void SetPitch(this Sound sound, float pitch)
        => Raylib.SetSoundPitch(sound, pitch);

    public static void SetPan(this Sound sound, float pan)
        => Raylib.SetSoundPan(sound, pan);
    
    
}