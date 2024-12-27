using OpenQA.Selenium;
using PlaySel.Configuration;
using PlaySel.Drivers;
using PlaySel.Logs;
using PlaySel.Modal;
using PlaySel.Repord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySel.Hooks
{
    [Binding]
    public class Hooks
    { 
        private  ScenarioContext _scenarioContext;
        private  IExtentManager _extentManager;
        private   IBrowserDriver _browserDriver;
        private  FeatureContext _featureContext;
        private IAppLogger _appLogger;
        private readonly Appconfig_DTO _appconfig;
        
        public Hooks(IExtentManager extentManager,IAppLogger appLogger, Appconfig_DTO appconfig_DTO)
        {
            _extentManager = extentManager;
            _appLogger = appLogger;
            _appconfig = appconfig_DTO;

        }
       
        [BeforeScenario]
        public  void BeforeScenario(ScenarioContext scenarioContext, IBrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
            _scenarioContext = scenarioContext;
          
            _extentManager.CreateTest(_scenarioContext.ScenarioInfo.Title);
            _extentManager.LogTestResult("Info", "Scenario"+ _scenarioContext.ScenarioInfo.Title + "started.");
           
            _scenarioContext.Set(_appconfig);
            _extentManager.LogTestResult("Info",_appconfig.Url );
            _appLogger.LogInfo(_scenarioContext.ScenarioInfo.Title);


        }
        [AfterScenario]
        public  void AfterScenario()
        {
            if (!(_scenarioContext.TestError == null? true:false))
            {
                ITakesScreenshot screenshotDriver =  _browserDriver._driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();

               
        
                string time = Guid.NewGuid().ToString();

                // string filePath = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net6.0", "Extent_Reports\\");
               
               
                screenshot.SaveAsFile(Directory.GetCurrentDirectory() +@"/Extent_Reports/"+ _scenarioContext.ScenarioInfo.Title+ time + ".Png");
                _extentManager.Attachscreenshot(Directory.GetCurrentDirectory() + @"/Extent_Reports/" + _scenarioContext.ScenarioInfo.Title + time + ".Png", "Screenshot");
            }
            _extentManager.Flush();
        }
        //[AfterFeature]
        //public static void AfterFeature()
        //{
        //    _extentManager.Flush();
        //}
    }
}
