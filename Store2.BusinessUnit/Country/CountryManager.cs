using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store2.Models.Country;

namespace Store2.BusinessUnit.Country
{
    public class CountryManager : ICountryManager
    {
        public I MyProperty { get; set; }
        public IEnumerable<CountryListModel> GetStoreCountries()
        {
            
        }
    }
}
