using E_Commerce_MVC.Data;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ImageService imageService = new ImageService();
        public IActionResult Index()
        {
            var products = context.products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = context.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product request,IFormFile Image)
        {
            if (ModelState.IsValid)
            {

                string fileName = imageService.UploadImage(Image);
                request.Image = fileName;
                context.products.Add(request);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {

                ViewBag.categories = context.categories.ToList();
                return View(request);
            }




            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.products.Find(id);
            ViewBag.categories = context.categories.ToList();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product request,IFormFile? image)
        {
            var oldproductImageName = context.products.AsNoTracking().FirstOrDefault(p=>p.Id==request.Id).Image;
           
            if (image is null)
            {
                request.Image = oldproductImageName;
            }
            else
            {
                 string newfilename=imageService.UploadImage(image);
                imageService.DeleteImage(oldproductImageName);
                request.Image = newfilename;





            }
            context.products.Update(request);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var product = context.products.FirstOrDefault(p => p.Id == id);
            imageService.DeleteImage(product.Image);



            context.products.Remove(product);
          
           
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
