![epic library logo trust me its very epic](Assets/Logo.png)
# Raylib-cs.Extensions
## attempt to make oop using extensions on top of raylib-cs
### wip!!1
todo:
- add comments for methods using cheatsheet
- port examples

there's also Raylib-cs.Extensions.Game project to test things i made

---

## requirements
to use this cool library you need:
- raylib-cs (at least 4.5.0.4)
- net 6.0 (based version)

---

## installation
### embedded
1. install Raylib-cs package
2. download source code
3. unpack `Raylib_cs.Extensions` folder to your project folder
### nuget package 
not on nuget

---

## hello world game
```cs
using Raylib_cs;
using static Raylib_cs.Raylib;
using Raylib_cs.Extensions;

InitWindow(800, 480, "hello world!");
SetTargetFPS(60);

while (!WindowShouldClose)
{
  BeginDrawing();
  Color.WHITE.ClearBackground();

  Color.BLACK.DrawText("hello world" 12, 12, 20);

  EndDrawing();
}

CloseWindow();
```
