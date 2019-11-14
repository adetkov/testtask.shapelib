using System;
using NUnit.Framework;

namespace TestTask.ShapeLib.Tests
{
    public class TriangleTests
    {
        [Test]
        public void Constructor_ImpossibleTriangle_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1.0, 3.0, 1.0));
        }

        [Test]
        public void Constructor_NanEdge_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(double.NaN, 4.0, 5.0));
            Assert.Throws<ArgumentException>(() => new Triangle(3.0, double.NaN, 5.0));
            Assert.Throws<ArgumentException>(() => new Triangle(3.0, 4.0, double.NaN));
        }

        [Test]
        public void Constructor_NegativeLength_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-1.0, 4.0, 5.0));
            Assert.Throws<ArgumentException>(() => new Triangle(3.0, -1.0, 5.0));
            Assert.Throws<ArgumentException>(() => new Triangle(3.0, 4.0, -1.0));
        }

        [Test]
        public void Constructor_ValidArguments_PropertiesEqual()
        {
            double a = 3;
            double b = 4;
            double c = 5;
            var tri = new Triangle(a, b, c);

            Assert.AreEqual(a, tri.A);
            Assert.AreEqual(b, tri.B);
            Assert.AreEqual(c, tri.C);
        }

        [Test]
        public void Equals_DifferentEdges_False()
        {
            var tri1 = new Triangle(1.0, 1.0, 1.0);
            var tri2 = new Triangle(3.0, 4.0, 5.0);
            Assert.AreNotEqual(tri1, tri2);
        }

        [Test]
        public void Equals_Null_False()
        {
            var tri = new Triangle(1.0, 1.0, 1.0);
            Assert.AreNotEqual(tri, null);
        }

        [Test]
        public void Equals_SameEdges_True()
        {
            var tri1 = new Triangle(3.0, 4.0, 5.0);
            var tri2 = new Triangle(3.0, 4.0, 5.0);
            Assert.AreEqual(tri1, tri2);
            Assert.AreEqual(tri1.GetHashCode(), tri2.GetHashCode());
        }

        [Test]
        public void Equals_SameObject_True()
        {
            var tri = new Triangle(1.0, 1.0, 1.0);
            Assert.AreEqual(tri, tri);
            Assert.AreEqual(tri.GetHashCode(), tri.GetHashCode());
        }

        [Test]
        public void IsRight_Random_False()
        {
            var tri = new Triangle(4, 4, 4);
            Assert.False(tri.IsRight);
        }

        [Test]
        public void IsRight_Random2_False()
        {
            var tri = new Triangle(32, 98, 74);
            Assert.False(tri.IsRight);
        }

        [Test]
        public void IsRight_Right_True()
        {
            var tri = new Triangle(3, 5, 4);
            Assert.True(tri.IsRight);
        }

        [Test]
        public void Square_EquilateralTriangle_ReturnCorrect()
        {
            var tri = new Triangle(5, 5, 5);
            Assert.AreEqual(5 * 5 * Math.Sqrt(3) / 4, tri.Square, 1e-8);
        }

        [Test]
        public void Square_Triangle_5_7_10_ReturnCorrect()
        {
            var tri = new Triangle(5, 7, 10);

            Assert.AreEqual(Math.Sqrt(11 * 6 * 4 * 1), tri.Square, 1e-8);
        }

        [Test]
        public void Square_ZeroHeight_Zero()
        {
            var tri = new Triangle(1, 2, 3);
            Assert.AreEqual(0.0, tri.Square);
        }
    }
}