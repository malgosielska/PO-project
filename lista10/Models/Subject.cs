using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lista10.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; } = string.Empty;

        // Navigation property to represent the relationship with Teacher
        public ICollection<Teacher> Teachers { get; set; }
    }
}
