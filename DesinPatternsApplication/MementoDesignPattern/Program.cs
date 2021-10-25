using MementoDesignPattern.BasicMemento.FoodExample;
using System;

namespace MementoDesignPattern
{

    class Program
    {
        static void Main(string[] args)
        {


            //Here's a new supplier for our restaurant
            FoodSupplier s = new FoodSupplier();
            s.Name = "Harold Karstark";
            s.Phone = "(482) 555-1172";

            // Give the s object to the caretaker to look after it.
            SupplierCaretaker m = new SupplierCaretaker();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Address = "548 S Main St. Nowhere, KS";

            // Crap, gotta undo that entry, I entered the wrong address
            s.RestoreMemento(m.Memento);

            Console.ReadKey();
        }
    }
}
