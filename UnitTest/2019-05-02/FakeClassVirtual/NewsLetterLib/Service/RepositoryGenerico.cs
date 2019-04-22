using BizMathLib;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterLib.Service
{
    public class RepositoryGenerico<T> where T : class
    {
        private LocalDbContext _context = null;
        private DbSet<T> table = null;
        protected RepositoryGenerico()
        {

        }

        public RepositoryGenerico(LocalDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public virtual void Insert(T obj)
        {
            table.Add(obj);
        }
        public virtual IEnumerable<T> GetItems(Func<T, bool> predicato)
        {
            return table.Where(predicato);
        }
        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public virtual void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
