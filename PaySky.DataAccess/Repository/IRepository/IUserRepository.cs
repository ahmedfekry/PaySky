using PaySky.Models.ApiModels.UserEntity;
using PaySky.Models.ApiModels.VacancyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Save();
    }
}
