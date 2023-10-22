using PaySky.DataAccess.Repository.IRepository;
using PaySky.Models.ApiModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.DataAccess.Repository
{
    public class RoleRepository : Repository<UserRole>, IRoleRepository
    {
        public PaySkyDBContext _paySkyDBContext { get; }

        public RoleRepository(PaySkyDBContext paySkyDBContext) : base(paySkyDBContext)
        {
            _paySkyDBContext = paySkyDBContext;
        }


        public void Save()
        {
        }

        public UserRole GetRole(string name)
        {
            return _paySkyDBContext.UserRole.Where(r => r.Name.Contains(name)).FirstOrDefault();
        }
    }
}
