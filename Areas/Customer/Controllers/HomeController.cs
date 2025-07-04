﻿using E_Commerce_MVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            ViewBag.categories = context.categories.ToList();
            ViewBag.products = context.products.ToList();
            return View();
        }
    }
}
