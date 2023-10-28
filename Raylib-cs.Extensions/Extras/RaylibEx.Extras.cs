using System.Runtime.InteropServices;

namespace Raylib_cs.Extensions;

public static partial class RaylibEx
{
    // if anyone have idea how to implement method for casting c# delegate to c delegate
    // please make pull request 🥺🥺🥺
    
    public static unsafe void SetTraceLogCallback(TraceLogCallback callback)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>) ptr; // cast pointer to raylib delegate

        Raylib.SetTraceLogCallback(rlDelegate);
    }

    public static unsafe void SetLoadFileDataCallback(LoadFileDataCallback callback)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>) ptr; // cast pointer to raylib delegate

        Raylib.SetLoadFileDataCallback(rlDelegate);
    }

    public static unsafe void SetSaveFileDataCallback(SaveFileDataCallback callback)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, void*, uint, CBool>) ptr; // cast pointer to raylib delegate

        Raylib.SetSaveFileDataCallback(rlDelegate);
    }
    
    public static unsafe void SetLoadFileTextCallback(LoadFileTextCallback callback)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, sbyte*>) ptr; // cast pointer to raylib delegate

        Raylib.SetLoadFileTextCallback(rlDelegate);
    }

    public static unsafe void SetSaveFileTextCallback(SaveFileTextCallback callback)
    {
        nint ptr = Marshal.GetFunctionPointerForDelegate(callback); // get pointer to callback
        var rlDelegate = (delegate* unmanaged[Cdecl]<sbyte*, sbyte*, CBool>) ptr; // cast pointer to raylib delegate

        Raylib.SetSaveFileTextCallback(rlDelegate);
    }

    public static unsafe string[] GetFiles(FilePathList list)
    {
        string[] files = new string[list.count];
        
        for (int i = 0; i < list.count; i++)
        {
            byte* pathRaw = list.paths[i];
            string path = Marshal.PtrToStringAnsi((IntPtr)pathRaw) ?? string.Empty;

            files[i] = path;
        }

        return files;
    }
}