using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }
        public DbSet<Command>Commands{ get; set; }
    }
}
