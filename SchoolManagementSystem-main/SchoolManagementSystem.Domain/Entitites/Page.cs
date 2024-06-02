namespace SchoolManagementSystem.Domain.Entitites
{
    public class Page
    {
        public int PageID { get; set; }

        public string Name { get; set; }

        public string Route { get; set; }

        public int ModuleID { get; set; }

        public Module Module { get; set; }

        public bool show_on_main { get; set; }

        public bool show_on_setting { get; set; }

        public bool show_on_nav { get; set; }
    }
}
