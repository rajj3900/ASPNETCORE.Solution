using AutoMapper;
using Store4.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store4.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected StoreEntities context = null;
        protected DbSet<T> dbset = null;

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

        public virtual int Insert(T entity)
        {
            dbset.Add(entity);
            return context.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public virtual int Delete(Guid id)
        {
            T existing = dbset.Find(id);
            dbset.Remove(existing);
            return context.SaveChanges();
        }

    }
}
