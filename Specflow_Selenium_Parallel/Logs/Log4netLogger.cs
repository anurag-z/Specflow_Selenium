using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySel.Logs
{
    public interface IAppLogger
    {
        void LogInfo(string message);
        void LogError(string message);
    }
    public class Log4netLogger:IAppLogger
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Log4netLogger));
        static Log4netLogger()
        {
            // Set dynamic log path
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory); // Ensure directory exists
            }

            string logFilePath = Path.Combine(logDirectory, $"test_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            // Initialize Log4Net with the custom log file path
            var fileAppender = new log4net.Appender.FileAppender
            {
                File = logFilePath,
                AppendToFile = true,
                Layout = new log4net.Layout.PatternLayout("%date{yyyy-MM-dd HH:mm:ss} [%thread] %-5level %logger - %message%newline")
            };

            BasicConfigurator.Configure(fileAppender); // Apply the configuration
        }

       

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

    }
}
