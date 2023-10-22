using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Models.Dtos
{
    public class UserDto : UserLoginDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EnumDataType(typeof(Roles))]
        public string Role { get; set; } = string.Empty;
    }

    enum Roles
    {
        Employer,
        Applicant
    }
}
