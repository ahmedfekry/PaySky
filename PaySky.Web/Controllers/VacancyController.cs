using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySky.DataAccess.Repository.IRepository;
using PaySky.Models.ApiModels.VacancyEntity;
using PaySky.Models.Dtos;

namespace PaySky.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        public IVacancyRepsitory _vacancyRepsitory { get; }
        public IUserRepository _userRepository { get; }

        public VacancyController(IVacancyRepsitory vacancyRepsitory, IUserRepository userRepository)
        {
            _vacancyRepsitory = vacancyRepsitory;
            _userRepository = userRepository;
        }


        [HttpGet]
        [Authorize(Roles = "Applicant")]
        [Authorize(Roles = "Employer")]
        public ActionResult Index()
        {
            
            List<Vacancy> vacancies = _vacancyRepsitory.GetAll().ToList();

            return Ok(vacancies);
        }

        [Route("Details/{Id}")]
        [HttpGet]
        public ActionResult Detail([FromRoute]int Id)
        {
            var vacancy = _vacancyRepsitory.Get(v => v.Id == Id);
            if (vacancy == null)
            {
                return NotFound();
            }
            return Ok(vacancy); 
        }

        [HttpPost("Create")]
        public ActionResult Create(VacancyDto vacancyDto)
        {
            var Vacancy = new Vacancy();

            Vacancy.Title = vacancyDto.Title;
            Vacancy.Description = vacancyDto.Description;
            Vacancy.ExpiryDate = DateTime.Parse(vacancyDto.ExpiryDate.ToString()) ;
            Vacancy.CreatedDate = DateTime.Now;
            Vacancy.MaxNumberOfApplicants = vacancyDto.MaxNumberOfApplicants;

            _vacancyRepsitory.Add(Vacancy);
            _vacancyRepsitory.Save();

            return Ok(Vacancy);
        }


        [Route("Delete/{Id}")]
        [HttpGet]
        public ActionResult Delete([FromRoute]int id)
        {
            var vacancy = _vacancyRepsitory.Get(vac => vac.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }
            _vacancyRepsitory.Dalete(vacancy);
            _vacancyRepsitory.Save();

            return Ok();
        }

        [Route("Update/{Id}")]
        [HttpPost]
        public ActionResult Update([FromRoute]int Id, [FromBody] VacancyDto vacancyDto)
        {
            var vac = _vacancyRepsitory.Get(v => v.Id == Id);
            if (vac == null)
            {
                return NotFound();
            }

            vac.Title = vacancyDto.Title;
            vac.Description = vacancyDto.Description;
            vac.ExpiryDate = DateTime.Parse(vacancyDto.ExpiryDate);
            vac.MaxNumberOfApplicants = vacancyDto.MaxNumberOfApplicants;
            
            _vacancyRepsitory.Update(vac);
            _vacancyRepsitory.Save();

            return Ok();
        }

        [Route("Deactivate/{Id}")]
        [HttpGet]
        public ActionResult DeactivateVacancy([FromRoute]int Id)
        {
            Vacancy vacancy = _vacancyRepsitory.Get(v => v.Id == Id);

            if (vacancy == null)
            {
                return NotFound();
            }

            vacancy.ExpiryDate = DateTime.Now.AddDays(-1);

            _vacancyRepsitory.Update(vacancy);
            _vacancyRepsitory.Save();

            return Ok();
        }

        [Route("Apply")]
        [HttpPost]
        public ActionResult Apply([FromBody] ApplicationDto applicationDto)
        {
            var vacancy = _vacancyRepsitory.Get(v => v.Id == applicationDto.VacancyId);
            if (vacancy == null)
            {
                return NotFound();
            }

            var user = _userRepository.Get(u => u.Id == applicationDto.UserId);
            if (user == null)
            {
                return NotFound();
            }

            if (vacancy.Applicants != null && vacancy.MaxNumberOfApplicants > 0 && vacancy.Applicants.Count() >= vacancy.MaxNumberOfApplicants)
            {
                return BadRequest("Exceeded Number of applications");
            }

            if (_vacancyRepsitory.GetUserLastApplication(user) != null)
            {
                return BadRequest("Can not apply for two jobs with 24 hours");
            }

            vacancy.Applicants.Add(user);

            _vacancyRepsitory.Update(vacancy);
            _vacancyRepsitory.Save();

            return Ok();
        }
    }
}
