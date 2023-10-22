using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Models.Dtos
{
    public class ApplicationDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VacancyId { get; set; } 
    }
}
