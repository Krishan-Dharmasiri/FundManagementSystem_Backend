using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfolioDetail
{
    public class GetPortfolioDetailQueryHandler : IRequestHandler<GetPortfolioDetailQuery, PortfolioDetailDto>
    {
        private IAsyncRepository<Portfolio> _portfolioRepository;
        private IAsyncRepository<Client> _clientRepository;
        private IMapper _mapper;

        public GetPortfolioDetailQueryHandler(IAsyncRepository<Portfolio> portfolioRepository,
                            IAsyncRepository<Client> clientRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<PortfolioDetailDto> Handle(GetPortfolioDetailQuery request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(request.Id);
            var portfolioDetailDto = _mapper.Map<PortfolioDetailDto>(portfolio);

            var client = await _clientRepository.GetByIdAsync(portfolio.ClientId);

            portfolioDetailDto.Client = _mapper.Map<ClientDto>(client);

            return portfolioDetailDto;
        }
    }
}
