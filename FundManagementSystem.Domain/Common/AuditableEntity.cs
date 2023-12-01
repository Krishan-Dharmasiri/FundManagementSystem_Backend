using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Domain.Common
{
    public  class AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set;}
    }
}
