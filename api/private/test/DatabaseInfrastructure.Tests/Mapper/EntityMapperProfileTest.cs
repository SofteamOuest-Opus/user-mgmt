using AutoMapper;
using DatabaseInfrastructure.Mapper;
using Xunit;

namespace DatabaseInfrastructure.Tests.Mapper
{
    public class EntityMapperProfileTest
    {
        public class Constructor: EntityMapperProfileTest
        {
            [Fact]
            public void Should_ConfigureMapper()
            {
                // Act
                var config = new MapperConfiguration(cfg => cfg.AddProfile<EntityMapperProfile>());

                // Assert
                config.AssertConfigurationIsValid();
            }
        }
    }
}
