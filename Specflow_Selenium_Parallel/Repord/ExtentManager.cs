using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySel.Repord
{public interface IExtentManager 
    {
       
        void CreateTest(string testName);
        void LogTestResult(string status, string message);
        void Flush();
        void Attachscreenshot(string filepath, string description);



    }

    public class ExtentManager : IExtentManager
    {


        private static ThreadLocal<ExtentTest> _extentTests = new ThreadLocal<ExtentTest>();

        private static ThreadLocal<ExtentReports> _extentReports = new ThreadLocal<ExtentReports>(() =>
   {
       var reportPath = Path.Combine(Directory.GetCurrentDirectory().Replace("bin\\Debug\\net6.0", "Extent_Reports"),
                                    $"TestReport_{Guid.NewGuid()}.html");

       Console.Write(reportPath);
            var extentReports = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(reportPath);
            extentReports.AttachReporter(sparkReporter);

            return extentReports;
        });

        public void CreateTest(string testName)
        {
            
            _extentTests.Value = _extentReports.Value.CreateTest(testName);
        }
        public void LogTestResult(string status, string message)
        {
            if (_extentTests.Value == null) throw new InvalidOperationException("Test is not initialized.");
            _extentTests.Value.Log((Status)Enum.Parse(typeof(Status), status), message);
        }
        public void Attachscreenshot(string filepath,string description)
        {
            _extentTests.Value.AddScreenCaptureFromPath(filepath, description);
        }
        
        public void Flush()
        {
            _extentReports.Value.Flush();
        }
      
    }
}
