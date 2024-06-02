using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.DTOs
{
    public record UserDTO
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RoleID { get; set; }
    }
}
