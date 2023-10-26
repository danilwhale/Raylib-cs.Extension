namespace Raylib_cs.Extensions;

public static partial class MusicEx
{
    /// <summary>
    /// Checks if a music stream is ready
    /// </summary>
    /// <param name="music"></param>
    /// <returns></returns>
    public static bool IsReady(this Music music) => Raylib.IsMusicReady(music);
    
    /// <summary>
    /// Unload music stream
    /// </summary>
    /// <param name="music"></param>
    public static void Unload(this Music music) => Raylib.UnloadMusicStream(music);

    
    /// <summary>
    /// Start music playing
    /// </summary>
    /// <param name="music"></param>
    public static void Play(this Music music)
        => Raylib.PlayMusicStream(music);
    
    /// <summary>
    /// Check if music is playing   
    /// </summary>
    /// <param name="music"></param>
    /// <returns></returns>
    public static bool IsPlaying(this Music music)
        => Raylib.IsMusicStreamPlaying(music);
    
    /// <summary>
    /// Stop music playing
    /// </summary>
    /// <param name="music"></param>
    public static void Stop(this Music music)
        => Raylib.StopMusicStream(music);
    
    /// <summary>
    /// Pause music playing
    /// </summary>
    /// <param name="music"></param>
    public static void Pause(this Music music)
        => Raylib.PauseMusicStream(music);
    
    /// <summary>
    /// Resume playing paused music
    /// </summary>
    /// <param name="music"></param>
    public static void Resume(this Music music)
        => Raylib.ResumeMusicStream(music);
    
    
    /// <summary>
    /// Updates buffers for music streaming
    /// </summary>
    /// <param name="music"></param>
    public static void Update(this Music music)
        => Raylib.UpdateMusicStream(music);

    
    /// <summary>
    /// Seek music to a position (in seconds)
    /// </summary>
    /// <param name="music"></param>
    /// <param name="position"></param>
    public static void Seek(this Music music, float position)
        => Raylib.SeekMusicStream(music, position);
    
    /// <summary>
    /// Set volume for music (1.0 is max level)
    /// </summary>
    /// <param name="music"></param>
    /// <param name="volume"></param>
    public static void SetVolume(this Music music, float volume)
        => Raylib.SetMusicVolume(music, volume);
    
    /// <summary>
    /// Set pitch for a music (1.0 is base level)
    /// </summary>
    /// <param name="music"></param>
    /// <param name="pitch"></param>
    public static void SetPitch(this Music music, float pitch)
        => Raylib.SetMusicPitch(music, pitch);
    
    /// <summary>
    /// Set pan for a music (0.5 is center)
    /// </summary>
    /// <param name="music"></param>
    /// <param name="pan"></param>
    public static void SetPan(this Music music, float pan)
        => Raylib.SetMusicPan(music, pan);

    
    /// <summary>
    /// Get music time length (in seconds)
    /// </summary>
    /// <param name="music"></param>
    /// <returns></returns>
    public static float GetTimeLength(this Music music)
        => Raylib.GetMusicTimeLength(music);
    
    /// <summary>
    /// Get current music time played (in seconds)
    /// </summary>
    /// <param name="music"></param>
    /// <returns></returns>
    public static float GetTimePlayed(this Music music)
        => Raylib.GetMusicTimePlayed(music);
}