using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfoliosList
{
    public class GetPortfoliosListQueryHandler : IRequestHandler<GetPortfoliosListQuery, List<PortfolioListDto>>
    {
        private readonly IAsyncRepository<Portfolio> _portfoliosRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPortfoliosListQueryHandler> _logger;

        public GetPortfoliosListQueryHandler(IMapper mapper, IAsyncRepository<Portfolio> portfolioRepository, 
            ILogger<GetPortfoliosListQueryHandler> logger)
        {
            _mapper = mapper;
            _portfoliosRepository = portfolioRepository;
            _logger = logger;
        }

        public async Task<List<PortfolioListDto>> Handle(GetPortfoliosListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching Portfolios from the DB Started.");
            var allPortfolios = (await _portfoliosRepository.GetAllAsync())
                                                .OrderByDescending(x => x.CreatedDate);
            _logger.LogInformation("Fetching Portfolios form the DB Finished");

            return _mapper.Map<List<PortfolioListDto>>(allPortfolios);
        }
    }
}
