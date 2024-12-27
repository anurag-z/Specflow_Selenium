using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;


namespace PlaySel.Drivers
{public interface IBrowserDriver
    { 
        IWebDriver _driver { get; }
     
    }

    public class BrowserDriver : IBrowserDriver,IDisposable
    {
        public IWebDriver _driver { get; }
        public BrowserDriver()
        { 
            _driver = createdriver();
        }
        public IWebDriver createdriver()
        { 
            return new ChromeDriver();
            
        }

     

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
