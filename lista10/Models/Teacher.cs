using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lista10.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; } = string.Empty;
        [Required]
        public int SubjectId { get; set; }

        // Navigation property to represent the relationship with Subject
        public Subject Subject { get; set; }

        [Required]
        public int Hours { get; set; }
    }
}
