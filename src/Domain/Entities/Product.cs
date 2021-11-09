using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovTestMgmt.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string title { get; set; }
    }
}