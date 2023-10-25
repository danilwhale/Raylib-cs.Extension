namespace Raylib_cs.Extension;

public struct RlMemoryHandle : IDisposable
{
    public readonly nint Handle;

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

    public unsafe RlMemoryHandle(int size)
    {
        if (size <= 0) throw new ArgumentException("Memory size couldn't be negative or zero", nameof(size));
        Handle = (nint)Raylib.MemAlloc(size);
        _Size = size;
    }

    public RlMemoryHandle(nint handle, int size)
    {
        Handle = handle;
        _Size = size;
    }

    public unsafe RlMemoryHandle(void* handle, int size)
    {
        Handle = (nint)handle;
        _Size = size;
    }

    public unsafe void CopyTo<T>(Span<T> span)
        where T : unmanaged
    {
        T* ptr = AsPtr<T>();
        fixed (T* spanPtr = span)
            Buffer.MemoryCopy(ptr, spanPtr, span.Length, Size);
    }

    public unsafe Span<T> AsSpan<T>(int size) 
        where T : unmanaged
    {
        return new Span<T>(AsPtr(), size);
    }
    
    public unsafe T* AsPtr<T>() where T : unmanaged
    {
        return (T*)Handle;
    }

    public unsafe void* AsPtr()
    {
        return (void*)Handle;
    }

    public unsafe void Reallocate(int size)
    {
        Raylib.MemRealloc(AsPtr(), (int)size);
        _Size = size;
    }

    public unsafe void Dispose()
    {
        Raylib.MemFree(AsPtr());
    }

    public static unsafe implicit operator void*(RlMemoryHandle handle) => handle.AsPtr();
}