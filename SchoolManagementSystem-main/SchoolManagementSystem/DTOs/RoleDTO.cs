namespace SchoolManagementSystem.DTOs
{
    public record RoleDTO
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }
    }
}
