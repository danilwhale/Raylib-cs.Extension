namespace Raylib_cs.Extensions;

public static partial class MusicEx
{
    public static bool IsReady(this Music music) => Raylib.IsMusicReady(music);
    public static void Unload(this Music music) => Raylib.UnloadMusicStream(music);


    public static void Play(this Music music)
        => Raylib.PlayMusicStream(music);

    public static bool IsPlaying(this Music music)
        => Raylib.IsMusicStreamPlaying(music);

    public static void Stop(this Music music)
        => Raylib.StopMusicStream(music);

    public static void Pause(this Music music)
        => Raylib.PauseMusicStream(music);

    public static void Resume(this Music music)
        => Raylib.ResumeMusicStream(music);
    
    
    public static void Update(this Music music)
        => Raylib.UpdateMusicStream(music);


    public static void Seek(this Music music, float position)
        => Raylib.SeekMusicStream(music, position);

    public static void SetVolume(this Music music, float volume)
        => Raylib.SetMusicVolume(music, volume);

    public static void SetPitch(this Music music, float pitch)
        => Raylib.SetMusicPitch(music, pitch);

    public static void SetPan(this Music music, float pan)
        => Raylib.SetMusicPan(music, pan);


    public static float GetTimeLength(this Music music)
        => Raylib.GetMusicTimeLength(music);

    public static float GetTimePlayed(this Music music)
        => Raylib.GetMusicTimePlayed(music);
}