namespace Geometrics.Shapes;

public sealed class Triangle : Shape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(
        double a,
        double b,
        double c)
    {
        A = a;
        B = b;
        C = c;

        Validate();
    }

    //probably, in future adding constructor that depends on points rather than on sides is required,
    //but at the moment it doesn't look necessary.

    private void Validate()
    {
        bool valid = A > 0
                     && B > 0
                     && C > 0
                     && A + B > C
                     && A + C > B
                     && C + B > A;

        if (valid is false)
            throw new ArgumentException("Triangle sides are invalid");
    }

    protected override double CalculateArea()
    {
        if (TryCalculateRightTriangle(out var area))
            return area;

        var perimeter = (A + B + C) / 2;

        return Math.Sqrt(
            perimeter * (perimeter - A) * (perimeter - B) * (perimeter - C));
    }

    private bool TryCalculateRightTriangle(out double area)
    {
        var (max, other1, other2) = GetMax();

        double sqrMax = max * max,
            sqrOther1 = other1 * other1,
            sqrOther2 = other2 * other2;

        double precision = 0.00001;

        //check if triangle is right. 
        if (Math.Abs(sqrMax - sqrOther1 - sqrOther2) < precision)
        {
            area = other1 * other2 / 2;
            return true;
        }

        area = default;
        return false;
    }

    private (double max, double other1, double other2) GetMax()
    {
        if (A > B)
        {
            return A > C
                ? (max: A, other1: B, other2: C)
                : (max: C, other1: B, other2: A);
        }

        return B > C
            ? (max: B, other1: A, other2: C)
            : (max: C, other1: B, other2: A);
    }
}