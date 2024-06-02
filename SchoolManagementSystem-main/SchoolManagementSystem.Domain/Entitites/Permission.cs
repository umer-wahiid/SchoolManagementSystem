namespace SchoolManagementSystem.Domain.Entitites
{
    public class Permission : BaseEntity
    {
        public int PermissionID { get; set; }

        public bool View { get; set; }

        public bool Update { get; set; }

        public bool Create { get; set; }

        public bool Delete { get; set; }

        public int RoleID { get; set; }

        public Role Role { get; set; }

        public int PageID { get; set; }

        public Page Page { get; set; }
    }
}
