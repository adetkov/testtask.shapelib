using System;
using NUnit.Framework;

namespace TestTask.ShapeLib.Tests
{
    public class NumberExtensionsTests
    {
        [Test]
        public void Constructor_CorrectRadiuses_PropertiesEqual()
        {
            double xR = 5;
            double yR = 10;

            var ellipse = new Ellipse(xR, yR);
            Assert.AreEqual(xR, ellipse.XRadius);
            Assert.AreEqual(yR, ellipse.YRadius);
        }

        [Test]
        public void Constructor_NanXRadius_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Ellipse(double.NaN, 1.0));
        }

        [Test]
        public void Constructor_NanYRadius_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Ellipse(1.0, double.NaN));
        }

        [Test]
        public void Constructor_NegativeXRadius_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Ellipse(-1.0, 1.0));
        }

        [Test]
        public void Constructor_NegativeYRadius_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Ellipse(1.0, -1.0));
        }

        [Test]
        public void Square_Radiuses1_ReturnPi()
        {
            var ellipse = new Ellipse(1.0, 1.0);
            Assert.AreEqual(Math.PI, ellipse.Square);
        }

        [Test]
        public void Square_ValidRadiuses_Correct()
        {
            var ellipse = new Ellipse(3.0, 2.0);

            Assert.AreEqual(Math.PI * 6, ellipse.Square);
        }

        [Test]
        public void Square_ZeroRadius_Zero()
        {
            var ellipse = new Ellipse(1.0, 0.0);
            Assert.AreEqual(0.0, ellipse.Square);

            ellipse = new Ellipse(0.0, 1.0);
            Assert.AreEqual(0.0, ellipse.Square);
        }

        [Test]
        public void Equals_SameObject_True()
        {
            var ellipse = new Ellipse(1.0, 3.0);
            Assert.AreEqual(ellipse, ellipse);
            Assert.AreEqual(ellipse.GetHashCode(), ellipse.GetHashCode());
        }

        [Test]
        public void Equals_SameRadiuses_True()
        {
            var ellipse1 = new Ellipse(1.0, 3.0);
            var ellipse2 = new Ellipse(1.0, 3.0);
            Assert.AreEqual(ellipse1, ellipse2);
            Assert.AreEqual(ellipse1.GetHashCode(), ellipse2.GetHashCode());
        }

        [Test]
        public void Equals_DifferentRadiuses_False()
        {
            var ellipse1 = new Ellipse(1.0, 3.0);
            var ellipse2 = new Ellipse(3.0, 1.0);
            Assert.AreNotEqual(ellipse1, ellipse2);
        }

        [Test]
        public void Equals_Null_False()
        {
            var ellipse = new Ellipse(1.0, 3.0);
            Assert.AreNotEqual(ellipse, null);
        }
    }
}