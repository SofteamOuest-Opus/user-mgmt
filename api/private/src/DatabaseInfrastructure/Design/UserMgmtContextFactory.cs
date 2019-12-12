using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatabaseInfrastructure.Design
{
    class UserMgmtContextFactory : IDesignTimeDbContextFactory<UserMgmtContext>
    {
        public UserMgmtContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserMgmtContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=user_mgmt_private_db;Username=user_mgmt_private;Password=******");

            return new UserMgmtContext(optionsBuilder.Options);
        }
    }
}
