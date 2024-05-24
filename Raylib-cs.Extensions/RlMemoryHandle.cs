namespace Raylib_cs.Extensions;

/// <summary>
///     Structure to handle memory allocated from raylib, releases pointer on Dispose
/// </summary>
public struct RlMemoryHandle : IDisposable
{
    /// <summary>
    ///     Handle to unmanaged raylib pointer
    /// </summary>
    public readonly nint Handle;

    /// <summary>
    ///     Size of raylib pointer
    /// </summary>
    public int Size
    {
        get => _Size;
        set
        {
            _Size = value;
            Reallocate(value);
        }
    }

    private int _Size;

    /// <summary>
    ///     Allocate memory for pointer using MemAlloc and create RlMemoryHandle
    /// </summary>
    /// <param name="size">Bytes to allocate</param>
    /// <exception cref="ArgumentException">Thrown if size is 0 or negative</exception>
    public unsafe RlMemoryHandle(int size)
    {
        if (size <= 0) throw new ArgumentException("Memory size couldn't be negative or zero", nameof(size));
        Handle = (nint)Raylib.MemAlloc(size);
        _Size = size;
    }

    /// <summary>
    ///     Create RlMemoryHandle using existing raylib pointer with specified size
    /// </summary>
    /// <param name="handle">Raylib pointer to handle</param>
    /// <param name="size">Size of pointer</param>
    /// <exception cref="ArgumentException">Thrown if size is 0 or negative</exception>
    public RlMemoryHandle(nint handle, int size)
    {
        if (size <= 0) throw new ArgumentException("Pointer size couldn't be negative or zero", nameof(size));
        Handle = handle;
        _Size = size;
    }

    /// <summary>
    ///     Create RlMemoryHandle using existing raylib pointer with specified size
    /// </summary>
    /// <param name="handle">Raylib pointer to handle</param>
    /// <param name="size">Size of pointer</param>
    /// <exception cref="ArgumentException">Thrown if size is 0 or negative</exception>
    public unsafe RlMemoryHandle(void* handle, int size)
    {
        if (size <= 0) throw new ArgumentException("Pointer size couldn't be negative or zero", nameof(size));
        Handle = (nint)handle;
        _Size = size;
    }

    /// <summary>
    ///     Copies data from pointer to span with specified type
    /// </summary>
    /// <param name="span">Span to copy to</param>
    /// <typeparam name="T">Type of data to copy</typeparam>
    public unsafe void CopyTo<T>(Span<T> span)
        where T : unmanaged
    {
        var ptr = AsPtr<T>();
        fixed (T* spanPtr = span)
        {
            Buffer.MemoryCopy(ptr, spanPtr, span.Length, Size);
        }
    }

    /// <summary>
    ///     Creates new span with specified type from pointer
    /// </summary>
    /// <typeparam name="T">Type of span1</typeparam>
    /// <returns></returns>
    public unsafe Span<T> AsSpan<T>()
        where T : unmanaged
    {
        return new Span<T>(AsPtr(), _Size);
    }

    /// <summary>
    ///     Casts handled pointer to specified type
    /// </summary>
    /// <typeparam name="T">Casting type</typeparam>
    /// <returns>Casted pointer</returns>
    public unsafe T* AsPtr<T>() where T : unmanaged
    {
        return (T*)Handle;
    }

    /// <summary>
    ///     Returns handled pointer as void*
    /// </summary>
    /// <returns>Pointer to raylib memory</returns>
    public unsafe void* AsPtr()
    {
        return (void*)Handle;
    }

    /// <summary>
    ///     Reallocates memory with new size
    /// </summary>
    /// <param name="size">New size for pointer</param>
    public unsafe void Reallocate(int size)
    {
        Raylib.MemRealloc(AsPtr(), size);
        _Size = size;
    }

    public unsafe void Dispose()
    {
        Raylib.MemFree(AsPtr());
    }

    public static unsafe implicit operator void*(RlMemoryHandle handle)
    {
        return handle.AsPtr();
    }
}