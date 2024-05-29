using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
  public class Enrollment
  {
    public int EnrollmentID { get; set; }

    public int StudentID { get; set; } // Foreign key to Student entity
    public int CourseID { get; set; } // Foreign key to Course entity

    [Required(ErrorMessage = "Enrollment date is required.")]
    [DataType(DataType.Date)]
    public DateTime EnrollmentDate { get; set; }

    public Student Student { get; set; } // Navigation property
    public Course Course { get; set; } // Navigation property
  }
}
