namespace Raylib_cs.Extensions;

public static partial class WaveEx
{
    public static bool IsReady(this Wave wave) => Raylib.IsWaveReady(wave);
    public static void Unload(this Wave wave) => Raylib.UnloadWave(wave);
    
    
    public static Sound LoadSound(this Wave wave) 
        => Raylib.LoadSoundFromWave(wave);

    public static void Export(this Wave wave, string path)
        => Raylib.ExportWave(wave, path);

    public static void ExportAsCode(this Wave wave, string path)
        => Raylib.ExportWaveAsCode(wave, path);


    public static Wave Copy(this Wave wave)
        => Raylib.WaveCopy(wave);

    public static void Crop(this ref Wave wave, int initSample, int finalSample)
        => Raylib.WaveCrop(ref wave, initSample, finalSample);

    public static void Format(this ref Wave wave, int sampleRate, int sampleSize, int channels)
        => Raylib.WaveFormat(ref wave, sampleRate, sampleSize, channels);


    public static unsafe float[] GetSamples(this Wave wave)
    {
        RlMemoryHandle samplesHandle = new RlMemoryHandle(Raylib.LoadWaveSamples(wave), (int)wave.sampleCount);

        float[] samples = new float[wave.sampleCount];
        samplesHandle.CopyTo<float>(samples);
        
        Raylib.UnloadWaveSamples(samplesHandle.AsPtr<float>());

        return samples;
    }
}