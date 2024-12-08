using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarStatusEntity> CarStatus { get; set; }
    public DbSet<CarStatusHistory> CarStatusHistories { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<MaintenancePlanningRecord> MaintenancePlanningRecords { get; set; }
    public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<MaintenanceState> MaintenanceStates { get; set; }
    public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}