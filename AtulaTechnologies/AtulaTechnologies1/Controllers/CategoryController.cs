using AtulaTechnologies1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtulaTechnologies1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AtulaTechnologiesDBContext _dbContext;
        public CategoryController(AtulaTechnologiesDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetCatgories()
        {
            try
            {
                return View(_dbContext.Category.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
               Category category = _dbContext.Category.Find(id);
                Category editCategory = new Category
                {
                    Id = id,
                    CategoryName = category.CategoryName
                };
                return View(editCategory);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Category category = _dbContext.Category.Find(id);
                Category editCategory = new Category
                {
                    Id = id,
                    CategoryName = category.CategoryName
                };
                return View(editCategory);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                _dbContext.Category.Remove(category);
                _dbContext.SaveChanges();
                return RedirectToAction("GetCatgories");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                _dbContext.Category.Update(category);
                _dbContext.SaveChanges();
                return RedirectToAction("GetCatgories");
            }
            catch
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult DeleteCategory(int categoryId)
        {
            try
            {
                var deleteCategory = _dbContext.Category.Where(x => x.Id == categoryId).FirstOrDefault();
                _dbContext.Category.Remove(deleteCategory);
                _dbContext.SaveChanges();
                return View(deleteCategory);
            }
            catch
            {
                return View();
            }
        }
    }
}
