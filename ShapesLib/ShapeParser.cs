using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ShapesLib
{
    public abstract class ShapeFactory
    {
        public abstract Shape CreateShape(string[] parameters);
        public abstract bool ValidateParameters(string[] parameters);
    }

    public class TriangleFactory : ShapeFactory
    {
        public override Shape CreateShape(string[] parameters)
        {
            return new Triangle(
                double.Parse(parameters[1], CultureInfo.InvariantCulture),
                double.Parse(parameters[2], CultureInfo.InvariantCulture),
                double.Parse(parameters[3], CultureInfo.InvariantCulture),
                double.Parse(parameters[4], CultureInfo.InvariantCulture),
                double.Parse(parameters[5], CultureInfo.InvariantCulture),
                double.Parse(parameters[6], CultureInfo.InvariantCulture)
            );
        }

        public override bool ValidateParameters(string[] parameters)
        {
            return ShapeValidators.ValidateTriangle(parameters);
        }
    }

    public class EquilateralTriangleFactory : ShapeFactory
    {
        public override Shape CreateShape(string[] parameters)
        {
            return new EquilateralTriangle(
                double.Parse(parameters[1], CultureInfo.InvariantCulture),
                double.Parse(parameters[2], CultureInfo.InvariantCulture),
                double.Parse(parameters[3], CultureInfo.InvariantCulture),
                double.Parse(parameters[4], CultureInfo.InvariantCulture),
                double.Parse(parameters[5], CultureInfo.InvariantCulture),
                double.Parse(parameters[6], CultureInfo.InvariantCulture)
            );
        }

        public override bool ValidateParameters(string[] parameters)
        {
            return ShapeValidators.ValidateEquilateralTriangle(parameters);
        }
    }

    public class RectangleFactory : ShapeFactory
    {
        public override Shape CreateShape(string[] parameters)
        {
            return new Rectangle(
                double.Parse(parameters[1], CultureInfo.InvariantCulture),
                double.Parse(parameters[2], CultureInfo.InvariantCulture),
                double.Parse(parameters[3], CultureInfo.InvariantCulture),
                double.Parse(parameters[4], CultureInfo.InvariantCulture),
                double.Parse(parameters[5], CultureInfo.InvariantCulture),
                double.Parse(parameters[6], CultureInfo.InvariantCulture),
                double.Parse(parameters[7], CultureInfo.InvariantCulture),
                double.Parse(parameters[8], CultureInfo.InvariantCulture)
            );
        }

        public override bool ValidateParameters(string[] parameters)
        {
            return ShapeValidators.ValidateRectangle(parameters);
        }
    }

    public class SquareFactory : ShapeFactory
    {
        public override Shape CreateShape(string[] parameters)
        {
            return new Square(
                double.Parse(parameters[1], CultureInfo.InvariantCulture),
                double.Parse(parameters[2], CultureInfo.InvariantCulture),
                double.Parse(parameters[3], CultureInfo.InvariantCulture),
                double.Parse(parameters[4], CultureInfo.InvariantCulture),
                double.Parse(parameters[5], CultureInfo.InvariantCulture),
                double.Parse(parameters[6], CultureInfo.InvariantCulture),
                double.Parse(parameters[7], CultureInfo.InvariantCulture),
                double.Parse(parameters[8], CultureInfo.InvariantCulture)
            );
        }

        public override bool ValidateParameters(string[] parameters)
        {
            return ShapeValidators.ValidateSquare(parameters);
        }
    }

    public class RhombusFactory : ShapeFactory
    {
        public override Shape CreateShape(string[] parameters)
        {
            return new Rhombus(
                double.Parse(parameters[1], CultureInfo.InvariantCulture),
                double.Parse(parameters[2], CultureInfo.InvariantCulture),
                double.Parse(parameters[3], CultureInfo.InvariantCulture),
                double.Parse(parameters[4], CultureInfo.InvariantCulture),
                double.Parse(parameters[5], CultureInfo.InvariantCulture),
                double.Parse(parameters[6], CultureInfo.InvariantCulture),
                double.Parse(parameters[7], CultureInfo.InvariantCulture),
                double.Parse(parameters[8], CultureInfo.InvariantCulture)
            );
        }

        public override bool ValidateParameters(string[] parameters)
        {
            return ShapeValidators.ValidateRhombus(parameters);
        }
    }

    public class CircleFactory : ShapeFactory
    {
        public override Shape CreateShape(string[] parameters)
        {
            return new Circle(
                double.Parse(parameters[1], CultureInfo.InvariantCulture),
                double.Parse(parameters[2], CultureInfo.InvariantCulture),
                double.Parse(parameters[3], CultureInfo.InvariantCulture)
            );
        }

        public override bool ValidateParameters(string[] parameters)
        {
            return ShapeValidators.ValidateCircle(parameters);
        }
    }

    public class EllipseFactory : ShapeFactory
    {
        public override Shape CreateShape(string[] parameters)
        {
            return new Ellipse(
                double.Parse(parameters[1], CultureInfo.InvariantCulture),
                double.Parse(parameters[2], CultureInfo.InvariantCulture),
                double.Parse(parameters[3], CultureInfo.InvariantCulture),
                double.Parse(parameters[4], CultureInfo.InvariantCulture),
                double.Parse(parameters[5], CultureInfo.InvariantCulture)
            );
        }

        public override bool ValidateParameters(string[] parameters)
        {
            return ShapeValidators.ValidateEllipse(parameters);
        }
    }

    public static class ShapeFactoryCreator
    {
        private static readonly Dictionary<string, ShapeFactory> Factories = new()
        {
            ["triangle"] = new TriangleFactory(),
            ["equilateraltriangle"] = new EquilateralTriangleFactory(),
            ["rectangle"] = new RectangleFactory(),
            ["square"] = new SquareFactory(),
            ["rhombus"] = new RhombusFactory(),
            ["circle"] = new CircleFactory(),
            ["ellipse"] = new EllipseFactory()
        };

        public static ShapeFactory? GetFactory(string shapeType)
        {
            return Factories.TryGetValue(shapeType.ToLower(CultureInfo.InvariantCulture), out var factory)
                ? factory
                : null;
        }
    }

    public static class ShapeParser
    {
        public static List<Shape> ParseShapesFromFile(string filePath)
        {
            List<Shape> shapes = new List<Shape>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int shapeCount = int.Parse(lines[0], CultureInfo.InvariantCulture);

                for (int i = 1; i <= shapeCount; i++)
                {
                    string[] parts = lines[i].Split(' ');
                    string shapeType = parts[0].ToLower(CultureInfo.InvariantCulture);

                    var factory = ShapeFactoryCreator.GetFactory(shapeType);
                    if (factory != null)
                    {
                        if (factory.ValidateParameters(parts))
                        {
                            shapes.Add(factory.CreateShape(parts));
                        }
                        else
                        {
                            Console.WriteLine($"Помилка: Дані для фігури '{shapeType}' некоректні.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Тип фігури '{shapeType}' не підтримується.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
            }

            return shapes;
        }
    }
}