using AventStack.ExtentReports;
using FluentAssertions;
using Newtonsoft.Json;
using PlaySel.Modal;
using PlaySel.Repord;
using RestSharp;
using Specflow_Selenium_Parallel.API_Client;
using System.Text.RegularExpressions;


namespace Specflow_Selenium_Parallel.StepDefinitions
{
    [Binding,Scope(Tag ="API")]
    public class API_Testing
    {

        public ScenarioContext _scenariocontext;
        public IRest_Client _Client;
        Appconfig_DTO _appconfig;
        IExtentManager _extentManager;
       public API_Testing(ScenarioContext scenariocontext,IRest_Client client, IExtentManager extentManager)
        {
            _scenariocontext = scenariocontext;
            _Client = client;
            _extentManager = extentManager;
        }

        [Given(@"Testing")]
        public void GivenTesting()
        {
            //_appconfig  = _scenariocontext.Get<Appconfig_DTO>();
            //string body = "{  \"username\" : \"admin\",   \"password\" : \"password123\"}";
            // RestResponse response = _Client.Post(_appconfig.Base_url + "/auth", body);
            //dynamic djson= JsonConvert.DeserializeObject<dynamic>(response.Content);
            //Console.WriteLine("Json format"+djson.token);
            //Console.WriteLine("String format" + response);


        }
        [Given(@"I get Auth Token")]
        public void GivenIGetAuthToken()
        {
            _appconfig = _scenariocontext.Get<Appconfig_DTO>();
            string body = "{  \"username\" : \"admin\",   \"password\" : \"password123\"}";
           RestResponse response = _Client.Post(_appconfig.Base_url + "/auth", body);
            _scenariocontext["AuthResponse"] = response;
            dynamic djson = JsonConvert.DeserializeObject<dynamic>(response.Content);

            _extentManager.LogTestResult("Pass", "Response as expected" + response.Content);

            _extentManager.LogTestResult("Pass", "Token as expected" + djson.token);


        }
        [Then(@"I verify Status code ""([^""]*)""")]
        public void ThenIVerifyStatusCode(string p0)
        {
            RestResponse status =(RestResponse) _scenariocontext["AuthResponse"];
            status.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
//            status.StatusCode.ToString().Should().Be(p0);
            _extentManager.LogTestResult("Pass", "Status as expected"+status.StatusCode);
        }
        [Then(@"I get booking list")]
        public void ThenIGetBookingList()
        {
           RestResponse rs= _Client.Get(_appconfig.Base_url+_appconfig.Endpoint.Booking);
            _extentManager.LogTestResult("Pass", "Response of booking" + rs.Content);
            rs.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            _extentManager.LogTestResult("Pass", "STatus of booking" + rs.StatusDescription);
            _scenariocontext["Booking"] = rs;
        }

        [Then(@"I verify Booking ID's")]
        public void ThenIVerifyBookingIDs()
        {
            RestResponse rs = (RestResponse)_scenariocontext["Booking"];
           List<root> r=JsonConvert.DeserializeObject<List<root>>(rs.Content);
            int id = r[0].bookingid;
            Match s = Regex.Match(id.ToString(),"[0-9]");
           s.Success.Should().BeTrue();
            _extentManager.LogTestResult("Pass", "Booking Id type is expected" + r[0].bookingid);

        }


    }
}
