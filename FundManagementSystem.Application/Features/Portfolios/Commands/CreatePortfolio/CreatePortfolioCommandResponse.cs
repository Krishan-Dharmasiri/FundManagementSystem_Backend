using FundManagementSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandResponse : BaseResponse
    {
        public CreatePortfolioCommandResponse() : base()
        {

        }

        public CreatePortfolioDto Portfolio { get; set; } = default!;
    }
}
