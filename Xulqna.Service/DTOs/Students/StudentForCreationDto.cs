using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xulqna.Service.DTOs.Students
{
    public class StudentForCreationDto
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public Guid GroupId { get; set; }
    }
}
