using Microsoft.EntityFrameworkCore;
using PaySky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public PaySkyDBContext _paySkyDBContext { get; }

        public DbSet<T> _Dbset;
        public Repository(PaySkyDBContext paySkyDBContext)
        {
            _paySkyDBContext = paySkyDBContext;
            _Dbset = _paySkyDBContext.Set<T>();
        }

        public T Add(T Entity)
        {
            _Dbset.Add(Entity);
            return Entity;
        }

        public bool Dalete(T Entity)
        {
            _Dbset.Remove(Entity);

            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _Dbset.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _Dbset.Where(filter).FirstOrDefault();
        }
    }
}
