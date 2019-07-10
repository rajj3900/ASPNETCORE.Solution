using AutoMapper;
using DOTNET.Solution.BusinessUnit.Model;
using DOTNET.Solution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE.Solution.Common
{
    public static class EntityMapper
    {
        //Creat a map and then use the created map where required
        public static void RegisterMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Country, CountryModel>();
                config.CreateMap<State, StateModel>();
            });
            
        }
    }
}
