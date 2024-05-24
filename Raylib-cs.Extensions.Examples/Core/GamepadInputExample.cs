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

        SetConfigFlags(ConfigFlags.Msaa4xHint);

        InitWindow(screenWidth, screenHeight, "raylib [core] example - gamepad input");

        var texPs3Pad = LoadTexture("Assets/Textures/Gamepads/PS3.png");
        var texXboxPad = LoadTexture("Assets/Textures/Gamepads/Xbox.png");

        SetTargetFPS(60);

        var gamepad = 0;

        while (!WindowShouldClose())
        {
            BeginDrawing();

            Color.RayWhite.ClearBackground();

            if (IsKeyPressed(KeyboardKey.Left) && gamepad > 0) gamepad--;
            if (IsKeyPressed(KeyboardKey.Right)) gamepad++;

            if (IsGamepadAvailable(gamepad))
            {
                Color.Black.DrawText($"GP{gamepad}: {GetGamepadName_(gamepad)}", 10, 10, 10);

                if (GetGamepadName_(gamepad) is Xbox360NameId or Xbox360LegacyNameId)
                {
                    texXboxPad.Draw(0, 0, Color.DarkGray);

                    // Draw buttons: xbox home
                    if (IsGamepadButtonDown(gamepad, GamepadButton.Middle)) Color.Red.DrawCircle(394, 89, 19);

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(gamepad, GamepadButton.MiddleRight)) Color.Red.DrawCircle(436, 150, 9);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.MiddleLeft)) Color.Red.DrawCircle(352, 150, 9);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceLeft)) Color.Blue.DrawCircle(501, 151, 15);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceDown)) Color.Lime.DrawCircle(536, 187, 15);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceRight))
                        Color.Maroon.DrawCircle(572, 151, 15);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceUp)) Color.Gold.DrawCircle(536, 115, 15);

                    // Draw buttons: d-pad
                    Color.Black.DrawRectangle(317, 202, 19, 71);
                    Color.Black.DrawRectangle(293, 228, 69, 19);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceUp))
                        Color.Red.DrawRectangle(317, 202, 19, 26);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceDown))
                        Color.Red.DrawRectangle(317, 202 + 45, 19, 26);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceLeft))
                        Color.Red.DrawRectangle(292, 228, 25, 19);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceRight))
                        Color.Red.DrawRectangle(292 + 44, 228, 26, 19);

                    // Draw buttons: left-right back
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftTrigger1)) Color.Red.DrawCircle(259, 61, 20);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightTrigger1)) Color.Red.DrawCircle(536, 61, 20);

                    // Draw axis: left joystick

                    var leftGamepadColor = Color.Black;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftThumb)) leftGamepadColor = Color.Red;
                    Color.Black.DrawCircle(259, 152, 39);
                    Color.LightGray.DrawCircle(259, 152, 34);
                    leftGamepadColor.DrawCircle(259 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.LeftX) * 20),
                        152 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.LeftY) * 20), 25);

                    // Draw axis: right joystick
                    var rightGamepadColor = Color.Black;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightThumb)) rightGamepadColor = Color.Red;
                    Color.Black.DrawCircle(461, 237, 38);
                    Color.LightGray.DrawCircle(461, 237, 33);
                    rightGamepadColor.DrawCircle(461 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.RightX) * 20),
                        237 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.RightY) * 20), 25);

                    // Draw axis: left-right triggers
                    Color.Gray.DrawRectangle(170, 30, 15, 70);
                    Color.Gray.DrawRectangle(604, 30, 15, 70);
                    Color.Red.DrawRectangle(170, 30, 15,
                        (int)((1 + GetGamepadAxisMovement(gamepad, GamepadAxis.LeftTrigger)) / 2 * 70));
                    Color.Red.DrawRectangle(604, 30, 15,
                        (int)((1 + GetGamepadAxisMovement(gamepad, GamepadAxis.RightTrigger)) / 2 * 70));

                    //DrawText(TextFormat("Xbox axis LT: %02.02f", GetGamepadAxisMovement(gamepad, LeftTrigger)), 10, 40, 10, BLACK);
                    //DrawText(TextFormat("Xbox axis RT: %02.02f", GetGamepadAxisMovement(gamepad, RightTrigger)), 10, 60, 10, BLACK);
                }
                else if (GetGamepadName_(gamepad) == Ps3NameId)
                {
                    texPs3Pad.Draw(0, 0, Color.DarkGray);

                    // Draw buttons: ps
                    if (IsGamepadButtonDown(gamepad, GamepadButton.Middle)) Color.Red.DrawCircle(396, 222, 13);

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(gamepad, GamepadButton.MiddleLeft))
                        Color.Red.DrawRectangle(328, 170, 32, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.MiddleRight))
                        Color.Red.DrawTriangle(new Vector2(436, 168), new Vector2(436, 185), new Vector2(464, 177));
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceUp)) Color.Lime.DrawCircle(557, 144, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceRight)) Color.Red.DrawCircle(586, 173, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceDown))
                        Color.Violet.DrawCircle(557, 203, 13);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightFaceLeft)) Color.Pink.DrawCircle(527, 173, 13);

                    // Draw buttons: d-pad
                    Color.Black.DrawRectangle(225, 132, 24, 84);
                    Color.Black.DrawRectangle(195, 161, 84, 25);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceUp))
                        Color.Red.DrawRectangle(225, 132, 24, 29);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceDown))
                        Color.Red.DrawRectangle(225, 132 + 54, 24, 30);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceLeft))
                        Color.Red.DrawRectangle(195, 161, 30, 25);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftFaceRight))
                        Color.Red.DrawRectangle(195 + 54, 161, 30, 25);

                    // Draw buttons: left-right back buttons
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftTrigger1)) Color.Red.DrawCircle(239, 82, 20);
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightTrigger1)) Color.Red.DrawCircle(557, 82, 20);

                    // Draw axis: left joystick
                    var leftGamepadColor = Color.Black;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.LeftThumb)) leftGamepadColor = Color.Red;
                    leftGamepadColor.DrawCircle(319, 255, 35);
                    Color.LightGray.DrawCircle(319, 255, 31);
                    leftGamepadColor.DrawCircle(319 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.LeftX) * 20),
                        255 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.LeftY) * 20), 25);

                    // Draw axis: right joystick
                    var rightGamepadColor = Color.Black;
                    if (IsGamepadButtonDown(gamepad, GamepadButton.RightThumb)) rightGamepadColor = Color.Red;
                    Color.Black.DrawCircle(475, 255, 35);
                    Color.LightGray.DrawCircle(475, 255, 31);
                    rightGamepadColor.DrawCircle(475 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.RightX) * 20),
                        255 + (int)(GetGamepadAxisMovement(gamepad, GamepadAxis.RightY) * 20), 25);

                    // Draw axis: left-right triggers
                    Color.Gray.DrawRectangle(169, 48, 15, 70);
                    Color.Gray.DrawRectangle(611, 48, 15, 70);
                    Color.Red.DrawRectangle(169, 48, 15,
                        (int)((1 - GetGamepadAxisMovement(gamepad, GamepadAxis.LeftTrigger)) / 2 * 70));
                    Color.Red.DrawRectangle(611, 48, 15,
                        (int)((1 - GetGamepadAxisMovement(gamepad, GamepadAxis.RightTrigger)) / 2 * 70));
                }
                else
                {
                    Color.Gray.DrawText("- GENERIC GAMEPAD -", 280, 180, 20);

                    // TODO: Draw generic gamepad
                }

                DrawText($"DETECTED AXIS: [{GetGamepadAxisCount(0)}]", 10, 50, 10, Color.Maroon);

                for (var i = 0; i < GetGamepadAxisCount(0); i++)
                    Color.DarkGray.DrawText($"AXIS {i}: {GetGamepadAxisMovement(0, (GamepadAxis)i):0.00}", 20,
                        70 + 20 * i, 10);

                if (GetGamepadButtonPressed() != (int)GamepadButton.Unknown)
                    Color.Red.DrawText($"DETECTED BUTTON: {GetGamepadButtonPressed()}", 10, 430, 10);
                else Color.Gray.DrawText("DETECTED BUTTON: NONE", 10, 430, 10);
            }
            else
            {
                Color.Gray.DrawText($"GP{gamepad}: NOT DETECTED", 10, 10, 10);

                texXboxPad.Draw(0, 0, Color.LightGray);
            }

            EndDrawing();
        }

        texPs3Pad.Unload();
        texXboxPad.Unload();

        CloseWindow();
    }
}