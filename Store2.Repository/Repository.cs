using Store2.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private StoreEntities context = null;
        private DbSet<T> dbset = null;

        public Repository()
        {
            this.context = new StoreEntities();
            dbset = context.Set<T>();
        }
        public Repository(StoreEntities _context)
        {
            this.context = _context;
            dbset = context.Set<T>();
        }

        public T Get(Guid id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(Guid id)
        {
            T existing = dbset.Find(id);
            dbset.Remove(existing);
        }

    }
}
