namespace TestTask.ShapeLib
{
    public abstract class Shape
    {
        protected static double Eps { get; } = 1e-6;

        public abstract double Square { get; }
    }
}