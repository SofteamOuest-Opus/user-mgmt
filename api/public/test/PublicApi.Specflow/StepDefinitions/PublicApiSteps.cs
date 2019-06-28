using System;
using TechTalk.SpecFlow;

namespace PublicApi.SpecFlow.StepDefinitions
{
    [Binding]
    public class PublicApiSteps
    {
        [Given(@"an Employee with valid credentials")]
        public void GivenAnEmployeeWithValidCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"an Employee list")]
        public void GivenAnEmployeeList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"an Employee")]
        public void GivenAnEmployee()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"an Administrator")]
        public void GivenAnAdministrator()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"an authenticated external application")]
        public void GivenAnAuthenticatedExternalApplication()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I login as this Employee")]
        public void WhenILoginAsThisEmployee()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I login as this Administrator")]
        public void WhenILoginAsThisAdministrator()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I bulk insert this list")]
        public void WhenIBulkInsertThisList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"that external application requests for personal data of this Employee")]
        public void WhenThatExternalApplicationRequestsForPersonalDataOfThisEmployee()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"this employee is updated")]
        public void WhenThisEmployeeIsUpdated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I can access the application according to my access rights")]
        public void ThenICanAccessTheApplicationAccordingToMyAccessRights()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"all employees are created or updated")]
        public void ThenAllEmployeesAreCreatedOrUpdated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it can read personal data of this Employee")]
        public void ThenItCanReadPersonalDataOfThisEmployee()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"that external application is notified of the update")]
        public void ThenThatExternalApplicationIsNotifiedOfTheUpdate()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
