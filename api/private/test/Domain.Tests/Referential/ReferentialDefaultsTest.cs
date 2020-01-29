using FluentAssertions;
using System.Linq;
using Xunit;
using Domain.Referential;

namespace Domain.Tests.Referential
{
    public class ReferentialDefaultsTest
    {
        public class Occupations : ReferentialDefaultsTest
        {
            [Fact]
            public void Should_GenerateIdsDynamically()
            {
                // Arrange
                using var identification = new Identification();
                var defaults = new ReferentialDefaults(identification);

                // Act
                var actual = defaults.Occupations.ToArray();

                // Assert
                actual.Should().OnlyContain(x => x.Id != null);
            }

            [Fact]
            public void Should_GenerateDistinctIds()
            {
                // Arrange
                using var identification = new Identification();
                var defaults = new ReferentialDefaults(identification);

                // Act
                var actual = defaults.Occupations.ToArray();

                // Assert
                actual.Select(x => x.Id).Should().OnlyHaveUniqueItems();
            }
        }
    }
}
