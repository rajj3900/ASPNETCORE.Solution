using Store4.Data;
using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Repository.StoreRepo
{
    public interface IStoreRepository : IRepository<Store>
    {
        IList<StoreEntity> SearchByName(string name);
    }
}
