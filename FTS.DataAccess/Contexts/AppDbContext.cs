using FTS.DataAccess.Constants;
using FTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FTS.Data.DbContexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Constant.STRING_CONNECTION);
    }

    public DbSet<NuritionPlan> NuritionPlans { get; set; }
    public DbSet<ProgressRecord> ProgressRecords { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkOut> WorkOuts { get; set; }
}