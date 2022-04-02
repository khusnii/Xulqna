
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Enums;
using Xulqna.Domain.Localization;

namespace Xulqna.Domain.Entities.Courses
{
    public class Course : IAuditable, ILocalizationName
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Multilanguages names
        /// </summary>
        ///
        [JsonIgnore]
        public string NameUz { get; set; }

        [JsonIgnore]
        public string NameRu { get; set; }

        [JsonIgnore]
        public string NameEng { get; set; }

        [NotMapped]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
