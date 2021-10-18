using System;

namespace FactoryMethodDesingPattern
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Square");
        }
    }
}
