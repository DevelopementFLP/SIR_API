using Microsoft.EntityFrameworkCore;
using _53_ReportesDataAccess;

    public class ReportesDbContext : DbContext
    {
        public ReportesDbContext (DbContextOptions<ReportesDbContext> options)
            : base(options)
        {
        }

        public DbSet<reportes> reportes { get; set; } = default!;
    }

