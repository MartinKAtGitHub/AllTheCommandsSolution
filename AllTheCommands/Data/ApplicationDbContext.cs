
using AllTheCommands.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllTheCommands.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Command> Commands{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
