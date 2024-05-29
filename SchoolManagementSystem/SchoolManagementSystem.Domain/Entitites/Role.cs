using System.ComponentModel.DataAnnotations;


namespace SchoolManagementSystem.Domain.Entitites
{
  public class Role
  {
    public int RoleID { get; set; }

    [Required(ErrorMessage = "Role name is required.")]
    public string RoleName { get; set; }

    public string Description { get; set; } // Optional: Description of the role

    public ICollection<User> Users { get; set; } // Navigation property
  }
}
