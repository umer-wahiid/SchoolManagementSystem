using System.ComponentModel.DataAnnotations;


namespace SchoolManagementSystem.Domain.Entitites
{
    public class Role : BaseEntity
    {
        public int RoleID { get; set; }
        [Required(ErrorMessage = "Role name is required.")]
        public string RoleName { get; set; }
        public string Description { get; set; } 
    }
}
