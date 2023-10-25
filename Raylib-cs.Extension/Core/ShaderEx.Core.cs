using System.Numerics;

namespace Raylib_cs.Extension;

public static partial class ShaderEx
{
    public static void BeginMode(this Shader shader) => Raylib.BeginShaderMode(shader);
    public static void EndMode(this Shader shader) => Raylib.EndShaderMode();
    public static bool IsReady(this Shader shader) => Raylib.IsShaderReady(shader);

    public static int GetLocation(this Shader shader, string uniformName) =>
        Raylib.GetShaderLocation(shader, uniformName);

    public static int GetAttribLocation(this Shader shader, string attribName) =>
        Raylib.GetShaderLocationAttrib(shader, attribName);

    public static void SetValue<T>(this Shader shader, ShaderLocationIndex index, T value, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, (int)index, value, type);
    }

    public static void SetValue<T>(this Shader shader, ShaderLocationIndex index, Span<T> values, ShaderUniformDataType type)
        where T : unmanaged
    {
        Raylib.SetShaderValue(shader, (int)index, values, type);
    }

    public static void SetValue(this Shader shader, ShaderLocationIndex index, Matrix4x4 matrix)
    {
        Raylib.SetShaderValueMatrix(shader, (int)index, matrix);
    }

    public static void SetValue(this Shader shader, ShaderLocationIndex index, Texture2D texture)
    {
        Raylib.SetShaderValueTexture(shader, (int)index, texture);
    }

    public static void Unload(this Shader shader) => Raylib.UnloadShader(shader);
}