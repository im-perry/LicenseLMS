using System;
using System.ComponentModel.DataAnnotations;

namespace TeachingAPI.Models
{
    public class ClassLesson
    {
        [Key]
        public Guid LessonId { get; set; }
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static ClassLesson Create(Guid classId, Class classs, string name, string description)
        {
            ClassLesson lesson = new ClassLesson
            {
                LessonId = Guid.NewGuid(),
                ClassId = classId,
                Class = classs,
                Name = name,
                Description = description
            };
            return lesson;
        }
    }
}
