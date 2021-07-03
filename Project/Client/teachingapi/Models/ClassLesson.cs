using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teachingapi.Models
{
    public class ClassLesson
    {
        [Key]
        public int LessonId { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
