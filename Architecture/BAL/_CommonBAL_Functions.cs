using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BAL
{


    public abstract class CommonBALFunctions
    {
        internal delegate void SendEmailDelegate(string EmailId, string Subject, string Message);
        internal delegate void LogDelegate(string MethodName, string LogMessage);
        internal LogDelegate ServerLog = new LogDelegate(Log);
        internal SendEmailDelegate SendEmail = new SendEmailDelegate(SendMail);

        static void SendMail(string EmailId, string Subject, string Message)
        {
            CommonMethods.SendEmail(EmailId, Subject, Message);
        }
        static void Log(string MethodName, string LogMessage)
        {
            SendMail("mohamed.azhar@tecxeed.com", "Exception:" + MethodName, LogMessage);
            CommonMethods.Log(MethodName, LogMessage);
        }

    }

}
