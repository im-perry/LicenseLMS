using System;
using System.ComponentModel.DataAnnotations;

namespace TeachingAPI.Models
{
    public class ClassLesson
    {
        [Key]
        public string LessonId { get; set; }
        public string ClassName { get; set; }
        public Class Class { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static ClassLesson Create(string className, string name, string description)
        {
            ClassLesson lesson = new ClassLesson
            {
                LessonId = Guid.NewGuid().ToString(),
                ClassName = className,
                Name = name,
                Description = description
            };
            return lesson;
        }
    }
}
