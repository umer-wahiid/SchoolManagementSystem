using SchoolManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class Attendance : BaseEntity
    {
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public AttendanceStatus Status { get; set; }
        public Student Student { get; set; }
    }
}
