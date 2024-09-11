namespace Geometrics.Shapes;

public sealed class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;

        Validate();
    }

    private void Validate()
    {
        if (Radius <= 0)
            throw new ArgumentException("Radius is invalid");
    }

    protected override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}