using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseInfrastructure
{
    public class UserMgmtContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public UserMgmtContext(DbContextOptions<UserMgmtContext> options) : base(options)
        { }
    }
}
