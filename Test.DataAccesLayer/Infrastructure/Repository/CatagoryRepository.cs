using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccesLayer.Infrastructure.IRepository;
using Test.Model;

namespace Test.DataAccesLayer.Infrastructure.Repository
{
    public class CatagoryRepository : Repository<Catagory>, ICatagoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CatagoryRepository(ApplicationDbContext country) : base(country)
        {
            _context = country;
        }

        public void Update(Catagory Catagory)
        {
            var catagoryData = _context?.Countries?.FirstOrDefault(x=>x.id == Catagory.Id);
            if (catagoryData != null)
            {
                catagoryData.name = Catagory.Name;

            }
           // _context.Countries.Update(country);
        }

        
    }
}
