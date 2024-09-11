using Geometrics.Shapes;

namespace Geometrics.Tests;

public sealed class CircleTests
{
    public static IEnumerable<object[]> InvalidRadiusData()
    {
        yield return [0];
        yield return [-1];
        yield return [-10_000];
    }

    [Theory]
    [MemberData(nameof(InvalidRadiusData))]
    public void InvalidCircleRadiusShouldThrow(double invalidRadius)
    {
        Assert.Throws<ArgumentException>(() => new Circle(invalidRadius));
    }

    public static IEnumerable<object[]> ValidRadiusData()
    {
        yield return [1];
        yield return [0.0001d];
        yield return [10_000];
    }

    [Theory]
    [MemberData(nameof(ValidRadiusData))]
    public void CircleCreationShouldSucceed(double validRadius)
    {
        var ex = Record.Exception(() => new Circle(validRadius));
        Assert.Null(ex);
    }

    public static IEnumerable<object[]> CirclesAreaTestData()
    {
        yield return [new Circle(1), 3.1415926535d];
        yield return [new Circle(0.0001d), 3.1415926535e-8d];
        yield return [new Circle(100), 31415.926535d];
        yield return [new Circle(79.42d), 19815.710015923836d];
    }

    [Theory]
    [MemberData(nameof(CirclesAreaTestData))]
    public void ShouldCalculateCircleAreaCorrectly(Circle circle, double expectedArea)
    {
        var area = circle.GetArea();

        Assert.Equal(expectedArea, area, precision: 5);
    }
}