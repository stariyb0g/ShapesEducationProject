using System;

namespace ShapesLib;

public class Triangle(double x1, double y1, double x2, double y2, double x3, double y3) : Shape
{
    private readonly double x1 = x1;
    private readonly double y1 = y1;
    private readonly double x2 = x2;
    private readonly double y2 = y2;
    private readonly double x3 = x3;
    private readonly double y3 = y3;

    public override double GetArea()
    {
        double a = Math.Sqrt(Math.Pow(this.x2 - this.x1, 2) + Math.Pow(this.y2 - this.y1, 2));
        double b = Math.Sqrt(Math.Pow(this.x3 - this.x2, 2) + Math.Pow(this.y3 - this.y2, 2));
        double c = Math.Sqrt(Math.Pow(this.x1 - this.x3, 2) + Math.Pow(this.y1 - this.y3, 2));

        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public override double GetPerimeter()
    {
        double a = Math.Sqrt(Math.Pow(this.x2 - this.x1, 2) + Math.Pow(this.y2 - this.y1, 2));
        double b = Math.Sqrt(Math.Pow(this.x3 - this.x2, 2) + Math.Pow(this.y3 - this.y2, 2));
        double c = Math.Sqrt(Math.Pow(this.x1 - this.x3, 2) + Math.Pow(this.y1 - this.y3, 2));
        return a + b + c;
    }

    public override string ToString()
    {
        return $"Triangle: Points ({this.x1},{this.y1}) ({this.x2},{this.y2}) ({this.x3},{this.y3})";
    }
}