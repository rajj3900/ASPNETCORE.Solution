using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store4.Data;
using Store4.Domain.Entities;
using Store4.Repository.CountryRepo;

namespace Store4.BusinessUnit.CountryManagement
{
    public class CountryManager : ICountryManager
    {
        public ICountryRepository CountryRepo { get; }

        public CountryManager(ICountryRepository countrRepo)
        {
            CountryRepo = countrRepo;
        }        

        public List<CountryEntity> GetCountriesList()
        {
            var data = CountryRepo.GetAll().ToList();

            return Mapper.Map<List<Country>, List<CountryEntity>>(data);
        }

        public int SaveCountry(CountryEntity country)
        {
            country.Id = Guid.NewGuid();
            country.CreatedUser = "Admin1";
            country.CreatedDate = DateTime.Now;
            
            return CountryRepo.Insert(Mapper.Map<CountryEntity, Country>(country));
        }

        public int UpdateCountry(CountryEntity country)
        {
            return CountryRepo.Update(Mapper.Map<CountryEntity, Country>(country));
        }

        public int DeletCountry(Guid id)
        {
            return CountryRepo.Delete(id);
        }
    }
}
