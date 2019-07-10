using Store2.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.BusinessUnit.Country
{
    public interface ICountryManager
    {
        IEnumerable<CountryListModel> GetStoreCountries();
            
    }
}
