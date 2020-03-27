using Domain.Model;
using FluentAssertions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Domain.Tests.Model
{
    public class EmployeeTest
    {
        public class Validation
        {
            [Fact]
            public void Should_ValidateEmployee()
            {
                // Arrange
                var incompleteEmployee = new Employee
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@doe.com"
                };

                var validationContext = new ValidationContext(incompleteEmployee, null, null);
                var validationResults = new List<ValidationResult>();

                // Act
                var actual = Validator.TryValidateObject(incompleteEmployee, validationContext, validationResults, true);

                // Assert
                actual.Should().BeTrue();
                validationResults.Should().BeEmpty();
            }

            [Fact]
            public void Should_NotValidateIncompleteEmployee()
            {
                // Arrange
                var incompleteEmployee = new Employee();
                var validationContext = new ValidationContext(incompleteEmployee, null, null);
                var validationResults = new List<ValidationResult>();

                // Act
                var actual = Validator.TryValidateObject(incompleteEmployee, validationContext, validationResults, true);

                // Assert
                actual.Should().BeFalse();
                validationResults.Should().HaveCountGreaterThan(0);
            }
        }
    }
}
