using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Application.Profiles;
using FundManagementSystem.Application.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.UnitTests.Portfolios.Commands
{
    public class CreatePortfolioTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPortfolioRepository> _portfolioRepositoryMock;

        public CreatePortfolioTests()
        {
            _portfolioRepositoryMock = RepositoryMocks.GetPortfolioRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
    }
}
