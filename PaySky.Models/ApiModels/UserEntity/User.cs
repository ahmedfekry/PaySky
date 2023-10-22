using PaySky.Models.ApiModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySky.Models.ApiModels.VacancyEntity;
using PaySky.Models.ApiModels.UserVacancyEntity;

namespace PaySky.Models.ApiModels.UserEntity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole role { get; set; }
        public List<Vacancy>? vacancies { get; set; }
        public List<UserVacancy>? UserVacancies { get; set; }

    }
}
