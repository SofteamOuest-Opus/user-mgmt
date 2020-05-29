using DatabaseInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInfrastructure.Tests
{
    public class UserMgmtContextTest
    {
        public class Add : UserMgmtContextTest
        {
            [Fact]
            public async Task Should_AddWritesToDatabase()
            {
                // Arrange
                var options = new DbContextOptionsBuilder<UserMgmtContext>()
                    .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                    .Options;

                // Act
                using (var context = new UserMgmtContext(options))
                {
                    context.Add(new EmployeeEntity
                    {
                        FirstName = "Stephen",
                        LastName = "Hawking",
                        Email = "me@example.com"
                    });
                    await context.SaveChangesAsync();
                }

                // Assert
                using (var context = new UserMgmtContext(options))
                {
                    Assert.Equal(1, context.Employees.Count());
                    Assert.Equal("Stephen", context.Employees.Single().FirstName);
                }
            }
        }
    }
}