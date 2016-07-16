using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.Web.Security;
using RMS_WEB.Models;
using Utility;
using ENTITY;
using System.Configuration;
using System.Net;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.Configuration;
using System.ComponentModel;
using System.Web.Caching;



namespace RMS_WEB.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private static string email = "";
        private static string pass = "";
        private static string GT_NO = "";

        public ActionResult Index(EmployeeModel objModel)
        {
            try
            {
                var tmpData = (EmployeeModel)TempData["IEmployeeModel"];
                var tmpFailed = (EmployeeModel)TempData["IEmployeeFailure"];
                if (!object.ReferenceEquals(tmpData, null))
                {
                    objModel = tmpData;
                }
                else if (!object.ReferenceEquals(tmpFailed, null))
                {
                    objModel = tmpFailed;
                }
                return View(objModel);
            }
            catch (Exception ex)
            {
                CommonMethods.Log(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                CommonMethods.SendEmail("it.azhar@gmail.com", "exception:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "-Host Name:" + System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName, ex.Message);
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Access Denied";
                return View(objModel);
            }
        }

        public ActionResult EmployeeLogin()
        {
            var objModel = ModelFactory.EmployeeFactory();
            try
            {
                string EMP_LOGIN, EMP_PASS;
                EMP_LOGIN = Request.Form["EMP_LOGIN"];
                EMP_PASS = Request.Form["EMP_PASS"];
                
                if (!object.ReferenceEquals(EMP_LOGIN, null) && !object.ReferenceEquals(EMP_PASS, null))
                {
                    string sIPAddress = null;
                    sIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(sIPAddress))
                        sIPAddress = Request.ServerVariables["REMOTE_ADDR"];
                    LoginRequest objReq = new LoginRequest();
                    objReq.EMAIL = EMP_LOGIN;
                    objReq.PASS = EMP_PASS;
                    objReq.IP = sIPAddress;
                    objModel.LoginDetail = objModel.Login(objReq);
                    var modelResponse = objModel.LoginDetail[0];
                    
                    if (modelResponse.IS_SUCCESS)
                    {
                        CookieInfo objCookie = new CookieInfo();
                        objCookie.USERID = modelResponse.USERID;
                        objCookie.PASS = modelResponse.PASS;
                        objCookie.EMAIL = modelResponse.EMAIL;
                        objCookie.MOBILE = modelResponse.MOBILE;
                        objCookie.LAST_LOGON = modelResponse.LAST_LOGON.ToString();
                        objCookie.PREV_LOGON = modelResponse.PREV_LOGON.ToString();
                        objCookie.LANG = modelResponse.LANG;
                        objCookie.USR_TYPE = modelResponse.USR_TYPE;
                        objCookie.NAME = modelResponse.NAME;
                        objCookie.IMG_PATH = modelResponse.IMG_PATH;
                        objCookie.ADDR1 = modelResponse.ADDR1;
                        objCookie.ADDR2 = modelResponse.ADDR2;
                        objCookie.CITY = modelResponse.CITY;
                        objCookie.REGION = modelResponse.REGION;
                        objCookie.COUNTRY = modelResponse.COUNTRY;
                        objCookie.PINCODE = modelResponse.PINCODE;
                        objCookie.MAIL1 = modelResponse.MAIL1;
                        objCookie.MAIL2 = modelResponse.MAIL2;
                        objCookie.PHONE1 = modelResponse.PHONE1;
                        objCookie.PHONE2 = modelResponse.PHONE2;
                        objCookie.PANCARD = modelResponse.PANCARD;
                        objCookie.SRV_TAX = modelResponse.SRV_TAX;
                        objCookie.ECC_NO = modelResponse.ECC_NO;
                        objCookie.CST_NO = modelResponse.CST_NO;
                        objCookie.LST_NO = modelResponse.LST_NO;
                        objCookie.IP_ADDR_LAST = modelResponse.IP_ADDR_LAST;
                        objCookie.IP_ADDR_PREV = modelResponse.IP_ADDR_PREV;
                        Response.Cookies.Set(objCookie.CreateloginCredential(objCookie));
                        FormsAuthentication.SetAuthCookie(objCookie.USERID.ToString(), true);
                        return RedirectToAction("../Dashboard");
                    }
                    else
                    {
                        TempData["IEmployeeModel"] = objModel;
                        return RedirectToAction("../Login");
                    }
                }
                else
                {
                    return RedirectToAction("../Login");
                }
            }
            catch (Exception ex)
            {
                CommonMethods.Log(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                CommonMethods.SendEmail("mohamed.azhar@tecxeed.com", "exception:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "-Host Name:" + System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName, ex.Message);
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Access Denied";
                return View(objModel);
            }
        }

        public ActionResult SignOut()
        {
            try
            {
                var objModel = ModelFactory.EmployeeFactory();
                var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);
                FormsAuthentication.SignOut();
                var model = ModelFactory.CookieFactory();
                Response.Cookies.Add(model.RemoveUserCredential(System.Web.HttpContext.Current.Request));
            }
            catch (Exception EX)
            {
                Utility.CommonMethods.Log(System.Reflection.MethodBase.GetCurrentMethod().Name, EX.Message);
            }
            return RedirectToAction("../Login");
        }

        public ActionResult ForgetPassword()
        {
            var objModel = ModelFactory.EmployeeFactory();
            string EMP_LOGIN;
            EMP_LOGIN = Request.QueryString["USER"];
            if (object.ReferenceEquals(EMP_LOGIN, null))
            {
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Enter the Username and click forget password.";
                TempData["IEmployeeFailure"] = objModel;
            }
            else
            {                
                ForgetPwdRequest objReq = new ForgetPwdRequest();
                objReq.EMAIL = EMP_LOGIN;
                objModel.PwdDetail = objModel.ForgetPwd(objReq);
                var modelResponse = objModel.PwdDetail[0];

                if (modelResponse.IS_SUCCESS)
                {
                    CommonMethods.SendEmail(modelResponse.EMAIL, "Your vendor portal password", 
                        "Dear sir/Madam, <BR>"
                        + "Password successfully changed." + " <BR>"
                        + "Temporary password has been created for your vendor portal, login using " + modelResponse.PASS + " <BR>"
                        + "This is an automated email, please don’t reply. <BR> ");
                    objModel.IS_ERROR = true;
                    objModel.ERROR_MSG = "Password sent to your registered mail.";
                    TempData["IEmployeeFailure"] = objModel;
                }
                else 
                {
                    objModel.IS_ERROR = true;
                    objModel.ERROR_MSG = modelResponse.RESPONSE_MESSAGE;
                    TempData["IEmployeeFailure"] = objModel;
                }                
            }
            return RedirectToAction("../Login");

        }

        public ActionResult ResetPassword()
        {
            var objModel = ModelFactory.EmployeeFactory();
            HttpBrowserCapabilitiesBase objBrwInfo = Request.Browser;
            objModel.BROWSER = objBrwInfo.Browser.ToString();
            objModel.VERSION = Decimal.Parse(objBrwInfo.Version);
            var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);

            var tmpFailed = (EmployeeModel)TempData["IResetFailure"];
            if (!object.ReferenceEquals(tmpFailed, null))
            {
                objModel = tmpFailed;
            }
            return View(objModel);           
        }

        public ActionResult ResetPwd()
        {
            var objModel = ModelFactory.EmployeeFactory();
            var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);
            string EMAIL, OLD_PASS, NEW_PASS;
            EMAIL = cookie.USERID;
            OLD_PASS = Request.Form["OLD_PASS"];
            NEW_PASS = Request.Form["NEW_PASS"];
            if (!object.ReferenceEquals(EMAIL, null)
                && !object.ReferenceEquals(OLD_PASS, null)
                && !object.ReferenceEquals(NEW_PASS, null))
            {
                ResetPwdRequest objReq = new ResetPwdRequest();
                objReq.EMAIL = EMAIL;
                objReq.OLD_PASS = OLD_PASS;
                objReq.NEW_PASS = NEW_PASS;
                objModel.ResetPwdDetail = objModel.ResetPwd(objReq);
                var modelResponse = objModel.ResetPwdDetail[0];

                if (modelResponse.IS_SUCCESS)
                {
                    email = cookie.EMAIL;
                    var cookie1 = ModelFactory.CookieFactory().UpdatePassCredential(System.Web.HttpContext.Current.Request, NEW_PASS);
                    resetpwd_mail();   
                    return RedirectToAction("../Dashboard");
                }
                else
                {
                    TempData["IResetFailure"] = objModel;
                    return RedirectToAction("../Login/ResetPassword");
                }
            }
            else
            {
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Check your session and password.";
                TempData["IResetFailure"] = objModel;
                return RedirectToAction("../Login/ResetPassword");
            }
        }

        private void resetpwd_mail()
        {

            BackgroundWorker sendMail = new BackgroundWorker();
            sendMail.DoWork += new System.ComponentModel.DoWorkEventHandler(resetmail_DoWork);
            sendMail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(resetmail_WorkerCompleted);
            sendMail.RunWorkerAsync();
        }

        private static void resetmail_DoWork(object sender, DoWorkEventArgs e)
        {
            // Long running background operation
            CommonMethods.SendEmail(email, "Password changed.",
                        "Dear Sir/Madam, <BR>"
                        + "Your password for vendor portal has been reset successfully." + " <BR>"
                        + "This is an automated email, please don’t reply. <BR> ");
        }

        private static void resetmail_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // log when the worker is completed.
            //  Code that runs on application shutdown
            //If background worker process is running then clean up that object.
            //if (CacheManager.IsExists("BackgroundWorker"))
            //{
            //    BackgroundWorker worker = (BackgroundWorker)CacheManager.Get("BackgroundWorker");
            //    if (worker != null)
            //        worker.CancelAsync();
            //}
        }

        public ActionResult UnlockPassword()
        {
            var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);
            var objModel = ModelFactory.EmployeeFactory();
            string EMP_LOGIN;
            EMP_LOGIN = Request.QueryString["USER"];
            if (object.ReferenceEquals(EMP_LOGIN, null))
            {
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Enter the Username and click forget password.";
                TempData["IEmployeeFailure"] = objModel;
            }
            else
            {
                ForgetPwdRequest objReq = new ForgetPwdRequest();
                objReq.EMAIL = EMP_LOGIN;
                objModel.PwdDetail = objModel.UnlockPwd(objReq);
                var modelResponse = objModel.PwdDetail[0];

                if (modelResponse.IS_SUCCESS)
                {
                    email = modelResponse.EMAIL;
                    pass = modelResponse.PASS;
                    unlock_mail();
                    objModel.IS_ERROR = true;
                    objModel.ERROR_MSG = "Password sent to your registered mail.";
                    TempData["IEmployeeFailure"] = objModel;
                }
                else
                {
                    objModel.IS_ERROR = true;
                    objModel.ERROR_MSG = "Enter valid username.";
                    TempData["IEmployeeFailure"] = objModel;
                }
            }
            return RedirectToAction("../Login");

        }

        private void unlock_mail()
        {

            BackgroundWorker sendMail = new BackgroundWorker();
            sendMail.DoWork += new System.ComponentModel.DoWorkEventHandler(unlockmail_DoWork);
            sendMail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(unlockmail_WorkerCompleted);
            sendMail.RunWorkerAsync();
        }

        private static void unlockmail_DoWork(object sender, DoWorkEventArgs e)
        {
            // Long running background operation
            CommonMethods.SendEmail(email, "Temporary password.",
                        "Dear sir/Madam, <BR>"
                        + "Password successfully changed." + " <BR>"
                        + "Temporary password has been created for your vendor portal, login using " + pass + " <BR>"
                        + "This is an automated email, please don’t reply. <BR> ");
        }

        private static void unlockmail_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // log when the worker is completed.
            //  Code that runs on application shutdown
            //If background worker process is running then clean up that object.
            //if (CacheManager.IsExists("BackgroundWorker"))
            //{
            //    BackgroundWorker worker = (BackgroundWorker)CacheManager.Get("BackgroundWorker");
            //    if (worker != null)
            //        worker.CancelAsync();
            //}
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                //string src = System.IO.Path.GetFullPath(file.FileName);
                string pic = System.IO.Path.GetFileName(file.FileName);
                /*string path = System.IO.Path.Combine(
                                       Server.MapPath("~/assets/img/"), pic);*/
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/assets/img/"), "wits_logo.png");

                string path1 = System.IO.Path.Combine(
                                       Server.MapPath("~/assets/img/"), "wits_logo_300.png");
                
                // file is uploaded
                //file.SaveAs(path);
                GenerateThumbnails(0.7, file.InputStream, path);
                GenerateThumbnails1(0.7, file.InputStream, path1);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                SessionStateSection sessionStateSection =
                                (SessionStateSection)ConfigurationManager.GetSection("system.web/sessionState");

                string cookieName = sessionStateSection.CookieName;
                if (Request.Cookies[cookieName] != null)
                {
                    HttpCookie myCookie = new HttpCookie(cookieName);
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("../Dashboard");
        }

        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = Image.FromStream(sourcePath))
            {
                //var newWidth = (int)(image.Width * scaleFactor);
                //var newHeight = (int)(image.Height * scaleFactor);
                var newWidth = (int)(50);
                var newHeight = (int)(50);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        private void GenerateThumbnails1(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = Image.FromStream(sourcePath))
            {
                //var newWidth = (int)(image.Width * scaleFactor);
                //var newHeight = (int)(image.Height * scaleFactor);
                var newWidth = (int)(100);
                var newHeight = (int)(100);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        public ActionResult UserUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/assets/img/profileImages/"), cookie.USERID+".png");

                var objModel = ModelFactory.EmployeeFactory();
                UserThumbnails(0.7, file.InputStream, path);
                UserImgPathRequest objReq = new UserImgPathRequest();
                objReq.USERID = cookie.USERID;
                objReq.PATH = "/vendor/assets/img/profileImages/" + cookie.USERID + ".png";
                UserImgPathResponse resp = new UserImgPathResponse();
                resp = objModel.UserImgPath(objReq)[0];

                var cookie1 = ModelFactory.CookieFactory().UpdateUserCredential(System.Web.HttpContext.Current.Request, "/vendor/assets/img/profileImages/" + cookie.USERID + ".png");
                
            }
            // after successfully uploading redirect the user
            return RedirectToAction("../Dashboard");
        }

        private void UserThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = Image.FromStream(sourcePath))
            {
                //var newWidth = (int)(image.Width * scaleFactor);
                //var newHeight = (int)(image.Height * scaleFactor);
                var newWidth = (int)(180);
                var newHeight = (int)(180);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        [HttpPost]
        public JsonResult RemoveImage()
        {
            var objModel = ModelFactory.EmployeeFactory();
            try
            {
                var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);
                UserImgPathRequest objReq = new UserImgPathRequest();
                objReq.USERID = cookie.USERID;
                objReq.PATH = " ";
                UserImgPathResponse resp = new UserImgPathResponse();
                resp = objModel.UserImgPath(objReq)[0];
                if (resp.IS_SUCCESS)
                {
                    ModelFactory.CookieFactory().UpdateUserCredential(System.Web.HttpContext.Current.Request, "");
                }
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CommonMethods.Log(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                CommonMethods.SendEmail("mohamed.azhar@tecxeed.com", "exception:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "-Host Name:" + System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName, ex.Message);
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Access Denied";
                return Json(objModel);
            }
        }

        [HttpPost]
        public JsonResult GetPwdPolicy(PasswordPolicyRequest objReq)
        {
            var objModel = ModelFactory.EmployeeFactory();
            try
            {
                var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);
                objModel.pwdpolicy = objModel.PasswordPolicy(objReq);
                return Json(objModel.pwdpolicy, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CommonMethods.Log(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                CommonMethods.SendEmail("mohamed.azhar@tecxeed.com", "exception:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "-Host Name:" + System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName, ex.Message);
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Access Denied";
                return Json(objModel);
            }
        }

        [HttpPost]
        public JsonResult UpdatePwdPolicy(UpdatePasswordPolicyRequest objReq)
        {
            var objModel = ModelFactory.EmployeeFactory();
            try
            {
                var cookie = ModelFactory.CookieFactory().GetUserDetails(System.Web.HttpContext.Current.Request);
                objModel.updatepwdpolicy = objModel.UpdatePasswordPolicy(objReq);
                return Json(objModel.updatepwdpolicy, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CommonMethods.Log(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                CommonMethods.SendEmail("mohamed.azhar@tecxeed.com", "exception:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "-Host Name:" + System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName, ex.Message);
                objModel.IS_ERROR = true;
                objModel.ERROR_MSG = "Access Denied";
                return Json(objModel);
            }
        }
    }
}
