using PlaySel.Pages;
using OpenQA.Selenium;
using PlaySel.Drivers;
using PlaySel.Helpers;
using PlaySel.Configuration;

namespace PlaySel.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        IBrowserDriver BrowserDriver;
        IActionWarpper _actionWarpper;
        LoginPage _loginPage;
      
        ScenarioContext _scenariocontext;
        public CalculatorStepDefinitions(IBrowserDriver browserDriver,IActionWarpper actionWarpper,ScenarioContext scenariocontext) {
            BrowserDriver = browserDriver;
            _actionWarpper = actionWarpper;
            _loginPage= new LoginPage(BrowserDriver._driver,_actionWarpper);
            _scenariocontext = scenariocontext;
        }
        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {

            _loginPage.navigate(_scenariocontext["URL"].ToString()!);
           
           
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

          
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

           
        }
    }
}
