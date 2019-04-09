using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace NewsLetterLib.Interface
{
    public interface IRepositoryGenerico<T> where T : class
    {
        IEnumerable<T> GetItems(Func<T, bool> predicato);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
