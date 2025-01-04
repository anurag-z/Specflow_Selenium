using Microsoft.Extensions.DependencyInjection;
using PlaySel.Configuration;
using PlaySel.Drivers;
using PlaySel.Helpers;
using PlaySel.Logs;
using PlaySel.Repord;
using RestSharp;
using SolidToken.SpecFlow.DependencyInjection;
using Specflow_Selenium_Parallel.API_Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySel
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateService()
        { 
            var service= new ServiceCollection();
            service.AddScoped<IBrowserDriver, BrowserDriver>();
            service.AddScoped<IExtentManager, ExtentManager>();
            service.AddSingleton(Config.loadconfig());
            service.AddScoped<IAppLogger, Log4netLogger>();
            service.AddScoped<IActionWarpper, ActionWarpper>();
            service.AddScoped<IRest_Client, Rest_Client>();
            return service;
        }
    }
}
