using System;

namespace ShapesLib;

public class Circle(double centerX, double centerY, double radius) : Shape
{
    private readonly double centerX = centerX;
    private readonly double centerY = centerY;
    private readonly double radius = radius;

    public override double GetArea()
    {
        return Math.PI * this.radius * this.radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * this.radius;
    }

    public override string ToString()
    {
        return $"Circle: Center ({this.centerX},{this.centerY}), Radius {this.radius}";
    }
}