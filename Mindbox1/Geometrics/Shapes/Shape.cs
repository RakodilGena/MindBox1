namespace Geometrics.Shapes;

public abstract class Shape
{
    //the only thing you need to add new shape is to inherit this class and override CalculateArea() function.

    //all shapes are going to be immutable.
    //There was no such requirement and none of the opposite, so I've decided on my own.

    //since they're immutable we can easily provide caching area and care not of its invalidation.

    private double? _cachedArea;

    public double GetArea()
    {
        if (_cachedArea.HasValue)
            return _cachedArea.Value;

        var area = CalculateArea();
        _cachedArea = area;
        return area;
    }

    protected abstract double CalculateArea();
}