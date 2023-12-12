using AutoMapper;
using FundManagementSystem.Application.Features.Portfolios.Commands.CreatePortfolio;
using FundManagementSystem.Application.Features.Portfolios.Commands.DeletePortfolio;
using FundManagementSystem.Application.Features.Portfolios.Commands.UpdatePortfolio;
using FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfolioDetail;
using FundManagementSystem.Application.Features.Portfolios.Queries.GetPortfoliosList;
using FundManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Portfolio, PortfolioListDto>().ReverseMap();
            CreateMap<Portfolio, PortfolioDetailDto>().ReverseMap();
            CreateMap<Portfolio, CreatePortfolioCommand>().ReverseMap();
            CreateMap<Portfolio, UpdatePortfolioCommand>().ReverseMap();
            CreateMap<Portfolio, DeletePortfolioCommand>().ReverseMap();
            CreateMap<Portfolio, CreatePortfolioDto>().ReverseMap();

            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
}
