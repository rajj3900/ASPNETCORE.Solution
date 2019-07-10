using AutoMapper;
using Store4.Data;
using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Repository.StoreRepo
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository()
        {
            
        }

        public IList<StoreEntity> SearchByName(string name)
        {
            var data = base.context.Stores.Where(n => n.StoreName.Contains(name)).ToList();

            return Mapper.Map<List<Store>, List<StoreEntity>>(data);
        }
    }
}
