using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lista10.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; } = string.Empty;

        // Navigation property to represent the relationship with Schedule
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Lesson> Lessons { get; set; }

    }
}
