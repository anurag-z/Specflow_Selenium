using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PlaySel.Helpers;

namespace LW.Pages
{
   
    public class MenuPage
    {
        private readonly IWebDriver? _driver;
        private readonly WebDriverWait _wait;
        private readonly IActionWarpper _actionWarpper;
        public MenuPage(IWebDriver driver, IActionWarpper actionWarpper)
        {
            _driver = driver;
            _actionWarpper = actionWarpper;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void Left_bar()
        {
            _actionWarpper.Click(_driver.ByXPath(left_bar));
                    
        }

        public IList<string> menulist()
        { 
            List<string> menulist = new List<string>();
            foreach (IWebElement item in _actionWarpper.FindElements(_driver.ByXPath(menu_element)))
            {
                Thread.Sleep(500);
                menulist.Add(item.Text);
              


            }

            return menulist;
        
        }
        private string left_bar => "//button[text()=\"Open Menu\"]";
        private string menu_element =>"//a[@class=\"bm-item menu-item\"]";
    }


}
