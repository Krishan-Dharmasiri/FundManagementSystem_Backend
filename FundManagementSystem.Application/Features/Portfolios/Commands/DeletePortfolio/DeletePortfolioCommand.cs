using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommand : IRequest
    {
        public Guid PortfolioId { get; set; }
    }
}
