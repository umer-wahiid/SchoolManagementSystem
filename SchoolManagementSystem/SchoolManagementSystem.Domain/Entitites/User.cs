using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
  public class User
  {
    public int UserID { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string PasswordHash { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    public int RoleID { get; set; } // Foreign key to Role entity
    public Role Role { get; set; } // Navigation property
  }

}
