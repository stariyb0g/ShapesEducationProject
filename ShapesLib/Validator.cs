using System;
using System.Globalization;

namespace ShapesLib
{
    public static class ShapeValidators
    {
        public static bool ValidateTriangle(string[] parts)
        {
            if (parts.Length != 7)
            {
                Console.WriteLine("Triangle requires 6 coordinates.");
                return false;
            }

            double x1 = double.Parse(parts[1], CultureInfo.InvariantCulture);
            double y1 = double.Parse(parts[2], CultureInfo.InvariantCulture);
            double x2 = double.Parse(parts[3], CultureInfo.InvariantCulture);
            double y2 = double.Parse(parts[4], CultureInfo.InvariantCulture);
            double x3 = double.Parse(parts[5], CultureInfo.InvariantCulture);
            double y3 = double.Parse(parts[6], CultureInfo.InvariantCulture);

            // Check if points are not collinear (area > 0)
            double area = 0.5 * Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
            if (area <= 0)
            {
                Console.WriteLine("The points provided do not form a valid triangle.");
                return false;
            }

            return true;
        }

        public static bool ValidateEquilateralTriangle(string[] parts)
        {
            if (parts.Length != 7)
            {
                Console.WriteLine("Equilateral Triangle requires 6 coordinates.");
                return false;
            }

            double x1 = double.Parse(parts[1], CultureInfo.InvariantCulture);
            double y1 = double.Parse(parts[2], CultureInfo.InvariantCulture);
            double x2 = double.Parse(parts[3], CultureInfo.InvariantCulture);
            double y2 = double.Parse(parts[4], CultureInfo.InvariantCulture);
            double x3 = double.Parse(parts[5], CultureInfo.InvariantCulture);
            double y3 = double.Parse(parts[6], CultureInfo.InvariantCulture);

            double side1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double side2 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double side3 = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));

            if (Math.Abs(side1 - side2) > 1e-4 || Math.Abs(side2 - side3) > 1e-4 || Math.Abs(side1 - side3) > 1e-4)
            {
                Console.WriteLine("All sides of an equilateral triangle must be equal.");
                return false;
            }

            return true;
        }

        public static bool ValidateCircle(string[] parts)
        {
            if (parts.Length != 4)
            {
                Console.WriteLine("Circle requires a center point and a radius (3 values).");
                return false;
            }

            double radius = double.Parse(parts[3], CultureInfo.InvariantCulture);
            if (radius <= 0)
            {
                Console.WriteLine("Radius must be greater than zero.");
                return false;
            }

            return true;
        }

        public static bool ValidateRectangle(string[] parts)
        {
            if (parts.Length != 9)
            {
                Console.WriteLine("Rectangle requires 8 coordinates.");
                return false;
            }

            double x1 = double.Parse(parts[1], CultureInfo.InvariantCulture);
            double y1 = double.Parse(parts[2], CultureInfo.InvariantCulture);
            double x2 = double.Parse(parts[3], CultureInfo.InvariantCulture);
            double y2 = double.Parse(parts[4], CultureInfo.InvariantCulture);
            double x3 = double.Parse(parts[5], CultureInfo.InvariantCulture);
            double y3 = double.Parse(parts[6], CultureInfo.InvariantCulture);
            double x4 = double.Parse(parts[7], CultureInfo.InvariantCulture);
            double y4 = double.Parse(parts[8], CultureInfo.InvariantCulture);

            double d1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double d2 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double d3 = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
            double d4 = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));

            if (Math.Abs(d1 - d3) > 1e-4 || Math.Abs(d2 - d4) > 1e-4)
            {
                Console.WriteLine("Opposite sides of a rectangle must be equal.");
                return false;
            }

            return true;
        }

        public static bool ValidateSquare(string[] parts)
        {
            if (parts.Length != 9)
            {
                Console.WriteLine("Square requires 8 coordinates.");
                return false;
            }

            double x1 = double.Parse(parts[1], CultureInfo.InvariantCulture);
            double y1 = double.Parse(parts[2], CultureInfo.InvariantCulture);
            double x2 = double.Parse(parts[3], CultureInfo.InvariantCulture);
            double y2 = double.Parse(parts[4], CultureInfo.InvariantCulture);
            double x3 = double.Parse(parts[5], CultureInfo.InvariantCulture);
            double y3 = double.Parse(parts[6], CultureInfo.InvariantCulture);
            double x4 = double.Parse(parts[7], CultureInfo.InvariantCulture);
            double y4 = double.Parse(parts[8], CultureInfo.InvariantCulture);

            double side1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double side2 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double side3 = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
            double side4 = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));

            if (Math.Abs(side1 - side2) > 1e-4 || Math.Abs(side2 - side3) > 1e-4 || Math.Abs(side3 - side4) > 1e-4 || Math.Abs(side4 - side1) > 1e-4)
            {
                Console.WriteLine("All sides of a square must be equal.");
                return false;
            }

            double diag1 = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            double diag2 = Math.Sqrt(Math.Pow(x4 - x2, 2) + Math.Pow(y4 - y2, 2));

            if (Math.Abs(diag1 - diag2) > 1e-4)
            {
                Console.WriteLine("Diagonals of a square must be equal.");
                return false;
            }

            return true;
        }

        public static bool ValidateRhombus(string[] parts)
        {
            if (parts.Length != 9)
            {
                Console.WriteLine("Rhombus requires 8 coordinates.");
                return false;
            }

            double x1 = double.Parse(parts[1], CultureInfo.InvariantCulture);
            double y1 = double.Parse(parts[2], CultureInfo.InvariantCulture);
            double x2 = double.Parse(parts[3], CultureInfo.InvariantCulture);
            double y2 = double.Parse(parts[4], CultureInfo.InvariantCulture);
            double x3 = double.Parse(parts[5], CultureInfo.InvariantCulture);
            double y3 = double.Parse(parts[6], CultureInfo.InvariantCulture);
            double x4 = double.Parse(parts[7], CultureInfo.InvariantCulture);
            double y4 = double.Parse(parts[8], CultureInfo.InvariantCulture);

            double side1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double side2 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double side3 = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
            double side4 = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));

            if (Math.Abs(side1 - side2) > 1e-6 || Math.Abs(side2 - side3) > 1e-6 || Math.Abs(side3 - side4) > 1e-6 || Math.Abs(side4 - side1) > 1e-6)
            {
                Console.WriteLine("All sides of a rhombus must be equal.");
                return false;
            }

            return true;
        }

        public static bool ValidateEllipse(string[] parts)
        {
            if (parts.Length != 6)
            {
                Console.WriteLine("Ellipse requires 5 values: 2 focus points and the major axis length.");
                return false;
            }

            double x1 = double.Parse(parts[1], CultureInfo.InvariantCulture);
            double y1 = double.Parse(parts[2], CultureInfo.InvariantCulture);
            double x2 = double.Parse(parts[3], CultureInfo.InvariantCulture);
            double y2 = double.Parse(parts[4], CultureInfo.InvariantCulture);
            double majorAxis = double.Parse(parts[5], CultureInfo.InvariantCulture);

            double c = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) / 2;

            if (c * 2 >= majorAxis)
            {
                Console.WriteLine("The distance between foci cannot be greater than or equal to the major axis length.");
                return false;
            }

            if (majorAxis <= 0)
            {
                Console.WriteLine("The major axis must be greater than zero.");
                return false;
            }

            return true;
        }
    }
}
