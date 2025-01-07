using System;

namespace ShapesLib;

public abstract class Shape
{
    public abstract double GetArea();

    public abstract double GetPerimeter();

    public abstract override string ToString();
}