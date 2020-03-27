using Domain.Model;
using Domain.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PrivateApi.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PrivateApi.Tests.Controllers
{
    public class EmployeeControllerTest
    {
        protected Mock<IEmployeeService> employeeService;
        protected EmployeeController controller;

        protected EmployeeControllerTest()
        {
            employeeService = new Mock<IEmployeeService>();
            controller = new EmployeeController(employeeService.Object);
        }

        public class ShowEmployeeById : EmployeeControllerTest
        {
            [Fact]
            public void Should_ReturnExistingEmployee()
            {
                // Arrange
                Guid id = Guid.NewGuid();
                employeeService.Setup(s => s.GetEmployee(id)).Returns(new Employee());

                // Act
                var actual = controller.ShowEmployeeById(id);

                // Assert
                actual.Should().BeAssignableTo<OkObjectResult>();
            }

            [Fact]
            public void Should_ReturnNotFoundIfMissingEmployee()
            {
                // Arrange
                Guid id = Guid.NewGuid();
                employeeService.Setup(s => s.GetEmployee(id)).Returns(default(Employee));

                // Act
                var actual = controller.ShowEmployeeById(id);

                // Assert
                actual.Should().BeAssignableTo<NotFoundResult>();
            }
        }

        public class UpdateEmployee : EmployeeControllerTest
        {
            [Fact]
            public async Task Should_UpdateEmployee()
            {
                // Arrange
                var employee = new Employee();
                Guid id = Guid.NewGuid();

                employeeService
                    .Setup(s => s.UpdateEmployeeAsync(It.IsAny<Guid>(), It.IsAny<Employee>()))
                    .ReturnsAsync((ServiceResult.Updated, new Employee()));

                // Act
                var actual = await controller.UpdateEmployee(id, employee);

                // Assert
                actual.Should().BeAssignableTo<OkObjectResult>();
            }

            [Fact]
            public async Task Should_ReturnCreatedIfNewEmployee()
            {
                // Arrange
                var employee = new Employee();
                Guid id = Guid.NewGuid();

                employeeService
                    .Setup(s => s.UpdateEmployeeAsync(It.IsAny<Guid>(), It.IsAny<Employee>()))
                    .ReturnsAsync((ServiceResult.Created, new Employee()));

                // Act
                var actual = await controller.UpdateEmployee(id, employee);

                // Assert
                actual.Should().BeAssignableTo<CreatedAtActionResult>();
            }

            [Fact]
            public async Task Should_ReturnBadRequestIfInvalid()
            {
                // Arrange
                var employee = new Employee();
                Guid id = Guid.NewGuid();

                controller.ModelState.AddModelError("error", "invalid");

                // Act
                var actual = await controller.UpdateEmployee(id, employee);

                // Assert
                actual.Should().BeAssignableTo<BadRequestObjectResult>();
            }
        }

        public class CreateEmployee : EmployeeControllerTest
        {
            [Fact]
            public async Task Should_AddEmployee()
            {
                // Arrange
                var employee = new Employee();

                employeeService
                    .Setup(s => s.CreateEmployeeAsync(It.IsAny<Employee>()))
                    .ReturnsAsync((ServiceResult.Created, new Employee()));

                // Act
                var actual = await controller.CreateEmployee(employee);

                // Assert
                actual.Should().BeAssignableTo<CreatedAtActionResult>();
            }

            [Fact]
            public async Task Should_ReturnBadRequestIfInvalid()
            {
                // Arrange
                var employee = new Employee();

                controller.ModelState.AddModelError("error", "invalid");

                // Act
                var actual = await controller.CreateEmployee(employee);

                // Assert
                actual.Should().BeAssignableTo<BadRequestObjectResult>();
            }
        }
    }
}
