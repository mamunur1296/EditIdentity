using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccesLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepo { get; }
        ICatagoryRepository CatagoryRepo { get; }
        IProductRepository ProductRepo { get; }
        void Save();
    }
}
