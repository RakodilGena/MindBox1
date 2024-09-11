// See https://aka.ms/new-console-template for more information

using Geometrics.Shapes;

Shape[] shapes =
[
    new Circle(5),
    new Triangle(3, 4, 5),
    new Circle(42.42),
    new Triangle(15, 20, 25)
];

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.GetType().Name} has area {shape.GetArea()}");
}