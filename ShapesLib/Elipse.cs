using System;

namespace ShapesLib;

public class Ellipse(double x1, double y1, double x2, double y2, double majorAxis) : Shape
{
    private readonly double x1 = x1;
    private readonly double y1 = y1;
    private readonly double x2 = x2;
    private readonly double y2 = y2;
    private readonly double majorAxis = majorAxis;

    public override double GetArea()
    {
        double c = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) / 2;

        double a = majorAxis / 2;

        if (c >= a)
        {
            throw new ArgumentException("Фокуси не можуть бути далі один від одного, ніж довжина великої осі.");
        }

        double b = Math.Sqrt(a * a - c * c);

        return Math.PI * a * b;
    }

    public override double GetPerimeter()
    {
        double c = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) / 2;

        double a = majorAxis / 2;

        if (c >= a)
        {
            throw new ArgumentException("Фокуси не можуть бути далі один від одного, ніж довжина великої осі.");
        }

        double b = Math.Sqrt(a * a - c * c);
        return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
    }

    public override string ToString()
    {
        return $"Ellipse: Center1 ({this.x1},{this.y1}), Center2 ({this.x2}, {this.y2}), MajorAxis: {this.majorAxis}";
    }
}