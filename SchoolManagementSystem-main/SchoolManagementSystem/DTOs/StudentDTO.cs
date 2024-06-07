using SchoolManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.DTOs
{
    public record StudentDTO
    (
        int StudentID,

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.", MinimumLength = 1)]
        string FirstName,

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.", MinimumLength = 1)]
        string LastName,

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        DateTime DateOfBirth,

        [Required(ErrorMessage = "Gender is required.")]
        Gender Gender,

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address must be between 1 and 100 characters.", MinimumLength = 1)]
        string Address,

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        string PhoneNumber,

        [Required(ErrorMessage = "Enrollment date is required.")]
        [DataType(DataType.Date)]
        DateTime AdmissionDate,

        int UserID
    );
}
