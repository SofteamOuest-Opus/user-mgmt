using DatabaseInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInfrastructure.Tests
{
    public class UserMgmtContextTest
    {
        public class Add : UserMgmtContextTest
        {
            [Test]
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
                    Assert.AreEqual(1, context.Employees.Count());
                    Assert.AreEqual("Stephen", context.Employees.Single().FirstName);
                }
            }
        }
    }
}