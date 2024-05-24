global using static Raylib_cs.Raylib;
global using Raylib_cs.Extensions;
global using System.Numerics;

namespace Raylib_cs.Extensions.Game;

public class Program
{
    public static void Main(string[] args)
    {
        IExample example = new FeatureTest(); // change class name to any example you want to run
        example.Run(args);
    }
}