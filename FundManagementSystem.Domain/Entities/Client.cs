using FundManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // A client can have multiple portfolios
        public ICollection<Portfolio>? Portfolios { get; set; }

    }
}
