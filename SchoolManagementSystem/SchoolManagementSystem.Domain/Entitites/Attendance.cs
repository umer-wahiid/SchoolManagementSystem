using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
  public class Attendance
  {
    public int AttendanceID { get; set; }

    public int StudentID { get; set; } // Foreign key to Student entity
    public int CourseID { get; set; } // Foreign key to Course entity

    [Required(ErrorMessage = "Date is required.")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; } // Present/Absent

    public Student Student { get; set; } // Navigation property
    public Course Course { get; set; } // Navigation property
  }
}
