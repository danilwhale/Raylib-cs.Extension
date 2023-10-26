namespace Raylib_cs.Extensions;

public static partial class RaylibEx
{
    public static void BeginScissorMode(Rectangle rectangle) =>
        Raylib.BeginScissorMode((int)rectangle.x, (int)rectangle.y, (int)rectangle.width, (int)rectangle.height);

    public static unsafe byte[] CompressData(byte[] data)
    {
        fixed (byte* dataPtr = data)
        {
            int size = 0;
            using RlMemoryHandle compressedData = new RlMemoryHandle(Raylib.CompressData(dataPtr, data.Length, &size), size);
            
            byte[] dataArray = new byte[compressedData.Size];
            compressedData.CopyTo<byte>(dataArray);

            return dataArray;
        }
    }

    public static unsafe byte[] DecompressData(byte[] compData)
    {
        fixed (byte* compDataPtr = compData)
        {
            int size = 0;
            using RlMemoryHandle data =
                new RlMemoryHandle(Raylib.DecompressData(compDataPtr, compData.Length, &size), size);
            
            byte[] safeData = new byte[data.Size];
            data.CopyTo<byte>(safeData);

            return safeData;
        }
    }

    public static unsafe string EncodeDataBase64(byte[] data)
    {
        fixed (byte* dataPtr = data)
        {
            int size = 0;
            using RlMemoryHandle encodedData = new RlMemoryHandle(Raylib.EncodeDataBase64(dataPtr, data.Length, &size), size);
            string base64 = Utf8StringUtils.GetUTF8String(encodedData.AsPtr<sbyte>());
            
            return base64;
        }
    }

    public static unsafe byte[] DecodeDataBase64(string data)
    {
        byte[] dataBytes = data.ToUtf8String();
        fixed (byte* dataPtr = dataBytes)
        {
            int outputSize = 0;
            using RlMemoryHandle decodedData =
                new RlMemoryHandle(Raylib.DecodeDataBase64(dataPtr, &outputSize), outputSize);
            
            byte[] decodedDataArray = new byte[outputSize];
            decodedData.CopyTo<byte>(decodedDataArray);

            return decodedDataArray;
        }
    }
}