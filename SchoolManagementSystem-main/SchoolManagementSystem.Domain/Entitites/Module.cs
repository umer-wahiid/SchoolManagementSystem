namespace SchoolManagementSystem.Domain.Entitites
{
    public class Module
    {
        public int ModuleID { get; set; }

        public string Name { get; set; }

        public bool show_on_main { get; set; }

        public bool show_on_settings { get; set; }
    }
}
