using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeDesignPattern
{
    public class BarPrep : IKitchenSection
    {
        public FoodItem PrepareDish(int dishId)
        {
            return new FoodItem
            {
                DishId = dishId
            };
        }
    }
}
