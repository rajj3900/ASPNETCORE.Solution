using AutoMapper;
using DOTNET.Solution.BusinessUnit.Interface;
using DOTNET.Solution.BusinessUnit.Model;
using DOTNET.Solution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Solution.BusinessUnit.BusinessUnit
{
    public class CountryManager : ICountry
    {
        public WOTC_DevEntities DbContext
        {
            get{
                return new WOTC_DevEntities();
            }
        }

        public IList<CountryModel> GetCountries()
        {
            var countries = DbContext.Countries.OrderBy(c => c.Name).ToList();

            List<CountryModel> data = new List<CountryModel>();

            data = Mapper.Map<List<Country>, List<CountryModel>>(countries);

            return data;
        }

        public IList<StateModel> GetStates()
        {
            var states = DbContext.States.Where(s => s.CountryId.Equals(new Guid("AF2A6212-B5BE-4FC0-8E0A-EE385A64370B"))).OrderBy(c => c.Description).ToList();

            List<StateModel> data = new List<StateModel>();

            data = Mapper.Map<List<State>, List<StateModel>>(states);

            return data;
            //return states;
        }

        public int Save(CountryModel country)
        {
            using (var DbContext = new WOTC_DevEntities())
            {
                DbContext.Countries.Add(new Country { Id = Guid.NewGuid(), Name = country.Name });

                return DbContext.SaveChanges();
            }
        }

        public List<CountryModel> SearchCountry(string name)
        {
            var countries = DbContext.Countries.Where(c => c.Name.Contains(name)).ToList();

            return Mapper.Map<List<Country>, List<CountryModel>>(countries);

        }
    }
}
