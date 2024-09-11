// See https://aka.ms/new-console-template for more information

/*
 Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 
 Дополнительно к работоспособности оценим:
    * Юнит-тесты
    * Легкость добавления других фигур
    * Вычисление площади фигуры без знания типа фигуры в compile-time
    * Проверку на то, является ли треугольник прямоугольным

 */

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