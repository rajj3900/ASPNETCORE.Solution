using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.BusinessUnit.StoreManagement
{
    public interface IStoreManager
    {
        IList<StoreEntity> GetStoresList();
        IList<StoreEntity> SearchStoreByName(string name);
        int SaveStore(StoreEntity store);
    }
}
