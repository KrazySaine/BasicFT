using FoodOrderingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodOrderingApp.Controllers
{
    public class FoodController : Controller
    {
        private static List<FoodItem> _foodItems = new List<FoodItem>
        {
            new FoodItem { Id = 1, Name = "Pizza", Price = 12.99m },
            new FoodItem { Id = 2, Name = "Burger", Price = 8.99m },
            new FoodItem { Id = 3, Name = "Pasta", Price = 10.99m }
        };

        public IActionResult Index()
        {
            return View(_foodItems);
        }

        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Order(Order order)
        {
            if (ModelState.IsValid)
            {
                // Save order logic here (e.g., to a database)
                // For now, return to the confirmation page
                return RedirectToAction("OrderConfirmation", new { id = order.Id });
            }
            return View(order);
        }

        public IActionResult OrderConfirmation(int id)
        {
            // Fetch the order details based on ID (For now just simulate with a new Order)
            var order = new Order
            {
                Id = id,
                OrderedItems = new List<FoodItem>(_foodItems), // Example, you'd filter by order
                TotalAmount = 32.97m, // Example total
                CustomerName = "John Doe"
            };
            return View(order);
        }
    }
}

