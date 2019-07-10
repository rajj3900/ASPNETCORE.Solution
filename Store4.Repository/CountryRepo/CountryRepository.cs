using Store4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Repository.CountryRepo
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository()
        {

        }
    }
}
