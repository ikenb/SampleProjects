using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public interface ICoffeeRepository
    {
        IEnumerable<Coffee> GetAllCoffees();
        Coffee GetCoffeeById(int pieId);
    }
}
