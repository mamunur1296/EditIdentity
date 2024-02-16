using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccesLayer.Infrastructure.IRepository;
using Test.Model;

namespace Test.DataAccesLayer.Infrastructure.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext country) : base(country)
        {
            _context = country;
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
        }
    }
}
