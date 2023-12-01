using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfoliosList
{
    public class GetPortfoliosListQuery : IRequest<List<PortfolioListDto>>
    {
    }
}
