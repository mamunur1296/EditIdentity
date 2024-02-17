using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.DataAccesLayer;
using Test.DataAccesLayer.Infrastructure.IRepository;
using Test.Model;

namespace EditIdentity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CountryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Country> rajult = _UnitOfWork.CountryRepo.GetAll();
            return View(rajult);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create(Country str)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.CountryRepo.Add(str);
                _UnitOfWork.Save();
                return RedirectToAction("Index", "Country");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details( int ? id)
        {
            if(id==null || id <= 0)
            {
                return NotFound();
            }
            var country = _UnitOfWork.CountryRepo.GetT(x=>x.id==id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id <= 0)
        //    {
        //        return NotFound();
        //    }
        //    var country = _UnitOfWork.CountryRepo.GetT(x => x.id == id);
        //    if (country == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(country);
        //}
        //[HttpPost]
        //[IgnoreAntiforgeryToken]
        //public IActionResult Edit(Country str)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _UnitOfWork.CountryRepo.Update(str);
        //        _UnitOfWork.Save();
        //        return RedirectToAction("Index", "Country");
        //    }
        //    return View();
        //}

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var country = _UnitOfWork.CountryRepo.GetT(x => x.id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpPost,ActionName("Delete")]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var country = _UnitOfWork.CountryRepo.GetT(x => x.id == id);
            if (country == null)
            {
                return NotFound();
            }
            _UnitOfWork.CountryRepo.Remove(country);
            _UnitOfWork.Save();
            return RedirectToAction("Index", "Country");
        }

// This is combain action Create and update . this action are titely coupole in this area 

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            if (id == null || id <= 0)
            {
                return View();
            }
            else
            {
                var country = _UnitOfWork.CountryRepo.GetT(x => x.id == id);
                if (country == null)
                {
                    return NotFound();
                }
                return View(country);
            } 
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateUpdate(Country  str)
        {
            if (ModelState.IsValid)
            {
                if (str?.id == null || str.id <= 0)
                {
                    _UnitOfWork.CountryRepo.Add(str);
                    _UnitOfWork.Save();
                    return RedirectToAction("Index", "Country");
                }
                else
                {
                    _UnitOfWork.CountryRepo.Update(str);
                    _UnitOfWork.Save();
                    return RedirectToAction("Index", "Country");
                }

            }
            return View();
        }
//--------------------------------------------------------------------------------------------------------------

    }
}
