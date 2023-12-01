using FundManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
    }
}
