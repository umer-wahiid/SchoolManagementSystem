using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class Class : BaseEntity
    {
        public int ClassID { get; set; }
        public int SubjectID { get; set; }
        [Required(ErrorMessage = "Class date is required.")]
        [DataType(DataType.Date)]
        public DateTime ClassDate { get; set; }
        public List<Subject> Subject { get; set; }
    }
}
