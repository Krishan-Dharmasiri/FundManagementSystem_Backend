using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Application.Exceptions;
using FundManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, CreatePortfolioCommandResponse>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public CreatePortfolioCommandHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<CreatePortfolioCommandResponse> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var createPortfolioCommandResponse = new CreatePortfolioCommandResponse();
            
            var validator = new CreatePortfolioCommandValidator(_portfolioRepository);
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count> 0)
            {
                createPortfolioCommandResponse.Success = false;
                createPortfolioCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createPortfolioCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }                
            }
            if (createPortfolioCommandResponse.Success)
            {
                var portfolio = _mapper.Map<Portfolio>(request);
                portfolio = await _portfolioRepository.AddAsync(portfolio);
                createPortfolioCommandResponse.Portfolio = _mapper.Map<CreatePortfolioDto>(portfolio);
            }

            return createPortfolioCommandResponse;
        }
    }
}
