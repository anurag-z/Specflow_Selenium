using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySel.Helpers
{
    public static class ByExtension
    {
      
            // Extension method for XPath locator (dynamic with parameters)
            public static By ByXPath(this IWebDriver driver, string xpathTemplate, params object[] args)
            {
                string xpath = string.Format(xpathTemplate, args);
                return By.XPath(xpath);
            }

            // Extension method for ID locator
            public static By ById(this IWebDriver driver, string id)
            {
                return By.Id(id);
            }

            // Extension method for CSS locator (dynamic with parameters)
            public static By ByCss(this IWebDriver driver, string cssTemplate, params object[] args)
            {
                string cssSelector = string.Format(cssTemplate, args);
                return By.CssSelector(cssSelector);
            }

            // Extension method for Link Text locator
            public static By ByLinkText(this IWebDriver driver, string linkText)
            {
                return By.LinkText(linkText);
            }

            // Extension method for Partial Link Text locator
            public static By ByPartialLinkText(this IWebDriver driver, string partialLinkText)
            {
                return By.PartialLinkText(partialLinkText);
            }
        }
    }

