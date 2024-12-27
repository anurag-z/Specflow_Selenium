
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using PlaySel.Drivers;
using PlaySel.Helpers;



namespace PlaySel.Pages
{

    //public interface ILoginPage
    //{
    //    public void navigate(string url);
    //    public void Login_details(string username,string password);

    //    public string login_success();
    //    public void testing();
    //}


    public class LoginPage
    {
        private readonly IWebDriver? _driver;
        private readonly WebDriverWait _wait;
        private readonly IActionWarpper _actionWarpper;
        public LoginPage(IWebDriver driver,IActionWarpper actionWarpper)
        {
            _driver = driver;
            _actionWarpper = actionWarpper;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void navigate(string url)
        {
            
            _actionWarpper.NavigateTo(url);
            _driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            for (int i = 0; i <= 10; i++)
            {

                bool flag = js.ExecuteScript("return document.readyState").ToString().Equals("complete");
                if (flag)
                {
                    break;
                }

            }

           
        }
        public void Login_details(string username, string password)
        {
            _actionWarpper.TypeText(_driver.ByXPath(Usernames),username);
            _actionWarpper.TypeText(_driver.ByXPath(Password), password);

            _actionWarpper.Click(_driver.ByXPath(loginbutton));


        }

        public string login_success()
        {
            return _actionWarpper.GetText(_driver.ByXPath(success_login));
        }
        private string Usernames => "//input[@id=\"user-name\"]";


     
        private string Password => "//input[@id=\"password\"]";

        private string loginbutton => "//input[@id=\"login-button\"]";
        private string success_login => "//span[@data-test=\"title\"]";
        public void testing()
        { }
    }

  
}
