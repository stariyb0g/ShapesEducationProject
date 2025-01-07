using System;
using NUnit.Framework;
using ShapesLib;

namespace ShapesLib.Test
{
    [TestFixture]
    public class ShapeTests
    {
        [Test]
        public void TriangleAreaCalculationCorrect()
        {
            var triangle = new Triangle(0, 0, 3, 0, 0, 4);
            Assert.AreEqual(6, triangle.GetArea(), 0.01);
        }

        [Test]
        public void TrianglePerimeterCalculationCorrect()
        {
            var triangle = new Triangle(0, 0, 3, 0, 0, 4);
            Assert.AreEqual(12, triangle.GetPerimeter(), 0.01);
        }

        [Test]
        public void RectangleAreaCalculationCorrect()
        {
            var rectangle = new Rectangle(0, 0, 4, 0, 4, 3, 0, 3);
            Assert.AreEqual(12, rectangle.GetArea());
        }

        [Test]
        public void RectanglePerimeterCalculationCorrect()
        {
            var rectangle = new Rectangle(0, 0, 4, 0, 4, 3, 0, 3);
            Assert.AreEqual(14, rectangle.GetPerimeter());
        }

        [Test]
        public void CircleAreaCalculationCorrect()
        {
            var circle = new Circle(0, 0, 3);
            Assert.AreEqual(Math.PI * 9, circle.GetArea(), 0.01);
        }

        [Test]
        public void CirclePerimeterCalculationCorrect()
        {
            var circle = new Circle(0, 0, 3);
            Assert.AreEqual(Math.PI * 6, circle.GetPerimeter(), 0.01);
        }
    }
}