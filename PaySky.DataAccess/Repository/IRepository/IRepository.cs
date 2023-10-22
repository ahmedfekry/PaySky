using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public T Add(T Entity);
        IEnumerable<T> GetAll();
        public bool Dalete(T Entity);
        public T Get(Expression<Func<T, bool>> filter);
    }
}
