using PaySky.Models.ApiModels.UserEntity;
using PaySky.Models.ApiModels.UserVacancyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Models.ApiModels.VacancyEntity
{
    public class Vacancy
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }   
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set;}
        public int MaxNumberOfApplicants { get; set; }
        public VacancyStatus Status => ExpiryDate < DateTime.Now ? VacancyStatus.Expired : VacancyStatus.Active;
        public List<User>? Applicants { get; set; } = new List<User>();
        public List<UserVacancy> UserVacancies { get; set; }
    }
}
