using Domain.Model;
using Domain.Persistence;
using Domain.Services;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests.Services
{
    public class EmployeeServiceTest
    {
        protected readonly IEmployeeService service;
        protected readonly Mock<IReadEmployee> readEmployee;
        protected readonly Mock<IWriteEmployee> writeEmployee;

        protected EmployeeServiceTest()
        {
            readEmployee = new Mock<IReadEmployee>();
            writeEmployee = new Mock<IWriteEmployee>();
            service = new EmployeeService(readEmployee.Object, writeEmployee.Object);
        }

        public class CreateEmployee : EmployeeServiceTest
        {
            [Fact]
            public async Task Should_PersistEmployee()
            {
                // Arrange
                var newEmployee = new Employee { Id = default };

                var newEmployeeId = Guid.NewGuid();
                writeEmployee
                    .Setup(s => s.CreateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(new Employee { Id = newEmployeeId });

                // Act
                var actual = await service.CreateEmployeeAsync(newEmployee);

                // Assert
                actual.Item1.Should().Be(ServiceResult.Created);
                actual.Item2.Should().NotBeNull();
                actual.Item2?.Id.Should().Be(newEmployeeId);
            }

            [Fact]
            public async Task Should_UseProvidedIdWhenPersistingNewEmployee()
            {
                // Arrange
                var newEmployeeId = Guid.NewGuid();
                var newEmployee = new Employee { Id = newEmployeeId };

                writeEmployee
                    .Setup(s => s.CreateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(new Employee());

                // Act
                var actual = await service.CreateEmployeeAsync(newEmployee);

                // Assert
                actual.Item1.Should().Be(ServiceResult.Created);
                actual.Item2.Should().NotBeNull();

                writeEmployee
                    .Verify(
                        s => s.CreateEmployeeAsync(It.Is<Employee>(e => e.Id == newEmployeeId)),
                        Times.Once);
            }

            [Fact]
            public async Task Should_ReturnErrorWhenCreationFails()
            {
                // Arrange
                var newEmployee = new Employee { Id = default };

                writeEmployee
                    .Setup(s => s.CreateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(default(Employee));

                // Act
                var actual = await service.CreateEmployeeAsync(newEmployee);

                // Assert
                actual.Item1.Should().Be(ServiceResult.Error);
                actual.Item2.Should().BeNull();
            }
        }

        public class UpdateEmployee : EmployeeServiceTest
        {
            [Fact]
            public async Task Should_PersistExistingEmployee()
            {
                // Arrange
                var employeeId = Guid.NewGuid();
                var employee = new Employee();

                readEmployee
                    .Setup(s => s.GetEmployee(employeeId))
                    .Returns(new Employee { Id = employeeId });
                writeEmployee
                    .Setup(s => s.UpdateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(new Employee { Id = employeeId });

                // Act
                var actual = await service.UpdateEmployeeAsync(employeeId, employee);

                // Assert
                actual.Item1.Should().Be(ServiceResult.Updated);
                actual.Item2.Should().NotBeNull();
            }

            [Fact]
            public void Should_UseProvidedIdWhenPersistingExistingEmployee()
            {
                // Arrange
                var employeeId = Guid.NewGuid();
                var someOtherIgnoredId = Guid.NewGuid();
                var employee = new Employee { Id = someOtherIgnoredId };

                readEmployee
                    .Setup(s => s.GetEmployee(employeeId))
                    .Returns(new Employee { Id = employeeId });
                writeEmployee
                    .Setup(s => s.UpdateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(new Employee { Id = employeeId });

                // Act
                service.UpdateEmployeeAsync(employeeId, employee);

                // Assert
                writeEmployee
                    .Verify(
                        s => s.UpdateEmployeeAsync(It.Is<Employee>(e => e.Id == employeeId)),
                        Times.Once);
            }

            [Fact]
            public async Task Should_ReturnErrorWhenUpdateFails()
            {
                // Arrange
                var employeeId = Guid.NewGuid();
                var employee = new Employee();

                readEmployee
                    .Setup(s => s.GetEmployee(employeeId))
                    .Returns(new Employee { Id = employeeId });
                writeEmployee
                    .Setup(s => s.UpdateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(default(Employee));

                // Act
                var actual = await service.UpdateEmployeeAsync(employeeId, employee);

                // Assert
                actual.Item1.Should().Be(ServiceResult.Error);
                actual.Item2.Should().BeNull();
            }

            [Fact]
            public async Task Should_CreateNewEmployeeWhenNotExisting()
            {
                // Arrange
                var employeeId = Guid.NewGuid();
                var employee = new Employee();

                readEmployee
                    .Setup(s => s.GetEmployee(employeeId))
                    .Returns(default(Employee));
                writeEmployee
                    .Setup(s => s.CreateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync(new Employee { Id = employeeId });

                // Act
                var actual = await service.UpdateEmployeeAsync(employeeId, employee);

                // Assert
                actual.Item1.Should().Be(ServiceResult.Created);
                actual.Item2.Should().NotBeNull();

                writeEmployee
                    .Verify(
                        s => s.CreateEmployeeAsync(It.Is<Employee>(e => e.Id == employeeId)),
                        Times.Once);
            }
        }
    }
}
