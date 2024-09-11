using Geometrics.Shapes;

namespace Geometrics.Tests;

public sealed class TriangleTests
{
    //invalid creation (invalid sides)
    //invalid creation (one side larger than 2)
    //creation
    //calculation
    public static IEnumerable<object[]> InvalidSidesData()
    {
        //negative
        yield return [-1, 1, 1];
        yield return [1, -1, 1];
        yield return [1, 1, -1];

        //zero
        yield return [0, 1, 1];
        yield return [1, 0, 1];
        yield return [1, 1, 0];

        //one side is larger that other two
        yield return [3, 1, 1];
        yield return [1, 3, 1];
        yield return [1, 1, 3];
    }

    [Theory]
    [MemberData(nameof(InvalidSidesData))]
    public void InvalidTriangleSidesShouldThrow(double side1, double side2, double side3)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3));
    }

    public static IEnumerable<object[]> ValidSidesData()
    {
        yield return [1, 1, 1];

        yield return [3, 4, 5];

        yield return [0.5d, 0.5d, 0.75d];

        yield return [15_000d, 15_000d, 22_222d];
    }

    [Theory]
    [MemberData(nameof(ValidSidesData))]
    public void TriangleCreationShouldSucceed(double side1, double side2, double side3)
    {
        var ex = Record.Exception(() => new Triangle(side1, side2, side3));
        Assert.Null(ex);
    }


    public static IEnumerable<object[]> TrianglesAreaTestData()
    {
        yield return [new Triangle(1, 1, 1), 0.4330127018922193d];

        yield return [new Triangle(3, 4, 5), 6];

        yield return [new Triangle(0.5d, 0.5d, 0.75d), 0.12401959270615269d];

        yield return [new Triangle(15_000d, 15_000d, 22_222d), 111965409.1736772d];
    }

    [Theory]
    [MemberData(nameof(TrianglesAreaTestData))]
    public void ShouldCalculateTriangleAreaCorrectly(Triangle triangle, double expectedArea)
    {
        var area = triangle.GetArea();

        Assert.Equal(expectedArea, area, precision: 10);
    }
}