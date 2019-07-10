using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Repository
{
    public interface IRepository<T>// where T : class
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Insert(T entity);        
        void Update(T entity);
        void Delete(Guid id);
    }
}
