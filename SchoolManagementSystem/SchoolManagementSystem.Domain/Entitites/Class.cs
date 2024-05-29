using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
  public class Class
  {
    public int ClassID { get; set; }

    public int CourseID { get; set; } // Foreign key to Course entity

    [Required(ErrorMessage = "Class date is required.")]
    [DataType(DataType.Date)]
    public DateTime ClassDate { get; set; }

    [Required(ErrorMessage = "Start time is required.")]
    [DataType(DataType.Time)]
    public TimeSpan StartTime { get; set; }

    [Required(ErrorMessage = "End time is required.")]
    [DataType(DataType.Time)]
    public TimeSpan EndTime { get; set; }

    public Course Course { get; set; } // Navigation property

    public ICollection<ClassAttendance> ClassAttendances { get; set; } // Navigation property
  }
}
