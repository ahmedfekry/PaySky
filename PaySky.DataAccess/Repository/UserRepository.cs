using Microsoft.EntityFrameworkCore;
using PaySky.DataAccess.Repository.IRepository;
using PaySky.Models.ApiModels.UserEntity;
using PaySky.Models.ApiModels.VacancyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public readonly PaySkyDBContext _paySkyDBContext;
        public UserRepository(PaySkyDBContext paySkyDBContext) : base(paySkyDBContext)
        {
            _paySkyDBContext = paySkyDBContext;
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _paySkyDBContext.Users.Where(filter).Include(u => u.role).FirstOrDefault();
        }

        public void Save()
        {
            _paySkyDBContext.SaveChanges();
        }
    }
}
