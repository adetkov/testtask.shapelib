namespace TestTask.ShapeLib
{
    public class Circle : Ellipse
    {
        public Circle(double r)
            : base(r, r)
        {
        }

        public double Radius => XRadius;

        public override string ToString()
        {
            return $"Circle ({Radius})";
        }
    }
}