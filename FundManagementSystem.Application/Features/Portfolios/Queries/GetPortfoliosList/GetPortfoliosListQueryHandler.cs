using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfoliosList
{
    public class GetPortfoliosListQueryHandler : IRequestHandler<GetPortfoliosListQuery, List<PortfolioListDto>>
    {
        private readonly IAsyncRepository<Portfolio> _portfoliosRepository;
        private readonly IMapper _mapper;

        public GetPortfoliosListQueryHandler(IMapper mapper, IAsyncRepository<Portfolio> portfolioRepository)
        {
            _mapper = mapper;
            _portfoliosRepository = portfolioRepository;
        }

        public async Task<List<PortfolioListDto>> Handle(GetPortfoliosListQuery request, CancellationToken cancellationToken)
        {
            var allPortfolios = (await _portfoliosRepository.GetAllAsync())
                                                .OrderByDescending(x => x.CreatedDate);
            return _mapper.Map<List<PortfolioListDto>>(allPortfolios);
        }
    }
}
