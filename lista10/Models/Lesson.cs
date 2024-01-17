using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lista10.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [Required]
        public int DayOfWeek { get; set; } // 1 - poniedziałek, 2 - wtorek, ..., 7 - niedziela
        [Required]

        public int Hour { get; set; }
        [Required]

        public int ClassId { get; set; }
        public Class Class { get; set; }
        [Required]

        public string TeacherName { get; set; }
        [Required]

        public string SubjectName { get; set; }
    }
}
