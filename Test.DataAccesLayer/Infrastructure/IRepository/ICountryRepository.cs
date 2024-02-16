using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.DataAccesLayer.Infrastructure.IRepository
{
    public interface ICountryRepository : IRepository<Country>
    {
        void Update(Country country);
    }
}
