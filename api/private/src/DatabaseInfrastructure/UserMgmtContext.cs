using DatabaseInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseInfrastructure
{
    public class UserMgmtContext : DbContext
    {
#nullable disable
        // All of the DBSet<TEntity> properties will be populated by the DBContext itself in the super constructor.
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<OfficeEntity> Offices { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<OccupationEntity> Occupations { get; set; }
#nullable restore

        public UserMgmtContext(DbContextOptions<UserMgmtContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Manager);
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.HumanResourceManager);
        }
    }
}
