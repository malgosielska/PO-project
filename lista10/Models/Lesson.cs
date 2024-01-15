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

        public Class ClassName { get; set; }
        [Required]

        public Subject Subject { get; set; }
        [Required]

        public Teacher Teacher { get; set; }
    }
}
