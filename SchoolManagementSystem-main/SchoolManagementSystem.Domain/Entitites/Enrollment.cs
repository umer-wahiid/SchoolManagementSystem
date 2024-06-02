using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class Enrollment : BaseEntity
    {
        public int EnrollmentID { get; set; }

        public int StudentID { get; set; }

        public int ClassID { get; set; }

        [Required(ErrorMessage = "Enrollment date is required.")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public Student Student { get; set; }

        public Class Class { get; set; }
    }
}
