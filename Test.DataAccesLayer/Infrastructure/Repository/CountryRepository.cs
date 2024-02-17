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
        public CountryRepository(ApplicationDbContext Country) : base(Country)
        {
            _context = Country;
        }

        public void Update(Country country)
        {
            var countryData = _context?.Countries?.FirstOrDefault(x=>x.id == country.id);
            if (countryData != null)
            {
                countryData.name = country.name;
                countryData.description = country.description;
                countryData.language = country.language;
            }
           // _context.Countries.Update(country);
        }

    }
}
