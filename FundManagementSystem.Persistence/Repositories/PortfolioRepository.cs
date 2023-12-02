using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Persistence.Repositories
{
    public class PortfolioRepository : BaseRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(FMSDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsPortfolioNameAndTypeUnique(string name, string type)
        {
            var isExists = _dbContext.Portfolios.Any(e => e.Name.Equals(name) && e.Type.Equals(type));
            return Task.FromResult(!isExists);
        }
    }
}
