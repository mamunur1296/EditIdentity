using Microsoft.AspNetCore.Mvc;
using Test.DataAccesLayer.Infrastructure.IRepository;
using Test.Model;
using Test.Model.ViewModels;

namespace EditIdentity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatagoryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CatagoryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            CatagoryView CatagoryView = new CatagoryView();
            CatagoryView.Catagorys = _UnitOfWork.CatagoryRepo.GetAll();
            return View(CatagoryView);
        }
        
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var catagory = _UnitOfWork.CatagoryRepo.GetT(x => x.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }
            return View(catagory);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var catagory = _UnitOfWork.CatagoryRepo.GetT(x => x.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }
            return View(catagory);
        }
        [HttpPost, ActionName("Delete")]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var catagory = _UnitOfWork.CatagoryRepo.GetT(x => x.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }
            _UnitOfWork.CatagoryRepo.Remove(catagory);
            _UnitOfWork.Save();
            return RedirectToAction("Index", "Country");
        }
        [HttpGet]
        public IActionResult CatagoryUpdate(int? id)
        {
            CatagoryView catagoryView = new CatagoryView();
            if (id == null || id <= 0)
            {
                return View(catagoryView);
            }
            else
            {
                catagoryView.Catagory = _UnitOfWork.CatagoryRepo.GetT(x => x.Id == id);
                if (catagoryView.Catagory == null)
                {
                    return NotFound();
                }
                return View(catagoryView.Catagory);
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CatagoryUpdate(CatagoryView  Catagoryview )
        {
            if (ModelState.IsValid)
            {
                if (Catagoryview.Catagory?.Id == null || Catagoryview.Catagory.Id <= 0)
                {
                    _UnitOfWork.CatagoryRepo.Add(Catagoryview.Catagory);
                    _UnitOfWork.Save();
                    return RedirectToAction("Index", "Country");
                }
                else
                {
                    _UnitOfWork.CatagoryRepo.Update(Catagoryview.Catagory);
                    _UnitOfWork.Save();
                    return RedirectToAction("Index", "Country");
                }

            }
            return View();
        }
    }
}
