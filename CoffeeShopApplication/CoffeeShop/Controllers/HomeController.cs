using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Models;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private ICoffeeRepository _coffeeRepository;

        public HomeController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository; 
        }
        public IActionResult Index()
        {
            var coffees = _coffeeRepository.GetAllCoffees().OrderBy(c => c.Name);
            HomeViewModels homeViewModels = new HomeViewModels()
            {
                HomeTitle = "Coffee Offerings For Today",
                Coffees = coffees.ToList()
            };

            return View(homeViewModels);
        }
    }
}
