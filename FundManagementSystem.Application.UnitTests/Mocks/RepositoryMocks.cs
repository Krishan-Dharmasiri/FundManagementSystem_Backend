using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IPortfolioRepository> GetPortfolioRepository()
        {
            var clientId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

            var portfolios = new List<Portfolio>
            {
                new Portfolio
                {
                    Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                    ClientId = clientId,
                    Name = "Portfolio One",
                    Type = "EQUITY",
                    StartDate = DateTime.Now,
                    EndDate = null
                },
                new Portfolio
                {
                    Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                    ClientId = clientId,
                    Name = "Portfolio Two",
                    Type = "FIXED_INCOME",
                    StartDate = DateTime.Now,
                    EndDate = null
                }
            };

            var mockPortfolioRepository = new Mock<IPortfolioRepository>();
            mockPortfolioRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(portfolios);

            mockPortfolioRepository.Setup(repo => repo.AddAsync(It.IsAny<Portfolio>()))
                .ReturnsAsync(
                    (Portfolio portfolio) => 
                    {
                        portfolios.Add(portfolio);
                        return portfolio;
                    });

            return mockPortfolioRepository;
        }
    }
}
