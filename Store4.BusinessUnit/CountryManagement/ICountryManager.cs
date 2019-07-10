using Store4.Data;
using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.BusinessUnit.CountryManagement
{
    public interface ICountryManager
    {
        List<CountryEntity> GetCountriesList();
        int SaveCountry(CountryEntity country);
        int UpdateCountry(CountryEntity country);
        int DeletCountry(Guid id);
    }
}
