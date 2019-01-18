using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint_06
{
    public class SpaceContext : DbContext
    {
        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<Ravioli> Raviolis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = Spaceships;");
        }
    }
}
