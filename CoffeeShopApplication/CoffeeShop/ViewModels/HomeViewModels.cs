using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.ViewModels
{
    public class HomeViewModels
    {
        public string HomeTitle { get; set; }
        public List<Coffee> Coffees { get; set; }
    }
}
