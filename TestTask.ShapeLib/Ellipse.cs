using System;

namespace TestTask.ShapeLib
{
    public class Ellipse : Shape
    {
        /// <summary>
        /// Creates ellipse defined by semi-major and semi-minor axes.
        /// </summary>
        /// <param name="xr">x-axis radius.</param>
        /// <param name="yr">y-axis radius.</param>
        public Ellipse(double xr, double yr)
        {
            if (!xr.IsNonNegative())
                throw new ArgumentException("Radius must be not negative number", nameof(xr));

            if (!yr.IsNonNegative())
                throw new ArgumentException("Radius must be not negative number", nameof(yr));

            XRadius = xr;
            YRadius = yr;
            Square = Math.PI * XRadius * YRadius;
        }

        public override double Square { get; }

        public double XRadius { get; }

        public double YRadius { get; }

        public override bool Equals(object obj)
        {
            return obj is Ellipse other
                && XRadius == other.XRadius
                && YRadius == other.YRadius;
        }

        public override int GetHashCode()
        {
            var hashCode = -1521134295 + XRadius.GetHashCode();

            return hashCode * -1521134295 + YRadius.GetHashCode();
        }

        public override string ToString()
        {
            return $"Ellipse ({XRadius}, {YRadius})";
        }
    }
}