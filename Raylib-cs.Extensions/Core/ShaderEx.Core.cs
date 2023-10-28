using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class ShaderEx
{
    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    public static void BeginMode(this Shader shader) => Raylib.BeginShaderMode(shader);
    
    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    public static void EndMode(this Shader shader) => Raylib.EndShaderMode();
    
    /// <summary>
    /// Check if a shader is ready
    /// </summary>
    public static bool IsReady(this Shader shader) => Raylib.IsShaderReady(shader);
    
    /// <summary>
    /// Get shader uniform location
    /// </summary>
    public static int GetLocation(this Shader shader, string uniformName) =>
        Raylib.GetShaderLocation(shader, uniformName);
    
    /// <summary>
    /// Get shader attribute location
    /// </summary>
    public static int GetAttribLocation(this Shader shader, string attribName) =>
        Raylib.GetShaderLocationAttrib(shader, attribName);
    
    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public static void SetValue<T>(this Shader shader, ShaderLocationIndex index, T value, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, (int)index, value, type);
    }
    
    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetValue<T>(this Shader shader, ShaderLocationIndex index, Span<T> values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, (int)index, values, type);
    }
    
    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static unsafe void SetValue<T>(this Shader shader, ShaderLocationIndex index, T* values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, (int)index, values, type);
    }
    
    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public static void SetValue(this Shader shader, ShaderLocationIndex index, Matrix4x4 matrix)
    {
        Raylib.SetShaderValueMatrix(shader, (int)index, matrix);
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    public static void SetValue(this Shader shader, ShaderLocationIndex index, Texture2D texture)
    {
        Raylib.SetShaderValueTexture(shader, (int)index, texture);
    }
    
    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public static void SetValue<T>(this Shader shader, int index, T value, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, index, value, type);
    }
    
    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetValue<T>(this Shader shader, int index, Span<T> values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, index, values, type);
    }
    
    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static unsafe void SetValue<T>(this Shader shader, int index, T* values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, index, values, type);
    }
    
    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public static void SetValue(this Shader shader, int index, Matrix4x4 matrix)
    {
        Raylib.SetShaderValueMatrix(shader, index, matrix);
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    public static void SetValue(this Shader shader, int index, Texture2D texture)
    {
        Raylib.SetShaderValueTexture(shader, index, texture);
    }
    
    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public static void SetValue<T>(this Shader shader, string uniformName, T value, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, shader.GetLocation(uniformName), value, type);
    }
    
    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetValue<T>(this Shader shader, string uniformName, Span<T> values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, shader.GetLocation(uniformName), values, type);
    }
    
    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static unsafe void SetValue<T>(this Shader shader, string uniformName, T* values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, shader.GetLocation(uniformName), values, type);
    }
    
    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public static void SetValue(this Shader shader, string uniformName, Matrix4x4 matrix)
    {
        Raylib.SetShaderValueMatrix(shader, shader.GetLocation(uniformName), matrix);
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    public static void SetValue(this Shader shader, string uniformName, Texture2D texture)
    {
        Raylib.SetShaderValueTexture(shader, shader.GetLocation(uniformName), texture);
    }
    
    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    public static void Unload(this Shader shader) => Raylib.UnloadShader(shader);
}