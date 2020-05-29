using AutoMapper;
using DatabaseInfrastructure.Entities;
using DatabaseInfrastructure.Mapper;
using DatabaseInfrastructure.Seeding;
using Domain.Referential;
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
            modelBuilder.Entity<EmployeeEntity>().HasOne(e => e.Manager);
            modelBuilder.Entity<EmployeeEntity>().HasOne(e => e.HumanResourceManager);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>());
            var mapper = config.CreateMapper();

            using var identification = new Identification();
            var defaults = new ReferentialDefaults(identification);
            var entities = new ReferentialEntities(defaults, mapper);

            modelBuilder.Entity<OccupationEntity>().HasData(entities.Occupations);
            modelBuilder.Entity<OfficeEntity>().HasData(entities.Offices);
            modelBuilder.Entity<StatusEntity>().HasData(entities.Statuses);
        }
    }
}
