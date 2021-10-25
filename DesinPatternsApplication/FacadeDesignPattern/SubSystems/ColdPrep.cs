using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeDesignPattern
{
    public class ColdPrep : IKitchenSection
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
