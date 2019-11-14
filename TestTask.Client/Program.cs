using System;
using System.Linq;
using TestTask.ShapeLib;

namespace TestTask.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var shapes = new Shape[]
            {
                new Circle(5),
                new Triangle(3, 4, 5),
                new Circle(1),
                new Ellipse(1, 10),
            };

            var orderedShapes = shapes
                .OrderBy(s => s.Square)
                .Select(s => s.ToString() + $" Square: {s.Square:F3}");

            Console.WriteLine(String.Join(Environment.NewLine, orderedShapes));
        }
    }
}