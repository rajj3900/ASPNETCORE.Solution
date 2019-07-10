using AutoMapper;
using Store4.Data;
using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Common
{
    public class StoreMapper
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(config =>
            {
                //To mappings
                config.CreateMap<Store, StoreEntity>();
                config.CreateMap<Country, CountryEntity>();

                //From mappings
                config.CreateMap<CountryEntity, Country>();
                config.CreateMap<StoreEntity, Store>();
            });
        }
    }
}
