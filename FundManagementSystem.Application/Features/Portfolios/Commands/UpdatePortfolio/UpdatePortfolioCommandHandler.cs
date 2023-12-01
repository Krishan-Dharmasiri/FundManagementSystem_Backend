using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Commands.UpdatePortfolio
{
    public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public UpdatePortfolioCommandHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolioToUpdate = await _portfolioRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, portfolioToUpdate, typeof(UpdatePortfolioCommand), typeof(Portfolio));
            await _portfolioRepository.UpdateAsync(portfolioToUpdate);
            
        }
    }
}
