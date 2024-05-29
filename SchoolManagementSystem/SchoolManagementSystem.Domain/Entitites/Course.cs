using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
  public class Course
  {
    public int CourseID { get; set; }

    [Required(ErrorMessage = "Course name is required.")]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Credits are required.")]
    [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10.")]
    public int Credits { get; set; }

    public int TeacherID { get; set; } // Foreign key to Teacher entity
    public Teacher Teacher { get; set; } // Navigation property

    public ICollection<Enrollment> Enrollments { get; set; } // Navigation property
    public ICollection<Attendance> Attendances { get; set; } // Navigation property
    public ICollection<Class> Classes { get; set; } // Navigation property
  }
}
