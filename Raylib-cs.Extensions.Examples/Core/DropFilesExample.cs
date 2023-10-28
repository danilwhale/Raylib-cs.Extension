namespace Raylib_cs.Extensions.Game.Core;

public class DropFilesExample : IExample
{
    private const int MAX_FILEPATH_RECORDED = 4096;
    private const int MAX_FILEPATH_SIZE = 2048;


    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - drop files");

        int filePathCounter = 0;
        string[] filePaths = new string[MAX_FILEPATH_RECORDED]; // We will register a maximum of filepaths

        // Allocate space for the required file paths
        for (int i = 0; i < MAX_FILEPATH_RECORDED; i++)
        {
            filePaths[i] = string.Empty;
        }

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            if (IsFileDropped())
            {
                string[] droppedFiles = GetDroppedFiles();

                for (int i = 0, offset = filePathCounter; i < droppedFiles.Length; i++)
                {
                    if (filePathCounter < MAX_FILEPATH_RECORDED - 1)
                    {
                        filePaths[offset + i] = droppedFiles[i];
                        filePathCounter++;
                    }
                }
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RAYWHITE.ClearBackground();

                if (filePathCounter == 0) Color.DARKGRAY.DrawText("Drop your files to this window!", 100, 40, 20);
                else
                {
                    Color.DARKGRAY.DrawText("Dropped files:", 100, 40, 20);

                    for (int i = 0; i < filePathCounter; i++)
                    {
                        if (i % 2 == 0) Color.LIGHTGRAY.Alpha(0.5f).DrawRectangle(0, 85 + 40 * i, screenWidth, 40);
                        else Color.LIGHTGRAY.Alpha(0.3f).DrawRectangle(0, 85 + 40 * i, screenWidth, 40);

                        Color.GRAY.DrawText(filePaths[i], 120, 100 + 40 * i, 10);
                    }

                    Color.DARKGRAY.DrawText("Drop new files...", 100, 110 + 40 * filePathCounter, 20);
                }
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }
}