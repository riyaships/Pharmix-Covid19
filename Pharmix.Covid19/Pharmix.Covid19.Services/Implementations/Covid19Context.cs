using Microsoft.EntityFrameworkCore;
using Pharmix.Covid19.Models;
using Pharmix.Covid19.Services.Interfaces;

namespace Pharmix.Covid19.Services.Implementations
{
    public class Covid19Context :DbContext, ICovid19Context
    {
        
        public Covid19Context(DbContextOptions options) : base(options)
        {
            
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JohnHopkinsData>().HasNoKey();
        }

        public DbSet<WorldMeterData> WorldMeterReports { get; set; }
        public DbSet<Models.JohnHopkinsData> JohnHopkinsData { get; set; }
    }
}