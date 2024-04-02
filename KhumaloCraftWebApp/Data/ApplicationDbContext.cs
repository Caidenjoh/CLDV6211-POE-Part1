using Microsoft.EntityFrameworkCore;
using KhumaloCraftWebApp.Models;
using System.Collections.Generic;

namespace KhumaloCraftWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Craftwork> Craftworks { get; set; }
    }
}