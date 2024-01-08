using AutoMapper;
using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfoliosList;
using FundManagementSystem.Application.Profiles;
using FundManagementSystem.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace FundManagementSystem.Application.UnitTests.Portfolios.Queries
{
    public class GetPortfolioListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPortfolioRepository> _portfolioRepositoryMock;

        public GetPortfolioListQueryHandlerTests()
        {
            _portfolioRepositoryMock = RepositoryMocks.GetPortfolioRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        //[Fact]
        //public async Task GetPortfolioListTest()
        //{
        //    var handler = new GetPortfoliosListQueryHandler(_mapper, _portfolioRepositoryMock.Object);

        //    var result = await handler.Handle(new GetPortfoliosListQuery(), CancellationToken.None);

        //    result.ShouldBeOfType<List<PortfolioListDto>>();

        //    result.Count.ShouldBe(2);
        //}
    }
}