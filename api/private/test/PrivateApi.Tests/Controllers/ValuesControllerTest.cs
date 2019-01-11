using FluentAssertions;
using NUnit.Framework;
using PrivateApi.Controllers;

namespace PrivateApi.Tests.Controllers
{
    public class ValuesControllerTest
    {
        protected ValuesController ControllerUnderTest;

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
                result.Should().HaveCount(2);
            }
        }
    }
}