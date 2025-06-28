using E_Commerce_MVC.Data;
using E_Commerce_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
        
            var categories = context.categories.ToList();
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            var category = context.categories.FirstOrDefault(c => c.Id == id);
            if(category is not null)
            {
                
                context.categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("index");

            }
            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public IActionResult Create(Category request)
        {
            if (ModelState.IsValid)
            {
                if (!context.categories.Any(c => c.Name == request.Name))
                {
                    
                    context.categories.Add(request);
                    context.SaveChanges();
                    TempData["success"] = "operation completely done";
                    return RedirectToAction("index");
                }
            }
            ModelState.AddModelError("Name", "the Name is already exist");

            return View(request);
        }
    }
}
