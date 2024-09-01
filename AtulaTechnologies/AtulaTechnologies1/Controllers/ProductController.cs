using AtulaTechnologies1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity.Infrastructure;

namespace AtulaTechnologies1.Controllers
{
    public class ProductController : Controller
    {
        private readonly AtulaTechnologiesDBContext _dbContext;
        public ProductController(AtulaTechnologiesDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetProducts()
        {
            try
            {
                ViewBag.Categories = new SelectList(_dbContext.Category, "Id", "CategoryName");
                return View(_dbContext.Product.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product =  _dbContext.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Map Product to ProductDTO (You might use AutoMapper or manual mapping)
            var productDto = new ProductDTO();
            productDto.Id = id;
            productDto.Name = product.Name;
            productDto.Sku = product.Sku;
            productDto.Category = _dbContext.Category.ToList();
            productDto.CategoryId = product.CategoryId;
            var category = _dbContext.Category.Where(x => x.Id == product.CategoryId).FirstOrDefault();
            productDto.CategoryName = category.CategoryName;
            ViewBag.Categories = new SelectList(_dbContext.Category, "Id", "CategoryName", productDto.Category?.FirstOrDefault()?.Id);

            return View(productDto);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Product category = _dbContext.Product.Find(id);
                Product editCategory = new Product
                {
                    Id = id,
                    Name = category.Name,
                    Sku = category.Sku,
                };
                return View(editCategory);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();
                return RedirectToAction("GetProducts");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductDTO productDto)
        {
            

             try
             {
                    // Map ProductDTO back to Product
                    var product =  _dbContext.Product.Find(productDto.Id);
                    product.Sku = productDto.Sku;
                    product.Name = productDto.Name;
                    product.CategoryId = (int)productDto.CategoryId;
                    // Handle Category mapping as needed

                    _dbContext.Product.Update(product);
                    _dbContext.SaveChangesAsync();
                    ViewBag.Categories = new SelectList(_dbContext.Category, "Id", "CategoryName", productDto.Category?.FirstOrDefault()?.Id);
                    return RedirectToAction("GetProducts");
            }
            catch (Exception ex)
            {
                   return BadRequest(ex.Message);
            }
        }
        private bool ProductExists(int id)
        {
            return _dbContext.Product.Any(e => e.Id == id);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dbContext.Category, "Id", "CategoryName");

            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductDTO productDto)
        {
            try
            {
                var categoryList = _dbContext.Product.ToList();
                
                // Create a new Product entity from the ProductDTO
                var product = new Product
                    {
                        Sku = productDto.Sku,
                        Name = productDto.Name,
                        CategoryId = (int)productDto.CategoryId // Assuming CategoryId is in Product entity
                    };
                if (categoryList == null || categoryList.Count == 0)
                {
                    product.Id = 1;
                }
                else
                {
                    product.Id = categoryList[categoryList.Count - 1].Id + 1;
                }
                // Add the product to the database
                _dbContext.Product.Add(product);
                _dbContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Product created successfully!";
                ViewBag.Categories = new SelectList(_dbContext.Category, "Id", "CategoryName", productDto.CategoryId);
                // Redirect to Index or another page
                return RedirectToAction("GetProducts");
            }
            catch
            {
                return View();
            }
        }
    }
}
