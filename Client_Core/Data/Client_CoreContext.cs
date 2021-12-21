using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Client_Core.Models;

namespace Client_Core.Data
{
    public class Client_CoreContext : DbContext
    {
        public Client_CoreContext (DbContextOptions<Client_CoreContext> options)
            : base(options)
        {
        }

        public DbSet<Client_Core.Models.Covid_Dto> Covid_Dto { get; set; }
    }
}
