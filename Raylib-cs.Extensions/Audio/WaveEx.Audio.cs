namespace Raylib_cs.Extensions;

public static partial class WaveEx
{
    /// <summary>
    /// Checks if wave data is ready
    /// </summary>
    public static bool IsReady(this Wave wave) => Raylib.IsWaveReady(wave);
    
    /// <summary>
    /// Unload wave data
    /// </summary>
    public static void Unload(this Wave wave) => Raylib.UnloadWave(wave);
    
    
    /// <summary>
    /// Load sound from wave data
    /// </summary>
    public static Sound LoadSound(this Wave wave) 
        => Raylib.LoadSoundFromWave(wave);
    
    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    public static void Export(this Wave wave, string path)
        => Raylib.ExportWave(wave, path);
    
    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public static void ExportAsCode(this Wave wave, string path)
        => Raylib.ExportWaveAsCode(wave, path);
    
    /// <summary>
    /// Copy a wave to a new wave
    /// </summary>
    public static Wave Copy(this Wave wave)
        => Raylib.WaveCopy(wave);
    
    /// <summary>
    /// Crop a wave to defined samples range
    /// </summary>
    public static void Crop(this ref Wave wave, int initSample, int finalSample)
        => Raylib.WaveCrop(ref wave, initSample, finalSample);
    
    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    public static void Format(this ref Wave wave, int sampleRate, int sampleSize, int channels)
        => Raylib.WaveFormat(ref wave, sampleRate, sampleSize, channels);

    /// <summary>
    /// Get samples data from wave as a 32bit float data array
    /// </summary>
    public static unsafe float[] GetSamples(this Wave wave)
    {
        RlMemoryHandle samplesHandle = new RlMemoryHandle(Raylib.LoadWaveSamples(wave), (int)wave.sampleCount);

        float[] samples = new float[wave.sampleCount];
        samplesHandle.CopyTo<float>(samples);
        
        Raylib.UnloadWaveSamples(samplesHandle.AsPtr<float>());

        return samples;
    }
}