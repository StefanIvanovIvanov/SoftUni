using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape square = new Square();
            IShape rectangle = new Rectangle();

            circle.Draw();
            square.Draw();
            rectangle.Draw();
        }
    }
}
