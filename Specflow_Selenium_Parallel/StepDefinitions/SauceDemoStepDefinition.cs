
using LW.Pages;
using NUnit.Framework;
using PlaySel.Configuration;
using PlaySel.Drivers;
using PlaySel.Helpers;
using PlaySel.Modal;
using PlaySel.Pages;
using PlaySel.Repord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace LW.StepDefinitions
{
    [Binding, Scope(Tag = "SauceDemo")]
    internal class SauceDemoStepDefinition
    {
        IBrowserDriver BrowserDriver;
        IActionWarpper _actionWarpper;
        LoginPage _loginPage;
        MenuPage _menuPage;
        IExtentManager _extentManager;
        ScenarioContext _scenarioContext;

        public SauceDemoStepDefinition(IBrowserDriver browserDriver, IActionWarpper actionWarpper, ScenarioContext scenariocontext,IExtentManager extentManager)
        {
            BrowserDriver = browserDriver;
            _actionWarpper = actionWarpper;
            _loginPage = new LoginPage(BrowserDriver._driver, _actionWarpper);
            _menuPage = new MenuPage(BrowserDriver._driver, _actionWarpper);
            _scenarioContext = scenariocontext;
            _extentManager = extentManager;

        }

    
        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            Appconfig_DTO dt = _scenarioContext.Get<Appconfig_DTO>();
            string url = dt.Url;
            _loginPage.navigate(url);

           

        }

        [When(@"I Login Application")]
        public void WhenILoginApplication(Table table)
        {
            dynamic items = table.CreateDynamicInstance();

            Console.WriteLine(items.Username);
            _loginPage.Login_details(items.Username, items.Password);
        }
      

        [Then(@"I verify Landing Page Success login ""([^""]*)""")]
        public void ThenIVerifyLandingPageSuccessLogin(string products)
        {
            try
            {
                string suceess = _loginPage.login_success();
                Assert.True(suceess.Equals(products));
                _extentManager.LogTestResult("Pass", "");
            }
            catch (Exception ex)
            {
                _extentManager.LogTestResult("Fail", _scenarioContext.StepContext.StepInfo.Text + " : Exception" + ex.Message);
                throw;
            }
        }

        [Given(@"I click on Left Side Menu")]
        public void GivenIClickOnLeftSideMenu()
        {
            try
            {
                _menuPage.Left_bar();
                _extentManager.LogTestResult("Pass", "");
            }
            catch (Exception ex) 
            {
                _extentManager.LogTestResult("Fail", _scenarioContext.StepContext.StepInfo.Text + " : Exception" +ex.Message);
                throw;
            }
        }

        [Then(@"I Verify Left side Menu")]
        public void ThenIVerifyLeftSideMenu(Table table)
        {
            try
            {
                dynamic items = table.CreateDynamicSet();
                List<string> menuls = new List<string>();
                foreach (var item in items)
                {
                    menuls.Add(item.Menu);
                }
                Assert.True(menuls.SequenceEqual(_menuPage.menulist()));
            }
            catch (Exception ex)
            {
                _extentManager.LogTestResult("Fail", _scenarioContext.StepContext.StepInfo.Text + " : Exception" + ex.Message);
                throw;
            }
        }


        [When(@"I click on Left Side Menu")]
        public void WhenIClickOnLeftSideMenu()
        {
          //  _menupage.Left_bar();
        }

    }
}
