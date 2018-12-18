using FluentAssertions;
using NUnit.Framework;
using UserMgmtBack.Controllers;

namespace UserMgmtBack.Tests.Controllers
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
            public void Test1()
            {
                // Act
                var result = ControllerUnderTest.Get();

                // Assert
                result.Should().HaveCount(2);
            }
        }
    }
}