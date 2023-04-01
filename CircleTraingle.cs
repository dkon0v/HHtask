//Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.

using System;

namespace ShapeLibrary
{
    public interface IShape
    {
        double GetArea();
    }

    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public class Triangle : IShape
    {
        private double side1, side2, side3;

        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public double GetArea()
        {
            // Using Heron's formula for triangle area
            double s = (side1 + side2 + side3) / 2;
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }

        public bool IsRightAngled()
        {
            double eps = 1e-10;
            return Math.Abs(side1 * side1 + side2 * side2 - side3 * side3) < eps ||
                   Math.Abs(side1 * side1 + side3 * side3 - side2 * side2) < eps ||
                   Math.Abs(side2 * side2 + side3 * side3 - side1 * side1) < eps;
        }
    }
}
//Чтобы добавить новую фигуру, достаточно реализовать интерфейс IShape и его метод GetArea().
public class Square : IShape
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public double GetArea()
    {
        return side * side;
    }
}
// Чтобы вычислить площадь фигуры без знания ее типа в compile-time, можно создать дополнительный метод, который будет принимать массив сторон и возвращать объект IShape. 
//Этот метод будет использовать логику определения типа фигуры в runtime и возвращать соответствующий объект.
public static class ShapeFactory
{
    public static IShape CreateShape(params double[] sides)
    {
        switch (sides.Length)
        {
            case 1:
                return new Circle(sides[0]);
            case 3:
                var triangle = new Triangle(sides[0], sides[1], sides[2]);
                if (triangle.IsRightAngled())
                {
                    return new RightAngledTriangle(sides[0], sides[1], sides[2]);
                }
                else
                {
                    return triangle;
                }
        }
    }
}