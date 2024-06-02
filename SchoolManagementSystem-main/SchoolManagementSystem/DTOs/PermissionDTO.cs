using SchoolManagementSystem.Domain.Entitites;

namespace SchoolManagementSystem.DTOs
{
    public record PermissionDTO
    {
        public int PermissionID { get; set; }

        public int RoleID { get; set; }

        public int PageID { get; set; }

        public bool View { get; set; }

        public bool Update { get; set; }

        public bool Create { get; set; }

        public bool Delete { get; set; }
    }
}
