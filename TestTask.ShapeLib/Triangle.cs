using System;

namespace TestTask.ShapeLib
{
    public class Triangle : Shape
    {
        /// <summary>
        /// Creates triangle defined by lengthes of edges.
        /// </summary>
        /// <param name="a">First edge length.</param>
        /// <param name="b">Second edge length.</param>
        /// <param name="c">Third edge length.</param>
        public Triangle(double a, double b, double c)
        {
            const string errorMessage = "Edge must have not negative length.";

            if (!a.IsNonNegative())
                throw new ArgumentException(errorMessage, nameof(a));

            if (!b.IsNonNegative())
                throw new ArgumentException(errorMessage, nameof(b));

            if (!c.IsNonNegative())
                throw new ArgumentException(errorMessage, nameof(c));

            var e = new[] { a, b, c };
            Array.Sort(e);

            if (!Valid(e[0], e[1], e[2]))
                throw new ArgumentException("Triangle with such edge lengthes is impossible.");

            A = a;
            B = b;
            C = c;

            Square = GetSquare(e[0], e[1], e[2]);
            IsRight = GetIsRight(e[0], e[1], e[2]);
        }

        public double A { get; }

        public double B { get; }

        public double C { get; }

        public bool IsRight { get; }

        public override double Square { get; }

        /// <summary>
        /// Return square calculated by <see href="https://en.wikipedia.org/wiki/Heron's_formula">Heron's formula</see>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static double GetSquare(double a, double b, double c)
        {
            double p = 0.5 * (a + b + c);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// Check if the squared hypotenuse equals sum of rest squared edges.
        /// </summary>
        /// <param name="a">Shortest edge.</param>
        /// <param name="b">Edge satisfies condition <paramref name="a"/> &lt;= <paramref name="b"/> &lt;= <paramref name="c"/></param>
        /// <param name="c">Longest edge.</param>
        /// <returns><c>true</c> if triangle is right.</returns>
        private static bool GetIsRight(double a, double b, double c)
        {
            return Math.Abs(c * c - a * a - b * b) <= Eps;
        }

        /// <summary>
        /// Check if triangle is possible.
        /// </summary>
        /// <param name="a">Shortest edge.</param>
        /// <param name="b">Edge satisfies condition <paramref name="a"/> &lt;= <paramref name="b"/> &lt;= <paramref name="c"/></param>
        /// <param name="c">Longest edge.</param>
        /// <returns><c>false</c> if triangle with such edges can not exist.</returns>
        private static bool Valid(double a, double b, double c)
        {
            return c <= a + b;
        }

        public override string ToString()
        {
            return $"Triangle ({A}, {B}, {C})";
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle other
                && A == other.A
                && B == other.B
                && C == other.C;
        }

        public override int GetHashCode()
        {
            var hashCode = 793064651 + A.GetHashCode();
            hashCode = hashCode * -1521134295 + B.GetHashCode();

            return hashCode * -1521134295 + C.GetHashCode();
        }
    }
}