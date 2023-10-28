namespace Raylib_cs.Extensions.Game.Core;

public class LoadingThreadExample : IExample
{
    private static volatile bool dataLoaded = false; // Data Loaded completion indicator
    private static volatile int dataProgress = 0; // Data progress accumulator

    private enum State
    {
        Waiting,
        Loading,
        Finished
    }

    public void Run(string[] args)
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - loading thread");

        Thread loadThread = new Thread(LoadDataThread); // Loading data thread id

        State state = State.Waiting;
        int framesCounter = 0;

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
                    if (IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        try
                        {
                            loadThread.Start();
                            TraceLog(TraceLogLevel.LOG_INFO, "Loading thread initialized successfully");
                        }
                        catch (Exception)
                        {
                            TraceLog(TraceLogLevel.LOG_ERROR, "Error creating loading thread");
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
                            TraceLog(TraceLogLevel.LOG_INFO, "Loading thread terminated successfully");
                        }
                        catch (Exception)
                        {
                            TraceLog(TraceLogLevel.LOG_ERROR, "Error joining loading thread");
                        }
                        state = State.Finished;
                    }

                    break;
                case State.Finished:
                    if (IsKeyPressed(KeyboardKey.KEY_ENTER))
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
                Color.RAYWHITE.ClearBackground();

                switch (state)
                {
                    case State.Waiting:
                        Color.DARKGRAY.DrawText("PRESS ENTER to START LOADING DATA", 150, 170, 20);
                        break;
                    case State.Loading:
                        Color.SKYBLUE.DrawRectangle(150, 200, dataProgress, 60);
                        if (framesCounter / 15 % 2 == 1)
                            Color.DARKBLUE.DrawText("LOADING DATA...", 240, 210, 40);
                        break;
                    case State.Finished:
                        Color.LIME.DrawRectangle(150, 200, 500, 60);
                        Color.GREEN.DrawText("DATA LOADED!", 250, 210, 40);
                        break;
                }

                Color.DARKGRAY.DrawRectangleLines(150, 200, 500, 60);
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
    static void LoadDataThread()
    {
        int timeCounter = 0; // Time counted in ms
        DateTime prevTime = DateTime.Now; // Previous time

        // We simulate data loading with a time counter for 5 seconds
        while (timeCounter < 5000)
        {
            TimeSpan currentTime = DateTime.Now - prevTime;
            timeCounter = (int)currentTime.TotalMilliseconds;

            // We accumulate time over a global variable to be used in
            // main thread as a progress bar
            dataProgress = timeCounter / 10;
        }

        // When data has finished loading, we set global variable
        dataLoaded = true;
    }
}