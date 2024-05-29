using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
  public class ClassAttendance
  {
    public int ClassAttendanceID { get; set; }

    public int ClassID { get; set; } // Foreign key to Class entity
    public int StudentID { get; set; } // Foreign key to Student entity

    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; } // Present/Absent

    public Class Class { get; set; } // Navigation property
    public Student Student { get; set; } // Navigation property
  }
}
