using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model.ViewModels
{
    public class CountryView
    {
        public Country Country { get; set; } = new Country();
        public IEnumerable<Country> Countries { get; set;} = new List<Country>();
    }
}
