using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Models.Dtos
{
    public class VacancyDto
    
    {
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String ExpiryDate { get; set; }
        [Required]
        public int MaxNumberOfApplicants { get; set; }
    }
}
