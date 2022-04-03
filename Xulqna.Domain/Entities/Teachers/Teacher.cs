using System;
using System.Collections.Generic;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Entities.Courses;
using Xulqna.Domain.Enums;

namespace Xulqna.Domain.Entities.Teachers
{
    public class Teacher : IAuditable
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
