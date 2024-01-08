using FundManagementSystem.Application.Features.Portfolios.Commands.CreatePortfolio;
using FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfoliosList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FundManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPortfolios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableRateLimiting("concurrency_rate_limiter")]
        public async Task<ActionResult<List<PortfolioListDto>>> GetAllPortfolios()
        {
            var result = await _mediator.Send(new GetPortfoliosListQuery());

            return Ok(result);
        }

        [HttpPost(Name = "AddPortfolio")]
        [EnableRateLimiting("fixed_rate_limiter")]
        public async Task<ActionResult<CreatePortfolioCommandResponse>> Create([FromBody] CreatePortfolioCommand
            createPortfolioCommand)
        {
            var response = await _mediator.Send(createPortfolioCommand);

            return Ok(response);
        }
    }
}
