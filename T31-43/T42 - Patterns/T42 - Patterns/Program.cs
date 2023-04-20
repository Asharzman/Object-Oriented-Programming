using System;
using System.Collections.Generic;

namespace Shapes
{
    abstract class Shape
    {
        public string Name { get; set; }
        public abstract double Area { get; }
        public abstract double Circumference { get; }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override double Circumference
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }

        public override double Circumference
        {
            get
            {
                return 2 * (Width + Height);
            }
        }
    }

    class Shapes
    {
        List<Shape> shapes = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void PrintShapes()
        {
            foreach (Shape shape in shapes)
            {
                if (shape is Circle)
                {
                    Circle circle = (Circle)shape;
                    Console.WriteLine($"Circle Radius={circle.Radius} Area={circle.Area:F2} Circumference={circle.Circumference:F2}");
                }
                else if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    Console.WriteLine($"Rectangle Width={rectangle.Width} Height={rectangle.Height} Area={rectangle.Area:F2} Circumference={rectangle.Circumference:F2}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shapes shapes = new Shapes();

            Circle circle1 = new Circle { Name = "Circle 1", Radius = 1 };
            Circle circle2 = new Circle { Name = "Circle 2", Radius = 2 };
            Circle circle3 = new Circle { Name = "Circle 3", Radius = 3 };
            Rectangle rectangle1 = new Rectangle { Name = "Rectangle 1", Width = 10, Height = 20 };
            Rectangle rectangle2 = new Rectangle { Name = "Rectangle 2", Width = 20, Height = 30 };
            Rectangle rectangle3 = new Rectangle { Name = "Rectangle 3", Width = 40, Height = 50 };

            shapes.AddShape(circle1);
            shapes.AddShape(circle2);
            shapes.AddShape(circle3);
            shapes.AddShape(rectangle1);
            shapes.AddShape(rectangle2);
            shapes.AddShape(rectangle3);

            shapes.PrintShapes();

            Console.ReadLine();
        }
    }
}
