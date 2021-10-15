using System;

namespace OOPDemo
{
    public interface IShape
    {
        public double GetArea();
    }
    public interface IAbc
    {
        public int GetArea();
    }

    public class Square : IShape, IAbc
    {
        public Square(double side)
        {
            if (side > 0)
            {
                _side = side;
            }
        }

        private double _side;

        public double Side
        {
            get { return _side; }
            set
            {
                if (value > 0)
                {
                    _side = value;
                }
            }
        }

        double IShape.GetArea()
        {
            return _side * _side;
        }

        int IAbc.GetArea()
        {
            throw new NotImplementedException();
        }
    }

    public class Rectangle : IShape
    {
        public Rectangle(double width, double length)
        {
            Width = width;
            Length = length;
        }
        
        public double Width { get; set; }
        public double Length { get; set; }

        public virtual double GetArea()
        {
            return Width * Length;
        }
    }

    public class Box : Rectangle
    {
        public Box(double width, double length, double height) : base(width, length)
        {
            Height = height;
        }

        public double Height { get; set; }

        public void AdditionSize(double addition)
        {
            Width += addition;
            Length += addition;
            Height += addition;
        }

        public void AdditionSize(double width, double length, double height)
        {
            Width += width;
            Length += length;
            Height += height;
        }

        public override double GetArea()
        {
            return 2 * Height * (Width + Length) + 2 * Width * Length;
        }

        public double GetVolume()
        {
            return Height * Width * Length;
        }
    }

    public class Circle : IShape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IShape square = new Square(10);
            IShape rectangle = new Rectangle(10, 20);
            IShape circle = new Circle(10);

            double squareArea = square.GetArea();
            Console.WriteLine($"Square Area: { squareArea }");

            double rectangleArea = rectangle.GetArea();
            Console.WriteLine($"Square Area: { rectangleArea }");

            double circleArea = circle.GetArea();
            Console.WriteLine($"Circle Area: { Math.Round(circleArea) }");

            Box box = new Box(10, 20, 20);

            box.AdditionSize(10);
            box.AdditionSize(10, 10, 20);

            double boxArea = box.GetArea();
            Console.WriteLine($"Box Area: { boxArea }");

            double boxVolume = box.GetVolume();
            Console.WriteLine($"Box Volume: { boxVolume }");
        }
    }
}
