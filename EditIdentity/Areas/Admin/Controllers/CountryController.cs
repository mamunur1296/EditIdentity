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
    }
}
