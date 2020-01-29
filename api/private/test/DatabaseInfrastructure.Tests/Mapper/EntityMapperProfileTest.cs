using AutoMapper;
using DatabaseInfrastructure.Mapper;
using NUnit.Framework;

namespace DatabaseInfrastructure.Tests.Mapper
{
    public class EntityMapperProfileTest
    {
        internal class Constructor: EntityMapperProfileTest
        {
            [Test]
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
