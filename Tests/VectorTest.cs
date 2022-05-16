using Invasion.Domain;
using NUnit.Framework;
using System;
using System.Drawing;

namespace Invasion.Tests
{
    [TestFixture]
    public class VectorTest
    {
        private Random random = new Random();

        private Vector GenerateRandomVector() => new Vector(random.NextDouble(), random.NextDouble());

        [Test]
        public void VectorInitTest()
        {
            var x = random.Next();
            var y = random.Next();
            var vector = new Vector(x, y);
            var vectorFromPoint = new Vector(new Point(x, y));
            Assert.AreEqual(x, vector.X);
            Assert.AreEqual(y, vector.Y);
            Assert.AreEqual(vector, vectorFromPoint);
        }

        [Test]
        public void VectorEqualityTest()
        {
            var x = random.Next();
            var y = random.Next();
            Assert.AreEqual(new Vector(x, y), new Vector(x, y));
        }

        [TestCase(0, 0, 0)]
        [TestCase(3, 0, 3)]
        [TestCase(0, 2, 2)]
        [TestCase(3, 4, 5)]
        [TestCase(-3, 4, 5)]
        public void VectorLengthTest(double x, double y, double expected)
        {
            var vector = new Vector(x, y);
            Assert.AreEqual(expected, vector.Length, 1E-05);
        }

        [TestCase(1, 0, 0)]
        [TestCase(0, 1, Math.PI / 2)]
        [TestCase(2, 2, Math.PI / 4)]
        [TestCase(0.86, 0.5, Math.PI / 6)]
        [TestCase(-0.86, 0.5, 5 * Math.PI / 6)]
        public void VectorAngleTest(double x, double y, double expected)
        {
            var vector = new Vector(x, y);
            Assert.AreEqual(expected, vector.Angle, 1E-02);
        }

        [Test]
        public void VectorArithmeticTest()
        {
            var vector1 = GenerateRandomVector();
            var vector2 = GenerateRandomVector();
            var num = random.NextDouble();
            var vectorsSum = vector1 + vector2;
            var vectorsdifference = vector1 - vector2;
            var vectorMultiplying1 = num * vector1;
            var vectorMultiplying2 = vector1 * num;
            var vectorQuotient = vector1 / 2;
            Assert.AreEqual((vector1.X + vector2.X), vectorsSum.X);
            Assert.AreEqual((vector1.Y + vector2.Y), vectorsSum.Y);
            Assert.AreEqual((vector1.X - vector2.X), vectorsdifference.X);
            Assert.AreEqual((vector1.Y - vector2.Y), vectorsdifference.Y);
            Assert.AreEqual((num * vector1.X), vectorMultiplying1.X);
            Assert.AreEqual((num * vector1.Y), vectorMultiplying1.Y);
            Assert.AreEqual(vectorMultiplying1, vectorMultiplying2);
            Assert.AreEqual((vector1.X / 2), vectorQuotient.X);
            Assert.AreEqual((vector1.Y / 2), vectorQuotient.Y);
        }

        [Test]
        public void VectorNormalizeTest()
        {
            var vector = GenerateRandomVector();
            var normalized = vector.Normalize();
            Assert.AreEqual(vector.Angle, normalized.Angle, 1E-05);
        }

        [Test]
        public void VectorBuildTest()
        {
            var length = random.Next(100);
            var angle = random.NextDouble() * Math.PI;
            var vector = Vector.Build(length, angle);
            Assert.AreEqual(length, vector.Length, 1E-03, "1");
            Assert.AreEqual(angle, vector.Angle, 1E-02, "2");
            Assert.AreEqual(length * Math.Cos(angle), vector.X, 1E-03, "3");
            Assert.AreEqual(length * Math.Sin(angle), vector.Y, 1E-03, "4");
        }

        [TestCase(2, 0, Math.PI, Math.PI)]
        [TestCase(0, 1, -Math.PI / 2, 0)]
        [TestCase(4, 5, 2.242, Math.PI)]
        public void VectorRotateTest(double x, double y, double angle, double expected)
        {
            var vector = new Vector(x, y);
            var rotated = vector.Rotate(angle);
            Assert.AreEqual(expected, rotated.Angle, 1E-02);
            Assert.AreEqual(rotated.Length, vector.Length, 1E-02);
        }
    }
}
