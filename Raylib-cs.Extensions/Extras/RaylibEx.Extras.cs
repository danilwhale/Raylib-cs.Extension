using System.Runtime.InteropServices;

namespace Raylib_cs.Extensions;

public static partial class RaylibEx
{
    // if anyone have idea how to implement method for casting c# delegate to c delegate
    // please make pull request 🥺🥺🥺

    public static unsafe void SetTraceLogCallback(TraceLogCallback callback)
    {
        var ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>)ptr; // cast pointer to raylib delegate

        Raylib.SetTraceLogCallback(rlDelegate);
    }

    public static unsafe void SetLoadFileDataCallback(LoadFileDataCallback callback)
    {
        var ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>)ptr; // cast pointer to raylib delegate

        Raylib.SetLoadFileDataCallback(rlDelegate);
    }

    public static unsafe void SetSaveFileDataCallback(SaveFileDataCallback callback)
    {
        var ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, void*, uint, CBool>)ptr; // cast pointer to raylib delegate

        Raylib.SetSaveFileDataCallback(rlDelegate);
    }

    public static unsafe void SetLoadFileTextCallback(LoadFileTextCallback callback)
    {
        var ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, sbyte*>)ptr; // cast pointer to raylib delegate

        Raylib.SetLoadFileTextCallback(rlDelegate);
    }

    public static unsafe void SetSaveFileTextCallback(SaveFileTextCallback callback)
    {
        var ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, sbyte*, CBool>)ptr; // cast pointer to raylib delegate

        Raylib.SetSaveFileTextCallback(rlDelegate);
    }

    public static unsafe string[] GetFiles(this FilePathList list)
    {
        var files = new string[list.Count];

        for (var i = 0; i < list.Count; i++)
        {
            var pathRaw = list.Paths[i];
            var path = Marshal.PtrToStringAnsi((IntPtr)pathRaw) ?? string.Empty;

            files[i] = path;
        }

        return files;
    }

    public static unsafe int[] GetRandomSequence(int count, int min, int max)
    {
        var sequence = new int[count];
        var rlSequence = Raylib.LoadRandomSequence(count, min, max);

        fixed (int* pSequence = sequence)
        {
            Buffer.MemoryCopy(rlSequence, pSequence, count * sizeof(int), count * sizeof(int));
        }

        Raylib.UnloadRandomSequence(rlSequence);

        return sequence;
    }
}