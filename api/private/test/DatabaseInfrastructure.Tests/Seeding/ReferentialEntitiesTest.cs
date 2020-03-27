using AutoMapper;
using DatabaseInfrastructure.Mapper;
using DatabaseInfrastructure.Seeding;
using Domain.Referential;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace DatabaseInfrastructure.Tests.Seeding
{
    public class ReferentialEntitiesTest
    {
        protected IMapper mapper;

        public ReferentialEntitiesTest()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>());
            mapper = config.CreateMapper();
        }

        public class Occupations : ReferentialEntitiesTest
        {
            [Fact]
            public void Should_ReturnDefaultOccupations()
            {
                // Arrange
                using var identification = new Identification();
                var defaults = new ReferentialDefaults(identification);
                var entities = new ReferentialEntities(defaults, mapper);

                // Act
                var actual = entities.Occupations.ToArray();

                // Assert
                actual.Should().HaveCount(defaults.Occupations.Count());
                actual.Select(x => x.Name).Should().Contain(defaults.Occupations.Select(x => x.Name));
            }
        }
    }
}
