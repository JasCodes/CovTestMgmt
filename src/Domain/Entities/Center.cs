using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovTestMgmt.Domain.Entities
{
    public class Center : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}