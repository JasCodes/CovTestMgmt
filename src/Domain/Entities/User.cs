using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovTestMgmt.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }
        public string NationalId { get; set; }
    }
}