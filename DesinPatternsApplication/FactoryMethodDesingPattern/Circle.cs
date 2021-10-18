using System;

namespace FactoryMethodDesingPattern
{
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Circle");
        }
    }
}
