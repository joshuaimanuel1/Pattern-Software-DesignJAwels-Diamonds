using System;
using System.Linq;
using System.Data.Entity;
using projectpsd.Model;

namespace projectpsd.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly Database1Entities db;

        public BaseRepository()
        {
            db = new Database1Entities();
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = db.Set<T>().Find(id);
            if (entityToDelete != null)
            {
                db.Set<T>().Remove(entityToDelete);
                db.SaveChanges();
            }
        }
    }
}