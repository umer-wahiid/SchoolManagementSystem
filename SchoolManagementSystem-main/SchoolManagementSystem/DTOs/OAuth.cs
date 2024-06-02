namespace SchoolManagementSystem.DTOs
{
    public record OAuth
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}