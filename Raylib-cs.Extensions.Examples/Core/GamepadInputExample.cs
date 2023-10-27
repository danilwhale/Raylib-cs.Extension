namespace Raylib_cs.Extensions.Game.Core;

public class GamepadInputExample : IExample
{
    public const string Xbox360LegacyNameId = "Xbox Controller";
    public const string Xbox360NameId = "Xbox 360 Controller";
    public const string Ps3NameId = "PLAYSTATION(R)3 Controller";

    public void Run(string[] args)
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);

        InitWindow(screenWidth, screenHeight, "raylib [core] example - gamepad input");

        Texture2D texPs3Pad = LoadTexture("Assets/Textures/Gamepads/PS3.png");
        Texture2D texXboxPad = LoadTexture("Assets/Textures/Gamepads/Xbox.png");

        SetTargetFPS(60);

        int gamepad = 0;
        
        while (!WindowShouldClose())
        {
            BeginDrawing();

            Color.RAYWHITE.ClearBackground();

            if (IsKeyPressed(KeyboardKey.KEY_LEFT) && gamepad > 0) gamepad--;
            if (IsKeyPressed(KeyboardKey.KEY_RIGHT)) gamepad++;

            if (IsGamepadAvailable(gamepad))
            {
                Color.BLACK.DrawText($"GP{gamepad}: {GetGamepadName_(gamepad)}", 10, 10, 10);

                if (GetGamepadName_(gamepad) is Xbox360NameId or Xbox360LegacyNameId)
                {
                    texXboxPad.Draw(0, 0, Color.DARKGRAY);

                    // Draw buttons: xbox home
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_MIDDLE)) Color.RED.DrawCircle(394, 89, 19);

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_MIDDLE_RIGHT)) Color.RED.DrawCircle(436, 150, 9);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_MIDDLE_LEFT)) Color.RED.DrawCircle(352, 150, 9);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_LEFT)) Color.BLUE.DrawCircle(501, 151, 15);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_DOWN)) Color.LIME.DrawCircle(536, 187, 15);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_RIGHT)) Color.MAROON.DrawCircle(572, 151, 15);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_UP)) Color.GOLD.DrawCircle(536, 115, 15);

                    // Draw buttons: d-pad
                    Color.BLACK.DrawRectangle(317, 202, 19, 71);
                    Color.BLACK.DrawRectangle(293, 228, 69, 19);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_UP)) Color.RED.DrawRectangle(317, 202, 19, 26);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_DOWN)) Color.RED.DrawRectangle(317, 202 + 45, 19, 26);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_LEFT)) Color.RED.DrawRectangle(292, 228, 25, 19);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_RIGHT)) Color.RED.DrawRectangle(292 + 44, 228, 26, 19);

                    // Draw buttons: left-right back
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_1)) Color.RED.DrawCircle(259, 61, 20);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_1)) Color.RED.DrawCircle(536, 61, 20);

                    // Draw axis: left joystick

                    Color leftGamepadColor = Color.BLACK;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_THUMB)) leftGamepadColor = Color.RED;
                    Color.BLACK.DrawCircle(259, 152, 39);
                    Color.LIGHTGRAY.DrawCircle(259, 152, 34);
                    leftGamepadColor.DrawCircle(259 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_X) * 20),
                        152 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_Y) * 20), 25);

                    // Draw axis: right joystick
                    Color rightGamepadColor = Color.BLACK;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_THUMB)) rightGamepadColor = Color.RED;
                    Color.BLACK.DrawCircle(461, 237, 38);
                    Color.LIGHTGRAY.DrawCircle(461, 237, 33);
                    rightGamepadColor.DrawCircle(461 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_X) * 20),
                        237 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_Y) * 20), 25);

                    // Draw axis: left-right triggers
                    Color.GRAY.DrawRectangle(170, 30, 15, 70);
                    Color.GRAY.DrawRectangle(604, 30, 15, 70);
                    Color.RED.DrawRectangle(170, 30, 15, (int)(((1 + GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_TRIGGER)) / 2) * 70));
                    Color.RED.DrawRectangle(604, 30, 15, (int)(((1 + GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_TRIGGER)) / 2) * 70));

                    //DrawText(TextFormat("Xbox axis LT: %02.02f", GetGamepadAxisMovement(gamepad, GAMEPAD_AXIS_LEFT_TRIGGER)), 10, 40, 10, BLACK);
                    //DrawText(TextFormat("Xbox axis RT: %02.02f", GetGamepadAxisMovement(gamepad, GAMEPAD_AXIS_RIGHT_TRIGGER)), 10, 60, 10, BLACK);
                }
                else if (GetGamepadName_(gamepad) == Ps3NameId)
                {
                    texPs3Pad.Draw(0, 0, Color.DARKGRAY);

                    // Draw buttons: ps
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_MIDDLE)) Color.RED.DrawCircle(396, 222, 13);

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_MIDDLE_LEFT)) Color.RED.DrawRectangle(328, 170, 32, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_MIDDLE_RIGHT)) Color.RED.DrawTriangle(new Vector2( 436, 168 ), new Vector2( 436, 185 ), new Vector2( 464, 177 ));
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_UP)) Color.LIME.DrawCircle(557, 144, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_RIGHT)) Color.RED.DrawCircle(586, 173, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_DOWN)) Color.VIOLET.DrawCircle(557, 203, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_LEFT)) Color.PINK.DrawCircle(527, 173, 13);

                    // Draw buttons: d-pad
                    Color.BLACK.DrawRectangle(225, 132, 24, 84);
                    Color.BLACK.DrawRectangle(195, 161, 84, 25);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_UP)) Color.RED.DrawRectangle(225, 132, 24, 29);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_DOWN)) Color.RED.DrawRectangle(225, 132 + 54, 24, 30);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_LEFT)) Color.RED.DrawRectangle(195, 161, 30, 25);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_RIGHT)) Color.RED.DrawRectangle(195 + 54, 161, 30, 25);

                    // Draw buttons: left-right back buttons
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_1)) Color.RED.DrawCircle(239, 82, 20);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_1)) Color.RED.DrawCircle(557, 82, 20);

                    // Draw axis: left joystick
                    Color leftGamepadColor = Color.BLACK;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_LEFT_THUMB)) leftGamepadColor = Color.RED;
                    leftGamepadColor.DrawCircle(319, 255, 35);
                    Color.LIGHTGRAY.DrawCircle(319, 255, 31);
                    leftGamepadColor.DrawCircle(319 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_X) * 20),
                        255 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_Y) * 20), 25);

                    // Draw axis: right joystick
                    Color rightGamepadColor = Color.BLACK;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.GAMEPAD_BUTTON_RIGHT_THUMB)) rightGamepadColor = Color.RED;
                    Color.BLACK.DrawCircle(475, 255, 35);
                    Color.LIGHTGRAY.DrawCircle(475, 255, 31);
                    rightGamepadColor.DrawCircle(475 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_X) * 20),
                        255 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_Y) * 20), 25);

                    // Draw axis: left-right triggers
                    Color.GRAY.DrawRectangle(169, 48, 15, 70);
                    Color.GRAY.DrawRectangle(611, 48, 15, 70);
                    Color.RED.DrawRectangle(169, 48, 15, (int)(((1 - GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_TRIGGER)) / 2) * 70));
                    Color.RED.DrawRectangle(611, 48, 15, (int)(((1 - GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_TRIGGER)) / 2) * 70));
                }
                else
                {
                    Color.GRAY.DrawText("- GENERIC GAMEPAD -", 280, 180, 20);

                    // TODO: Draw generic gamepad
                }
                
                DrawText($"DETECTED AXIS: [{GetGamepadAxisCount(0)}]", 10, 50, 10, Color.MAROON);

                for (int i = 0; i < GetGamepadAxisCount(0); i++)
                {
                    Color.DARKGRAY.DrawText($"AXIS {i}: {GetGamepadAxisMovement(0, (GamepadAxis)i):0.00}", 20, 70 + 20 * i, 10);
                }

                if (GetGamepadButtonPressed() != (int)GamepadButton.GAMEPAD_BUTTON_UNKNOWN) Color.RED.DrawText($"DETECTED BUTTON: {GetGamepadButtonPressed()}", 10, 430, 10);
                else Color.GRAY.DrawText("DETECTED BUTTON: NONE", 10, 430, 10);
            }
            else
            {
                Color.GRAY.DrawText($"GP{gamepad}: NOT DETECTED", 10, 10, 10);

                texXboxPad.Draw(0, 0, Color.LIGHTGRAY);
            }

            EndDrawing();
        }
        
        texPs3Pad.Unload();
        texXboxPad.Unload();

        CloseWindow();
    }
}