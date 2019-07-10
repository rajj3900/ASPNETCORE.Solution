using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store4.Data;
using Store4.Domain.Entities;
using Store4.Repository;
using Store4.Repository.StoreRepo;

namespace Store4.BusinessUnit.StoreManagement
{
    public class StoreManager : IStoreManager
    {
        private readonly IStoreRepository storeContext;
        public StoreManager(IStoreRepository storeContext)
        {
            this.storeContext = storeContext;
        }
        public IList<StoreEntity> GetStoresList()
        {
            var data = storeContext.GetAll().ToList();

            return Mapper.Map<List<Store>, List<StoreEntity>>(data);
        }

        public int SaveStore(StoreEntity store)
        {
            store.Id = Guid.NewGuid();
            store.CreatedUser = "Admin2";
            store.CreatedDate = DateTime.Now;

            return storeContext.Insert(Mapper.Map<StoreEntity, Store>(store));
        }

        public IList<StoreEntity> SearchStoreByName(string name)
        {
            //var data = storeContext.GetAll()
            //            .Where(n => n.StoreName.Contains(name))
            //            .ToList();

            //return Mapper.Map<List<Store>, List<StoreEntity>>(data);

            return storeContext.SearchByName(name);
        }
    }
}