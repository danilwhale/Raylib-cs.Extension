namespace Raylib_cs.Extensions.Game.Core;

public class LoadingThreadExample : IExample
{
    private static volatile bool dataLoaded; // Data Loaded completion indicator
    private static volatile int dataProgress; // Data progress accumulator

    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - loading thread");

        var loadThread = new Thread(LoadDataThread); // Loading data thread id

        var state = State.Waiting;
        var framesCounter = 0;

        SetTargetFPS(60); // Set our game to run at 60 frames-per-second
        //--------------------------------------------------------------------------------------

        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update
            //----------------------------------------------------------------------------------
            switch (state)
            {
                case State.Waiting:
                    if (IsKeyPressed(KeyboardKey.Enter))
                    {
                        try
                        {
                            loadThread.Start();
                            TraceLog(TraceLogLevel.Info, "Loading thread initialized successfully");
                        }
                        catch (Exception)
                        {
                            TraceLog(TraceLogLevel.Error, "Error creating loading thread");
                        }

                        state = State.Loading;
                    }

                    break;

                case State.Loading:
                    framesCounter++;

                    if (dataLoaded)
                    {
                        framesCounter = 0;
                        try
                        {
                            loadThread.Join();
                            TraceLog(TraceLogLevel.Info, "Loading thread terminated successfully");
                        }
                        catch (Exception)
                        {
                            TraceLog(TraceLogLevel.Error, "Error joining loading thread");
                        }

                        state = State.Finished;
                    }

                    break;
                case State.Finished:
                    if (IsKeyPressed(KeyboardKey.Enter))
                    {
                        // Reset everything to launch again
                        dataLoaded = false;
                        dataProgress = 0;
                        state = State.Waiting;
                    }

                    break;
            }
            //----------------------------------------------------------------------------------

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            {
                Color.RayWhite.ClearBackground();

                switch (state)
                {
                    case State.Waiting:
                        Color.DarkGray.DrawText("PRESS ENTER to START LOADING DATA", 150, 170, 20);
                        break;
                    case State.Loading:
                        Color.SkyBlue.DrawRectangle(150, 200, dataProgress, 60);
                        if (framesCounter / 15 % 2 == 1)
                            Color.DarkBlue.DrawText("LOADING DATA...", 240, 210, 40);
                        break;
                    case State.Finished:
                        Color.Lime.DrawRectangle(150, 200, 500, 60);
                        Color.Green.DrawText("DATA LOADED!", 250, 210, 40);
                        break;
                }

                Color.DarkGray.DrawRectangleLines(150, 200, 500, 60);
            }
            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        CloseWindow(); // Close window and OpenGL context
        //--------------------------------------------------------------------------------------
    }

    // Loading data thread function definition
    private static void LoadDataThread()
    {
        var timeCounter = 0; // Time counted in ms
        var prevTime = DateTime.Now; // Previous time

        // We simulate data loading with a time counter for 5 seconds
        while (timeCounter < 5000)
        {
            var currentTime = DateTime.Now - prevTime;
            timeCounter = (int)currentTime.TotalMilliseconds;

            // We accumulate time over a global variable to be used in
            // main thread as a progress bar
            dataProgress = timeCounter / 10;
        }

        // When data has finished loading, we set global variable
        dataLoaded = true;
    }

    private enum State
    {
        Waiting,
        Loading,
        Finished
    }
}