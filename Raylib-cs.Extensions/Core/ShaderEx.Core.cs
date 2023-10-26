using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ShaderEx
{
    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    /// <param name="shader"></param>
    public static void BeginMode(this Shader shader) => Raylib.BeginShaderMode(shader);
    
    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    /// <param name="shader"></param>
    public static void EndMode(this Shader shader) => Raylib.EndShaderMode();
    
    /// <summary>
    /// Check if a shader is ready
    /// </summary>
    /// <param name="shader"></param>
    /// <returns></returns>
    public static bool IsReady(this Shader shader) => Raylib.IsShaderReady(shader);
    
    /// <summary>
    /// Get shader uniform location
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="uniformName"></param>
    /// <returns></returns>
    public static int GetLocation(this Shader shader, string uniformName) =>
        Raylib.GetShaderLocation(shader, uniformName);
    
    /// <summary>
    /// Get shader attribute location
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="attribName"></param>
    /// <returns></returns>
    public static int GetAttribLocation(this Shader shader, string attribName) =>
        Raylib.GetShaderLocationAttrib(shader, attribName);
    
    /// <summary>
    /// Set shader uniform value
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <param name="type"></param>
    /// <typeparam name="T"></typeparam>
    public static void SetValue<T>(this Shader shader, ShaderLocationIndex index, T value, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, (int)index, value, type);
    }
    
    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="index"></param>
    /// <param name="values"></param>
    /// <param name="type"></param>
    /// <typeparam name="T"></typeparam>
    public static void SetValue<T>(this Shader shader, ShaderLocationIndex index, Span<T> values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, (int)index, values, type);
    }
    
    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="index"></param>
    /// <param name="matrix"></param>
    public static void SetValue(this Shader shader, ShaderLocationIndex index, Matrix4x4 matrix)
    {
        Raylib.SetShaderValueMatrix(shader, (int)index, matrix);
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="index"></param>
    /// <param name="texture"></param>
    public static void SetValue(this Shader shader, ShaderLocationIndex index, Texture2D texture)
    {
        Raylib.SetShaderValueTexture(shader, (int)index, texture);
    }
    
    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    /// <param name="shader"></param>
    public static void Unload(this Shader shader) => Raylib.UnloadShader(shader);
}