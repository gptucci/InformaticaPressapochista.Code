using BizMathLib;
using NewsLetterLib.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterLib.Service
{
    public class RepositoryGenerico<T>: IRepositoryGenerico<T> where T:class
    {
        private LocalDbContext _context = null;
        private DbSet<T> table = null;
        public RepositoryGenerico()
        {
            this._context = new LocalDbContext();
            table = _context.Set<T>();
        }
        public RepositoryGenerico(LocalDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public IEnumerable<T> GetItems(Func<T, bool> predicato)
        {
            return table.Where(predicato);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
