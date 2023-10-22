using PaySky.Models.ApiModels.UserEntity;
using PaySky.Models.ApiModels.VacancyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Models.ApiModels.UserVacancyEntity
{
    public class UserVacancy
    {
        public int VacanyId { get; set; }
        public int UserId { get; set; }

        public Vacancy Vacancy { get; set; }
        public User User { get; set; }

        public DateTime AddedOn {  get; set; }
    }
}
