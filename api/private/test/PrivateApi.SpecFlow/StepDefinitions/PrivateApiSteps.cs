using System;
using TechTalk.SpecFlow;

namespace PrivateApi.SpecFlow.StepDefinitions
{
    [Binding]
    public class PrivateApiSteps
    {
        [Given(@"an Employee")]
        public void GivenAnEmployee()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I am logged in as this Employee")]
        public void WhenIAmLoggedInAsThisEmployee()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can view my profile and personal data")]
        public void ThenICanViewMyProfileAndPersonalData()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can edit my personal data")]
        public void ThenICanEditMyPersonalData()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"a Human resource manager")]
        public void GivenAHumanResourceManager()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I am logged in as this Human resource manager")]
        public void WhenIAmLoggedInAsThisHumanResourceManager()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can view that Employee's personal data")]
        public void ThenICanViewThatEmployeeSPersonalData()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can edit that Employee's personal data")]
        public void ThenICanEditThatEmployeeSPersonalData()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can create a new Employee")]
        public void ThenICanCreateANewEmployee()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"an Employee \(former or actual\)")]
        public void GivenAnEmployeeFormerOrActual()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can delete personal data of this Employee")]
        public void ThenICanDeletePersonalDataOfThisEmployee()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
