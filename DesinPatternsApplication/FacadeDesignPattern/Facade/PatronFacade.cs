using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeDesignPattern.Facade
{
    public class PatronFacade
    {
        private ColdPrep _coldPrep = new ColdPrep();
        private BarPrep _bar = new BarPrep();
        private HotPrep _hotPrep = new HotPrep();

        public Order PlaceOrder(Customer patron, int coldAppId, int hotEntreeId, int drinkId)
        {
            Console.WriteLine("{0} places order for cold app #"
                          + coldAppId.ToString()
                          + ", hot entree #" + hotEntreeId.ToString()
                          + ", and drink #" + drinkId.ToString() + ".");

            Order order = new Order();

            order.Appetizer = _coldPrep.PrepareDish(coldAppId);
            order.Entree = _hotPrep.PrepareDish(hotEntreeId);
            order.Drink = _bar.PrepareDish(drinkId);

            return order;
        }
    }
}
