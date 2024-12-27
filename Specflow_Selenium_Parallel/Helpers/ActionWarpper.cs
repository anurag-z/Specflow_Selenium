using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlaySel.Drivers;
using PlaySel.Logs;
using SeleniumExtras.WaitHelpers;


namespace PlaySel.Helpers
{   public interface IActionWarpper
    {
        IWebElement FindElement(By locator);
        void NavigateTo(string url);
        public IWebElement WaitForElement(By locator);
        public void Click(By locator);
        public void TypeText(By locator, string text);
        public string GetText(By locator);
        public void TakeScreenshot(string filePath);
        public void SelectDropdownByText(By by, string text);
        public void SelectDropdownByValue(By by, string value);
        public List<string> GetDropdownOptions(By by);
        public void SetCheckbox(By by, bool check);
        public void ScrollToElement(By by);
        public IList<IWebElement> FindElements(By locator);

    }
    public class ActionWarpper:IActionWarpper
    {
        private readonly IWebDriver _driver;
        private readonly IAppLogger _logger;
        private WebDriverWait wait;
        public ActionWarpper(IBrowserDriver driver, IAppLogger logger, int timeoutInSeconds = 30) 
        {
            _driver = driver._driver;
            _logger = logger;
            this.wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }
        public IWebElement FindElement(By locator)
        {
            try
            {
                return _driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                _logger.LogError($"Element not found: {locator}");
                Console.WriteLine($"Element not found: {locator}");
                throw;
            }
        }
        public IList<IWebElement> FindElements(By locator)
        {
            try
            {
                return _driver.FindElements(locator);
            }
            catch (NoSuchElementException)
            {
                _logger.LogError($"Element not found: {locator}");
                Console.WriteLine($"Element not found: {locator}");
                throw;
            }
        }
        public void NavigateTo(string url)
        {
            try
            {
                _driver.Navigate().GoToUrl(url);
                _logger.LogInfo($"Navigated to: {url}");
                Console.WriteLine($"Navigated to: {url}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error navigating to {url}: {ex.Message}");
                Console.WriteLine($"Error navigating to {url}: {ex.Message}");
                throw; // Rethrow exception to propagate it
            }
        }
        public IWebElement WaitForElement(By locator)
        {
            try
            {
          
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                _logger.LogError($"Timeout waiting for element: {locator}. Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error finding element: {locator}. Error: {ex.Message}");
                throw;
            }
        }

        // Find an element and click it
        public void Click(By locator)
        {
            try
            {
                IWebElement element = WaitForElement(locator);
                element.Click();
                _logger.LogInfo($"Clicked on element: {locator}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error clicking on element: {locator}. Error: {ex.Message}");
                throw;
            }
        }
        // Send keys to an element
        public void TypeText(By locator, string text)
        {
            try
            {
                IWebElement element = WaitForElement(locator);
                element.Clear();
                element.SendKeys(text);
                _logger.LogInfo($"Typed '{text}' into element: {locator}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error typing into element: {locator}. Error: {ex.Message}");
                throw;
            }
        }

        // Get the text of an element
        public string GetText(By locator)
        {
            try
            {
                IWebElement element = WaitForElement(locator);
                string text = element.Text;
                _logger.LogInfo($"Text retrieved from element: {locator}: {text}");
                return text;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving text from element: {locator}. Error: {ex.Message}");
                throw;
            }
        }

        // Take a screenshot
        public void TakeScreenshot(string filePath)
        {
            try
            {   
                Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(filePath+"ScreenshotImageFormat.Png");
                _logger.LogInfo($"Screenshot saved to: {filePath}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error taking screenshot. Error: {ex.Message}");
                throw;
            }
        }

        // Method to select a dropdown option by visible text
        public void SelectDropdownByText(By by, string text)
        {
            try
            {
                SelectElement dropdown = new SelectElement(_driver.FindElement(by));
                dropdown.SelectByText(text);  // Select the option with the visible text
                Console.WriteLine($"Selected dropdown option: {text}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting dropdown option: {ex.Message}");
            }
        }
        // Method to select a dropdown option by value
        public void SelectDropdownByValue(By by, string value)
        {
            try
            {
                SelectElement dropdown = new SelectElement(_driver.FindElement(by));
                dropdown.SelectByValue(value);  // Select the option by its value
                Console.WriteLine($"Selected dropdown option by value: {value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting dropdown option: {ex.Message}");
            }
        }
        // Method to get all the options in a dropdown
        public List<string> GetDropdownOptions(By by)
        {
            List<string> optionsText = new List<string>();
            try
            {
                SelectElement dropdown = new SelectElement(_driver.FindElement(by));
                foreach (IWebElement option in dropdown.Options)
                {
                    optionsText.Add(option.Text);  // Add option text to the list
                }
                Console.WriteLine("Retrieved dropdown options.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving dropdown options: {ex.Message}");
            }
            return optionsText;
        }

        // Method to check or uncheck a checkbox based on a boolean value
        public void SetCheckbox(By by, bool check)
        {
            try
            {
                IWebElement checkbox = _driver.FindElement(by);
                if (checkbox.Selected != check)  // Only click if the checkbox needs to be changed
                {
                    checkbox.Click();  // Check or uncheck
                    Console.WriteLine($"Checkbox is now {(check ? "checked" : "unchecked")}");
                }
                else
                {
                    Console.WriteLine($"Checkbox is already {(check ? "checked" : "unchecked")}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error interacting with checkbox: {ex.Message}");
            }
        }

        // Scroll down to a particular element
        public void ScrollToElement(By by)
        {
            try
            {
                IWebElement element = _driver.FindElement(by);
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;

                // Scroll to the element
                jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                Console.WriteLine($"Scrolled to element: {by}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scrolling to element: {ex.Message}");
            }
        }

       

    }
}
