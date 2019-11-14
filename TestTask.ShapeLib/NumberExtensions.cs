using System;

namespace TestTask.ShapeLib
{
    internal static class NumberExtensions
    {
        public static bool IsNonNegative(this double num)
        {
            return !Double.IsNaN(num) && num >= 0;
        }
    }
}