using eticaret_data.Abstract;
using eticaret_entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_data.Concrete.SQL
{
    public class SqlGenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : artContext, new()
    {
        //protected readonly artContext context;
        //public SqlGenericRepository(artContext artContext)
        //{
        //    context = artContext;
        //}
        public void create(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }

        }

        public void delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }
        //public List<TEntity> GetsProductByCategory(string name)
        //{

        //    return context.Set<TEntity>().ToList();

        //}
        //public List<TEntity> GetAll(int id)
        //{
          
        //        return context.Set<TEntity>().ToList();
            
        //}
        //public List<TEntity> GetOrders(string UserId)
        //{
           
        //        return context.Set<TEntity>().ToList();
            
        //}

        //public TEntity GetById(int id)
        //{
           
        //        return context.Set<TEntity>().Find(id);
            
        //}

        //public TEntity GetByUserId(string UserId)
        //{
            
        //        return context.Set<TEntity>().Find(UserId);
            
        //}

        public virtual void update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
    }
}
