using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfolioDetail
{
    public class GetPortfolioDetailQuery : IRequest<PortfolioDetailDto>
    {
        public Guid Id { get; set; }
    }
}
