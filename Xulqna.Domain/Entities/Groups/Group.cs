
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Entities.Courses;
using Xulqna.Domain.Entities.Students;
using Xulqna.Domain.Entities.Teachers;
using Xulqna.Domain.Enums;
using Xulqna.Domain.Localization;

namespace Xulqna.Domain.Entities.Groups
{
    public class Group : IAuditable, ILocalizationName
    {
        public Guid Id { get; set; }


        [JsonIgnore]
        public string NameUz { get; set; }

        [JsonIgnore]
        public string NameRu { get; set; }

        [JsonIgnore]
        public string NameEng { get; set; }

        [NotMapped]
        public string Name { get; set; }
        public Guid TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }

        public Guid CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
