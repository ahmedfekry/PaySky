using PaySky.Models.ApiModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.DataAccess.Repository.IRepository
{
    public interface IRoleRepository: IRepository<UserRole>
    {
        UserRole GetRole(string name);
        public void Save();
    }
}
