using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartShop.Data
{
    public interface IRepository<T> where T : Entity
    {
        void Delete(Expression<Func<T, bool>> filter);
        void Delete(object id);
        void Delete(T entityToDelete);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, 
            IOrderedQueryable<T>> orderBy = null, string includeProperties = "", bool isTrackingOff = false);
        IEnumerable<T> Get(out int total, out int totalDisplay, Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        T GetByID(object id, string includeProperties = "");
        int GetCount(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetDynamic(Expression<Func<T, bool>> filter = null, 
            string orderBy = null, string includeProperties = "", bool isTrackingOff = false);
        IEnumerable<T> GetDynamic(out int total, out int totalDisplay, 
            Expression<Func<T, bool>> filter = null, string orderBy = null, string includeProperties = "", 
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}