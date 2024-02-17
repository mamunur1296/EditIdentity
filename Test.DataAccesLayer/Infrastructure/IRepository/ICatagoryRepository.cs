using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.DataAccesLayer.Infrastructure.IRepository
{
    public interface ICatagoryRepository : IRepository<Catagory>
    {
        void Update(Catagory Catagory);
    }
}
