using FacadeDesignPattern.Facade;
using System;

namespace FacadeDesignPattern
{
    //https://medium.com/@antarikshverma/facade-design-pattern-in-c-eedf0872f242
    class Program
    {
        static void Main(string[] args)
        {
            PatronFacade facade = new PatronFacade();

            Console.WriteLine("Hello!  I'll be your server today. What is your name?");
            var name = Console.ReadLine();

            Customer patron = new Customer(name);

            Console.WriteLine("Hello " + patron.Name
                              + ". What appetizer would you like? (1-15):");
            var appID = int.Parse(Console.ReadLine());

            Console.WriteLine("That's a good one.  What entree would you like? (1-20):");
            var entreeID = int.Parse(Console.ReadLine());

            Console.WriteLine("A great choice!  Finally, what drink would you like? (1-60):");
            var drinkID = int.Parse(Console.ReadLine());

            Console.WriteLine("I'll get that order in right away.");

            //Here's what the Facade simplifies
            facade.PlaceOrder(patron, appID, entreeID, drinkID);

            Console.ReadKey();
        }
    }
}
