using FluentValidation;
using FundManagementSystem.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public CreatePortfolioCommandValidator(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository= portfolioRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.EndDate)
                .GreaterThan(DateTime.Now.AddDays(1));

            RuleFor(p => p.ClientId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            // Custom Validator
            RuleFor(e => e)
                .MustAsync(PortfolioNameAndTypeUnique)
                .WithMessage("A portfolio with the same name and type already exists");
                

        }

        private async Task<bool> PortfolioNameAndTypeUnique(CreatePortfolioCommand e, CancellationToken token)
        {
            return await _portfolioRepository.IsPortfolioNameAndTypeUnique(e.Name, e.Type);
        }
    }
}
