using System;
using ShapesLib;

namespace ShapesConsole;

public static class Program
{
    public static void Main()
    {
        string filePath = "shapes.txt";
        var shapes = ShapeParser.ParseShapesFromFile(filePath);

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
            Console.WriteLine($"Area: {Math.Round(shape.GetArea(), 2)}");
            Console.WriteLine($"Perimeter: {Math.Round(shape.GetPerimeter(), 2)}");
            Console.WriteLine();
        }
    }
}