using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataRepository
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class;


        int UpdateAndSave<T>(T model) where T : class;


        T GetById<T>(Guid id) where T : class;


        int AddandSave<T>(T model) where T : class;



        int DeleteAndSave<T>(Guid id) where T : class;


        IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;


        bool IsExist<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
    }
}
