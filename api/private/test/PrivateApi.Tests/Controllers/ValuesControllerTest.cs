using FluentAssertions;
using NUnit.Framework;
using PrivateApi.Controllers;

namespace PrivateApi.Tests.Controllers
{
    public class ValuesControllerTest
    {
#nullable disable
        protected ValuesController ControllerUnderTest;
#nullable restore

        [SetUp]
        public void Setup()
        {
            ControllerUnderTest = new ValuesController();
        }

        public class Get : ValuesControllerTest
        {
            [Test]
            public void ShouldReturn2Elements()
            {
                // Act
                var result = ControllerUnderTest.Get();

                // Assert
                result.Value.Should().HaveCount(2);
            }
        }
    }
}