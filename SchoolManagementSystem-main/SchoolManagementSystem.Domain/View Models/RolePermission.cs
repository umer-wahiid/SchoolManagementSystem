using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class Permission
    {
        public string PermissionID { get; set; }
        public List<ModuleViewModel> ModuleViewModels { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class ModuleViewModel
    {
        [Key]
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool IsModuleAllow { get; set; }
        public List<PageViewModel> PageViewModel { get; set; }
    }

    public class ActionViewModel
    {
        [Key]
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public bool IsActionAllow { get; set; }
    }

    public class PageViewModel
    {
        [Key]
        public int PageId { get; set; }
        public string PageName { get; set; }
        public bool IsPageAllow { get; set; }
        public List<ActionViewModel> ActionViewModel { get; set; }
    }
}
