using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmix.Covid19.Models;

namespace Pharmix.Covid19.Services.Interfaces
{
    public interface ICovid19Context 
    {
        DbSet<WorldMeterData> WorldMeterReports { get; set; }
        DbSet<JohnHopkinsData> JohnHopkinsData { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}