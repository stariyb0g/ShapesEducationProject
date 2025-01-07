using System;

namespace ShapesLib;

public class EquilateralTriangle(double x1, double y1, double x2, double y2, double x3, double y3) : Shape
{
    private readonly double x1 = x1;
    private readonly double y1 = y1;
    private readonly double x2 = x2;
    private readonly double y2 = y2;
    private readonly double x3 = x3;
    private readonly double y3 = y3;

    public override double GetArea()
    {
        double side = Math.Sqrt(Math.Pow(this.x2 - this.x1, 2) + Math.Pow(this.y2 - this.y1, 2));
        return (Math.Sqrt(3) / 4) * side * side;
    }

    public override double GetPerimeter()
    {
        double side = Math.Sqrt(Math.Pow(this.x2 - this.x1, 2) + Math.Pow(this.y2 - this.y1, 2));
        return 3 * side;
    }

    public override string ToString()
    {
        return $"Equilateral Triangle: Points ({this.x1},{this.y1}) ({this.x2},{this.y2}) ({this.x3},{this.y3})";
    }
}