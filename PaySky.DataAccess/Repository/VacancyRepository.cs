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
    public class VacancyRepository : Repository<Vacancy>, IVacancyRepsitory
    {
        public PaySkyDBContext _paySkyDBContext { get; set; }
        public VacancyRepository(PaySkyDBContext paySkyDBContext) : base(paySkyDBContext)
        {
            _paySkyDBContext = paySkyDBContext;
        }

        public void Save()
        {
            _paySkyDBContext.SaveChanges();
        }

        public void Update(Vacancy vacancy)
        {
            _paySkyDBContext.Vacancies.Update(vacancy);
        }

        public Vacancy GetUserLastApplication(User user)
        {
            return _paySkyDBContext.UserVacancies.Where(u => u.UserId == user.Id && u.AddedOn > DateTime.Now.AddDays(-1)).Select(x => x.Vacancy).FirstOrDefault();
        }
    }
}
