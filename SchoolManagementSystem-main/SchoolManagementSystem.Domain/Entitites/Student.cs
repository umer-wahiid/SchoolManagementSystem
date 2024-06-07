using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Enums;

namespace SchoolManagementSystem.Domain.Entitites
{

    public class Student : BaseEntity
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address must be between 1 and 100 characters.", MinimumLength = 1)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enrollment date is required.")]
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public List<Enrollment> Enrollments { get; set; }

        public List<Attendance> Attendances { get; set; }
    }
}
