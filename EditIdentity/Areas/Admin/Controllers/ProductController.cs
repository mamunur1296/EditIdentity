using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.DataAccesLayer.Infrastructure.IRepository;
using Test.Model.ViewModels;

namespace EditIdentity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _Environment;

        public ProductController(IUnitOfWork UnitOfWork, IWebHostEnvironment environment)
        {
            _UnitOfWork = UnitOfWork;
            _Environment = environment;
        }
        public IActionResult Index()
        {
            ProductView productView = new ProductView();
            productView.Products = _UnitOfWork.ProductRepo.GetAll();
            return View(productView);
        }
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            ProductView productView = new ProductView()
            {
                Product = new(),
                Catagoris = _UnitOfWork.CatagoryRepo.GetAll().Select(item => new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                })
            };
            if (id == null || id <= 0)
            {
                return View(productView);
            }
            else
            {
                productView.Product = _UnitOfWork.ProductRepo.GetT(x => x.Id == id);
                if (productView.Product == null)
                {
                    return NotFound();
                }
                return View(productView.Product);
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateUpdate(ProductView ProductView , IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    string uploadDir = Path.Combine(_Environment.WebRootPath, "ProductImg");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);

                    // Delete old image if it exists
                    if (!string.IsNullOrEmpty(ProductView.Product.ProductImg))
                    {
                        string oldImgPath = Path.Combine(_Environment.WebRootPath, "ProductImg", ProductView.Product.ProductImg);
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }

                    // Save new image
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Update the product's image file name
                    ProductView.Product.ProductImg = "/ProductImg/" + fileName;
                }

                if (ProductView.Product?.Id == null || ProductView.Product?.Id <= 0)
                {
                    _UnitOfWork.ProductRepo.Add(ProductView.Product);
                }
                else
                {
                    _UnitOfWork.ProductRepo.Update(ProductView.Product);
                }
                _UnitOfWork.Save();
                return RedirectToAction("Index", "Country");

            }
            return View();
        }

    }
}
