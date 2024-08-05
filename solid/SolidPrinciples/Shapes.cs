using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public interface IShape { }
    public interface I3DShape : IShape
    {
        public double GetVolume();
    }
    
    public interface I2DShape : IShape
    {
        public double GetArea();
    }
    public class Circle : I2DShape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }
    }

    public class Rectangle : I2DShape
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Rectangle(double length, double breadth)
        {
            this.Length = length;
            this.Breadth = breadth;
        }

        public double GetArea()
        {
            return (this.Length * this.Breadth);
        }
    }

    public class Square : I2DShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            this.Side = side;
        }
        public double GetArea()
        {
            return Side * Side;
        }
    }

    public class Cube : I3DShape
    {
        public double Side { get; set; }

        public Cube(double side)
        {
            this.Side = side;
        }
        public double GetVolume()
        {
            return Side * Side * Side;
        }
    }
}
