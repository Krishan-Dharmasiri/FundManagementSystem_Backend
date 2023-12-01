using FundManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Domain.Entities
{
    public class Portfolio : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        // A portfolio must  belong to a client
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = default!;
    }
}
