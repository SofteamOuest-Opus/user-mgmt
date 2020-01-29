using AutoMapper;
using DatabaseInfrastructure.Mapper;
using DatabaseInfrastructure.Seeding;
using Domain.Referential;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace DatabaseInfrastructure.Tests.Seeding
{
    public class ReferentialEntitiesTest
    {
#nullable disable
        protected IMapper mapper;
#nullable restore

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>());
            mapper = config.CreateMapper();
        }

        internal class Occupations : ReferentialEntitiesTest
        {
            [Test]
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
