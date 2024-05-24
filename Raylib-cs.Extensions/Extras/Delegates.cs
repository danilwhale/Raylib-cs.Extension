namespace Raylib_cs.Extensions;

public unsafe delegate void TraceLogCallback(TraceLogLevel logLevel, sbyte* text, sbyte* args);

public unsafe delegate byte* LoadFileDataCallback(sbyte* fileName, int* dataSize);

public unsafe delegate bool SaveFileDataCallback(sbyte* fileName, void* data, int dataSize);

public unsafe delegate sbyte* LoadFileTextCallback(sbyte* fileName);

public unsafe delegate bool SaveFileTextCallback(sbyte* fileName, sbyte* text);