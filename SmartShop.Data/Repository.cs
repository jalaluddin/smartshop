using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace SmartShop.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

		public virtual IEnumerable<T> Get(
            out int total, out int totalDisplay,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<T> query = _context.Set<T>();
            total = query.Count();
            totalDisplay = query.Count();

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                var result = orderBy(query).Skip((pageIndex  - 1)* pageSize).Take(pageSize);

                if (isTrackingOff)
                    return result.AsNoTracking().ToList();
                else
                    return result.ToList();
            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

                if (isTrackingOff)
                    return result.AsNoTracking().ToList();
                else
                    return result.ToList();
            }
        }

        public virtual IEnumerable<T> GetDynamic(out int total, out int totalDisplay, Expression<Func<T, bool>> filter = null,
            string orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<T> query = _context.Set<T>();
            total = query.Count();
            totalDisplay = query.Count();

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);

                if (isTrackingOff)
                    return result.AsNoTracking().ToList();
                else
                    return result.ToList();
            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

                if (isTrackingOff)
                    return result.AsNoTracking().ToList();
                else
                    return result.ToList();
            }
        }

        public virtual IEnumerable<T> GetDynamic(Expression<Func<T, bool>> filter = null, string orderBy = null, 
            string includeProperties = "", bool isTrackingOff = false)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                if (isTrackingOff)
                    return query.OrderBy(orderBy).AsNoTracking().ToList();
                else
                    return query.OrderBy(orderBy).ToList();
            }
            else
            {
                if (isTrackingOff)
                    return query.AsNoTracking().ToList();
                else
                    return query.ToList();
            }
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, string includeProperties = "", bool isTrackingOff = false)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                if (isTrackingOff)
                    return orderBy(query).AsNoTracking().ToList();
                else
                    return orderBy(query).ToList();
            }
            else
            {
                if (isTrackingOff)
                    return query.AsNoTracking().ToList();
                else
                    return query.ToList();
            }
        }

        public virtual int GetCount(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _context.Set<T>();
            int count = query.Count();

            if (filter != null)
            {
                query = query.Where(filter);
                count = query.Count();
            }
            return count;
        }

        public virtual T GetByID(object id, string includeProperties = "")
        {
            if(string.IsNullOrEmpty(includeProperties))
                return _context.Set<T>().Find(id);
            else
            {
                IQueryable<T> query = _context.Set<T>();
                //query = query.Where(x => x.ID == (Guid)id);

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.SingleOrDefault();
            }
        }

        public virtual void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _context.Set<T>().Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entityToDelete);
            }
            _context.Set<T>().Remove(entityToDelete);
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            _context.Set<T>().RemoveRange(_context.Set<T>().Where(filter));
        }

        public virtual void Update(T entityToUpdate)
        {
            _context.Set<T>().Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
