using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccesLayer.Infrastructure.IRepository;

namespace Test.DataAccesLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICountryRepository CountryRepo { get; private set; }

        public ICatagoryRepository CatagoryRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CountryRepo = new CountryRepository(context);
            CatagoryRepo = new CatagoryRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
