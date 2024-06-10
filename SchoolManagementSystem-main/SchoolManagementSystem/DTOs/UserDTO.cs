using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.DTOs
{
    public record UserDTO
    (
        int UserID,

        string Username,

        string Password,

        string Email,

        int RoleID
    );
}