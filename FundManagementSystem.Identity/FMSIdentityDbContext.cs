using FundManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Identity
{
    public class FMSIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public FMSIdentityDbContext()
        {

        }

        public FMSIdentityDbContext(DbContextOptions<FMSIdentityDbContext> options) : base(options)
        {

        }
    }
}
