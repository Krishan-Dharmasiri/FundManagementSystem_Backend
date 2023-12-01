using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public DeletePortfolioCommandHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolioToDelete = await _portfolioRepository.GetByIdAsync(request.PortfolioId);
            await _portfolioRepository.DeleteAsync(portfolioToDelete);
        }
    }
}
