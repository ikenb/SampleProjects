using System;

namespace FactoryMethodDesingPattern
{

     //https://www.tutorialspoint.com/design_pattern/factory_pattern.htm
    class Program
    {
        static void Main(string[] args)
        {
        ShapeFactory shapeFactory = new ShapeFactory();

        var shape1 = shapeFactory.GetShape("circle");
        var shape2 = shapeFactory.GetShape("rectangle");
        var shape3 = shapeFactory.GetShape("square");

            shape1.Draw();
            shape2.Draw();
            shape3.Draw();

            Console.ReadLine();
        }
    }
}
