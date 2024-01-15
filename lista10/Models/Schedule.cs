using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lista10.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public int ClassId { get; set; }

        // Navigation property to represent the relationship with Class
        public Class Class { get; set; }

        [Required]
        public int SubjectId { get; set; }

        // Navigation property to represent the relationship with Subject
        public Subject Subject { get; set; }

        [Required]
        public int Hours { get; set; }
    }
}
