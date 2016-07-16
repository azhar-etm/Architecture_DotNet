using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Management;
using System.Drawing.Printing;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.ComponentModel;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Web;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;



namespace Utility
{

    public class CommonMethods
    {
        //To send Email
        public static bool SendEmail(string EmailId, string Subject, string Message)
        {
            try
            {
                string Email = ConfigurationManager.AppSettings["EmailAddress"].ToString();
                string pwd = ConfigurationManager.AppSettings["Password"].ToString();
                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                string port = ConfigurationManager.AppSettings["port"].ToString();

                NetworkCredential aut = new NetworkCredential(Email, pwd);
                MailMessage message = new MailMessage();
                MailAddress frm = new MailAddress(Email, "VENDOR PORTAL");
                message.From = frm;
                message.To.Add(new MailAddress(string.Format(EmailId)));
                message.Bcc.Add(new MailAddress(string.Format("mohamed.azhar@tecxeed.com")));
                message.Subject = Subject;
                message.IsBodyHtml = true;
                message.Body = Message;
                SmtpClient smtpClient = new SmtpClient(smtp);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.Credentials = aut;
                smtpClient.Send(message);
                return true;

            }
            catch (Exception ex)
            {
                NetworkCredential aut = new NetworkCredential("mohamed.azhar@tecxeed.com", "azharudeen4");
                MailMessage message = new MailMessage();
                MailAddress frm = new MailAddress("mohamed.azhar@tecxeed.com");
                message.From = frm;
                message.To.Add(new MailAddress(string.Format("mohamed.azhar@tecxeed.com")));
                message.Subject = "Error in Email id";
                message.IsBodyHtml = true;
                message.Body = ex.Message;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.Credentials = aut;
                smtpClient.Send(message);
                throw new Exception(ex.Message);

            }

        }
        public static void Log(string MethodName, string LogMessage)
        {
            HttpRuntime.UnloadAppDomain();
            string content = Environment.NewLine + "<br/>------------------------------------------------------------------------";
            content += Environment.NewLine + "<br/>Time: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");
            content += Environment.NewLine + "<br/>Method Name: " + MethodName;
            content += Environment.NewLine + "<br/>Log Message: " + LogMessage;
            content += Environment.NewLine + "<br/>-------------------------------------------------------------------------------";

            try
            {
                string existingContent = "";
                string fileDir = AppDomain.CurrentDomain.BaseDirectory + "ErrorLog\\";
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                string filepath = fileDir + "Log.txt";
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Close();
                }
                else
                {
                    existingContent = File.ReadAllText(filepath);
                }

                File.WriteAllText(filepath, content + existingContent);

                //  SendEmail("suresh@way2smile.com", "RMS-Error Report", content);
            }
            catch (Exception ex)
            {

            }
        }
        
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle()
                : base(true)
            {
            }

            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);

            protected override bool ReleaseHandle()
            {
                return CloseHandle(handle);
            }
        }

    }
}







 
