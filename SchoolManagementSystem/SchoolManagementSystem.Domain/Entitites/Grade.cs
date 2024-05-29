using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
  public class Grade
  {
    public int GradeID { get; set; }

    public int EnrollmentID { get; set; } // Foreign key to Enrollment entity

    [Required(ErrorMessage = "Grade is required.")]
    public string GradeValue { get; set; }

    public Enrollment Enrollment { get; set; } // Navigation property
  }
}
