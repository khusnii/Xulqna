using System;
using System.ComponentModel.DataAnnotations;

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
