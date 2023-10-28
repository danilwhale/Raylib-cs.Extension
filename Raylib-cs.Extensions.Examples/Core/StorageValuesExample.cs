namespace Raylib_cs.Extensions.Game.Core;

public class StorageValuesExample : IExample
{
    public const string StorageDataFile = "storage.data";

    // NOTE: Storage positions must start with 0, directly related to file memory layout
    private enum StorageData : uint
    {
        PositionScore = 0,
        PositionHiScore = 1
    }

    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - storage save/load values");

        int score = 0;
        int hiscore = 0;
        int framesCounter = 0;
        Random random = new Random();

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsKeyPressed(KeyboardKey.KEY_R))
            {
                score = random.Next(1000, 2000);
                hiscore = random.Next(2000, 4000);
            }

            if (IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                SaveStorageValue(StorageData.PositionScore, score);
                SaveStorageValue(StorageData.PositionHiScore, hiscore);
            }
            else if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                // NOTE: If requested position could not be found, value 0 is returned
                score = LoadStorageValue(StorageData.PositionScore);
                hiscore = LoadStorageValue(StorageData.PositionHiScore);
            }

            framesCounter++;
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RAYWHITE.ClearBackground();

                Color.MAROON.DrawText($"SCORE: {score}", 280, 130, 40);
                Color.BLACK.DrawText($"HI-SCORE: {hiscore}", 210, 200, 50);

                Color.LIME.DrawText($"frames: {framesCounter}", 10, 10, 20);

                Color.DARKGRAY.DrawText("Press R to generate random numbers", 220, 40, 20);
                Color.DARKGRAY.DrawText("Press ENTER to SAVE values", 250, 310, 20);
                Color.DARKGRAY.DrawText("Press SPACE to LOAD values", 252, 350, 20);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
    
    // TODO: simplificate using c# streams
    private static unsafe bool SaveStorageValue(StorageData position, int value)
    {
        using AnsiBuffer buffer = StorageDataFile.ToAnsiBuffer();

        bool success = false;
        uint dataSize = 0;
        uint newDataSize = 0;
        byte* fileData = LoadFileData(buffer.AsPointer(), &dataSize);
        byte* newFileData = null;

        if (fileData != null)
        {
            if (dataSize <= ((uint)position * sizeof(int)))
            {
                // Increase data size up to position and store value
                newDataSize = ((uint)position + 1) * sizeof(int);
                newFileData = (byte*)MemRealloc(fileData, (int)newDataSize);

                if (newFileData != null)
                {
                    // Reallocate succeded
                    int* dataPtr = (int*)newFileData;
                    dataPtr[(int)position] = value;
                }
                else
                {
                    // RL_REALLOC failed
                    TraceLog(TraceLogLevel.LOG_WARNING,
                        string.Format(
                            "FILEIO: [{0}] Failed to realloc data ({1}), position in bytes ({2}) bigger than actual file size",
                            StorageDataFile,
                            dataSize,
                            (uint)position * sizeof(int)
                        )
                    );

                    // We store the old size of the file
                    newFileData = fileData;
                    newDataSize = dataSize;
                }
            }
            else
            {
                // Store the old size of the file
                newFileData = fileData;
                newDataSize = dataSize;

                // Replace value on selected position
                int* dataPtr = (int*)newFileData;
                dataPtr[(int)position] = value;
            }

            success = SaveFileData(buffer.AsPointer(), newFileData, newDataSize);
            MemFree(newFileData);

            TraceLog(TraceLogLevel.LOG_INFO, $"FILEIO: [{StorageDataFile}] Saved storage value: {value}");
        }
        else
        {
            TraceLog(TraceLogLevel.LOG_INFO, $"FILEIO: [{StorageDataFile}] File created successfully");

            dataSize = ((uint)position + 1) * sizeof(int);
            fileData = (byte*)MemAlloc((int)dataSize);
            int* dataPtr = (int*)fileData;
            dataPtr[(int)position] = value;

            success = SaveFileData(buffer.AsPointer(), fileData, dataSize);
            UnloadFileData(fileData);

            TraceLog(TraceLogLevel.LOG_INFO, $"FILEIO: [{StorageDataFile}] Saved storage value: {value}");
        }

        return success;
    }
    
    // TODO: simplificate using c# streams
    private static unsafe int LoadStorageValue(StorageData position)
    {
        using var buffer = StorageDataFile.ToAnsiBuffer();
        int value = 0;
        uint dataSize = 0;
        byte*fileData = LoadFileData(buffer.AsPointer(), &dataSize);

        if (fileData != null)
        {
            if (dataSize < ((uint)position*4)) TraceLog(TraceLogLevel.LOG_WARNING, $"FILEIO: [{StorageDataFile}] Failed to find storage position: {position}");
            else
            {
                int *dataPtr = (int *)fileData;
                value = dataPtr[(int)position];
            }

            UnloadFileData(fileData);

            TraceLog(TraceLogLevel.LOG_INFO, $"FILEIO: [{StorageDataFile}] Loaded storage value: {value}");
        }

        return value;
    }
}