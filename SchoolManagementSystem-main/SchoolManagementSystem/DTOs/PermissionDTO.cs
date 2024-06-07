using SchoolManagementSystem.Domain.Entitites;

namespace SchoolManagementSystem.DTOs
{
    public record PermissionDTO
    (
        int PermissionID,

        int RoleID,

        int PageID,

        bool View,

        bool Update,

        bool Create,

        bool Delete
    );
}
