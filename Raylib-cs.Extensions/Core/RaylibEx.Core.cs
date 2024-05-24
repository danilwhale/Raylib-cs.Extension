namespace Raylib_cs.Extensions;

public static partial class RaylibEx
{
    /// <summary>
    ///     Begin scissor mode (define screen area for following drawing)
    /// </summary>
    public static void BeginScissorMode(Rectangle rectangle)
    {
        Raylib.BeginScissorMode((int)rectangle.X, (int)rectangle.Y, (int)rectangle.Width, (int)rectangle.Height);
    }

    /// <summary>
    ///     Compress data (DEFLATE algorithm)
    /// </summary>
    public static unsafe byte[] CompressData(byte[] data)
    {
        fixed (byte* dataPtr = data)
        {
            var size = 0;
            using var compressedData = new RlMemoryHandle(Raylib.CompressData(dataPtr, data.Length, &size), size);

            var dataArray = new byte[compressedData.Size];
            compressedData.CopyTo<byte>(dataArray);

            return dataArray;
        }
    }

    /// <summary>
    ///     Decompress data (DEFLATE algorithm)
    /// </summary>
    public static unsafe byte[] DecompressData(byte[] compData)
    {
        fixed (byte* compDataPtr = compData)
        {
            var size = 0;
            using var data =
                new RlMemoryHandle(Raylib.DecompressData(compDataPtr, compData.Length, &size), size);

            var safeData = new byte[data.Size];
            data.CopyTo<byte>(safeData);

            return safeData;
        }
    }

    /// <summary>
    ///     Encode data to Base64 string
    /// </summary>
    public static unsafe string EncodeDataBase64(byte[] data)
    {
        fixed (byte* dataPtr = data)
        {
            var size = 0;
            using var encodedData = new RlMemoryHandle(Raylib.EncodeDataBase64(dataPtr, data.Length, &size), size);
            var base64 = Utf8StringUtils.GetUTF8String(encodedData.AsPtr<sbyte>());

            return base64;
        }
    }

    /// <summary>
    ///     Decode Base64 string data
    /// </summary>
    public static unsafe byte[] DecodeDataBase64(string data)
    {
        var dataBytes = data.ToUtf8String();
        fixed (byte* dataPtr = dataBytes)
        {
            var outputSize = 0;
            using var decodedData =
                new RlMemoryHandle(Raylib.DecodeDataBase64(dataPtr, &outputSize), outputSize);

            var decodedDataArray = new byte[outputSize];
            decodedData.CopyTo<byte>(decodedDataArray);

            return decodedDataArray;
        }
    }
}