using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class SubjectResult : BaseEntity
    {
        [Key]
        public int SubjectResultID { get; set; }

        [Required]
        public int ResultID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total Marks must be a positive number.")]
        public double TotalMarks { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Obtained Marks must be a positive number.")]
        public double ObtainedMarks { get; set; }

        [ForeignKey(nameof(ResultID))]
        public Result Result { get; set; }

        [ForeignKey(nameof(SubjectID))]
        public Subject Subject { get; set; }
    }
}
