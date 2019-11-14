using System;
using NUnit.Framework;

namespace TestTask.ShapeLib.Tests
{
    public class CircleTests
    {
        [Test]
        public void Constructor_CorrectRadius_PropertiesEqual()
        {
            double r = 5;
            var circle = new Circle(r);

            Assert.AreEqual(r, circle.Radius);
        }

        [Test]
        public void Constructor_NanRadius_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Ellipse(double.NaN, 1.0));
        }

        [Test]
        public void Constructor_NegativeRadius_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1.0));
        }

        [Test]
        public void Equals_DifferentRadiuses_False()
        {
            var circle1 = new Circle(1.0);
            var circle2 = new Circle(3.0);
            Assert.AreNotEqual(circle1, circle2);
        }

        [Test]
        public void Equals_Null_False()
        {
            var circle = new Circle(1.0);
            Assert.AreNotEqual(circle, null);
        }

        [Test]
        public void Equals_SameObject_True()
        {
            var circle = new Circle(3.0);
            Assert.AreEqual(circle, circle);
            Assert.AreEqual(circle.GetHashCode(), circle.GetHashCode());
        }

        [Test]
        public void Equals_SameRadiuses_True()
        {
            var circle1 = new Circle(3.0);
            var circle2 = new Circle(3.0);
            Assert.AreEqual(circle1, circle2);
            Assert.AreEqual(circle1.GetHashCode(), circle2.GetHashCode());
        }

        [Test]
        public void Square_Radiuses1_ReturnPi()
        {
            var circle = new Circle(1.0);

            Assert.AreEqual(Math.PI, circle.Square);
        }

        [Test]
        public void Square_RadiusIsInvertedPi_Return1()
        {
            var circle = new Circle(Math.Sqrt(1 / Math.PI));

            Assert.AreEqual(1, circle.Square, 1e-8);
        }

        [Test]
        public void Square_ZeroRadius_Zero()
        {
            var circle = new Circle(0.0);
            Assert.AreEqual(0.0, circle.Square);
        }
    }
}