using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.DTOs
{
    public record SubjectDTO
    (
        int SubjectID,

        [Required(ErrorMessage = "Course name is required.")]
        string Name,

        [Required(ErrorMessage = "Description is required.")]
        string Description
    );
}
