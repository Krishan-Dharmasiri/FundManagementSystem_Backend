using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(FMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
