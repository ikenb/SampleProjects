using System;

namespace FactoryMethodDesingPattern
{
    public class Rectangle:IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Rectangle");
        }
        
    }
}
