using DOTNET.Solution.BusinessUnit.Model;
using DOTNET.Solution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Solution.BusinessUnit.Interface
{
    public interface ICountry
    {
        IList<CountryModel> GetCountries();
        List<CountryModel> SearchCountry(string name);
        int Save(CountryModel country);

        IList<StateModel> GetStates();
    }
}
