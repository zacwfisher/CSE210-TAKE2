using System;
using System.Drawing;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        Square s1 = new Square("Red", 4);
        shapes.Add(s1);

        Rectangle r1 = new Rectangle("Blue", 3, 5);
        shapes.Add(r1);

        Circle c1 = new Circle("Green", 2.5);
        shapes.Add(c1);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
        }
    }
}