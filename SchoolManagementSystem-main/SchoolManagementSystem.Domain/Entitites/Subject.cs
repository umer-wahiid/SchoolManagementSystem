using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class Subject : BaseEntity
    {
        public int SubjectID { get; set; }
        [Required(ErrorMessage = "Course name is required.")]
        public string SubjectName { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}
