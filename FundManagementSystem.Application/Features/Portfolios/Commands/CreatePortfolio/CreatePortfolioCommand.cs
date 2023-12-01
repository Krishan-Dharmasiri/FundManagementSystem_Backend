using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommand : IRequest<CreatePortfolioCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }        
        public Guid ClientId { get; set; }
        public override string ToString()
        {
            return $"Portfolio Name : {Name}, Type : {Type}, Started On : {StartDate}";
        }
    }
}
