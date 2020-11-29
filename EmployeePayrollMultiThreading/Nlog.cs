using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace EmployeePayrollMultiThreading
{
    public class Nlog
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Method to log for the debug operation
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        /// <summary>
        /// Method to log for the message at error level
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            logger.Error(message);
        }
        /// <summary>
        /// Method to log for the message at information level
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        /// <summary>
        /// Method to log for the message at warning level
        /// </summary>
        /// <param name="message"></param>
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
