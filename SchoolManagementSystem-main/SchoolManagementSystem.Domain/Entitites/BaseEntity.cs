using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entitites
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; } = "Default";
    }
}
