using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccesLayer.Infrastructure.IRepository;
using Test.Model;

namespace Test.DataAccesLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext product) : base(product)
        {
            _context = product;
        }

        public void Update(Product Product)
        {
            var ProductData = _context?.Products?.FirstOrDefault(x=>x.Id == Product.Id);
            if (ProductData != null)
            {
                ProductData.ProductName = Product.ProductName;
                ProductData.Description = Product.Description;
                ProductData.Price = Product.Price;
                ProductData.Quentity = Product.Quentity;
                if(Product.ProductImg != null) ProductData.ProductImg = Product.ProductImg;

            }
           
        }

       
    }
}
