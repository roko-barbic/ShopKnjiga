using Microsoft.AspNetCore.Mvc;
using ShopKnjiga.Data;
using ShopKnjiga.Models;

namespace ShopKnjiga.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _context.Categories.ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            List<Category> categoryList = _context.Categories.ToList();

            foreach (var item in categoryList)
            {
                if (item.Name == category.Name)
                {
                    ModelState.AddModelError("Name", "Name vec postoji");
                }
                if(item.DisplayOrder == category.DisplayOrder)
                {
                    ModelState.AddModelError("DisplayOrder", "Display order vec postoji");
                }
            }

            if (ModelState.IsValid)
            {
               
                _context.Categories.Add(category);
                _context.SaveChanges();  //potrebno da je se spremi na bazu
                TempData["success"] = "Uspijeh";
                return RedirectToAction("Index", "Category");
            }
           
            return View();
        }

        public IActionResult Edit(int? categoryId)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            //Category? category1 = _context.Categories.Find(categoryId);
            //Category? category2 = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            List<Category> categoryList = _context.Categories.ToList();

            foreach (var item in categoryList)
            {
                if (item.Name == category.Name)
                {
                    ModelState.AddModelError("Name", "Name vec postoji");
                }
                if (item.DisplayOrder == category.DisplayOrder)
                {
                    ModelState.AddModelError("DisplayOrder", "Display order vec postoji");
                }
            }

            if (ModelState.IsValid)
            {

                _context.Categories.Add(category);
                _context.SaveChanges();  //potrebno da je se spremi na bazu
                TempData["success"] = "Uspijeh";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }
    }
}
