using SchoolManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class Result : BaseEntity
    {
        [Key]
        public int ResultID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int ClassID { get; set; }
        [Required(ErrorMessage = "Grade is required.")]
        [StringLength(2, ErrorMessage = "Grade should be a maximum of 2 characters.")]
        public string Grade { get; set; }
        public double TotalMarks { get; set; }
        public double ObtainedMarks { get; set; }
        [NotMapped]
        public double Percentage => (TotalMarks > 0) ? (ObtainedMarks / TotalMarks) * 100 : 0;
        [Required]
        public ResultType ResultType { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
        [ForeignKey(nameof(ClassID))]
        public Class Class { get; set; }
        public List<SubjectResult> SubjectResults { get; set; }
    }
}
