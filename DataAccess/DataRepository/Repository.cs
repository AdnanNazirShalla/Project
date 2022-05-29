using DataAccess.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataRepository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public int AddandSave<T>(T model) where T : class
        {
            appDbContext.Set<T>().Add(model);
            return appDbContext.SaveChanges();
        }

        //public int Delete<T>(T model) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete<T>(Guid id) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public int DeleteAndSave<T>(Guid id) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return appDbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
          return appDbContext.Set<T>();
        }

        //public T GetById<T>(Guid id) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        public bool IsExist<T>(Expression<Func<T, bool>> predicate) where T : class
        {
           return appDbContext.Set<T>().Any(predicate);
        }

        public int UpdateAndSave<T>(T model) where T : class
        {
            appDbContext.Set<T>().Update(model);
            return appDbContext.SaveChanges();
        }
    }
}
