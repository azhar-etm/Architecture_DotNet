using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace RMS_WEB.Models
{
    public class CookieInfo:ICookieInfo
    {
        public string USERID { get; set; }
        public string PASS { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public string LAST_LOGON { get; set; }
        public string PREV_LOGON { get; set; }
        public string LANG { get; set; }
        public string USR_TYPE { get; set; }
        public string NAME { get; set; }
        public string IMG_PATH { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public string CITY { get; set; }
        public string REGION { get; set; }
        public string COUNTRY { get; set; }
        public string PINCODE { get; set; }
        public string MAIL1 { get; set; }
        public string MAIL2 { get; set; }
        public string PHONE1 { get; set; }
        public string PHONE2 { get; set; }
        public string PANCARD { get; set; }
        public string SRV_TAX { get; set; }
        public string ECC_NO { get; set; }
        public string CST_NO { get; set; }
        public string LST_NO { get; set; }
        public string IP_ADDR_LAST { get; set; }
        public string IP_ADDR_PREV { get; set; }
        public bool ASN { get; set; }
        public bool ASN_REPORT { get; set; }
        public bool DASHBOARD { get; set; }
        public bool FMS_BILL_BOOKING { get; set; }
        public bool FMS_PYMT_REPORT { get; set; }
        public bool GATE { get; set; }
        public bool GATE_ADMIN { get; set; }
        public bool GATE_REPORTS { get; set; }
        public bool GRP_VENDOR { get; set; }
        public bool MAT_TRANSISTS { get; set; }
        public bool MSG_BOARD { get; set; }
        public bool MSG_BRD_AUTHOR { get; set; }
        public bool ORD_ACK { get; set; }
        public bool PO_LOOKUP { get; set; }
        public bool PYMT_DETAILS { get; set; }
        public bool PAYMENT_REPORT { get; set; }
        public bool QUERY_RES_ADMIN { get; set; }
        public bool QUERY_RES_USER { get; set; }
        public bool QUERY_RESOLUTION { get; set; }
        public bool SOCK_VENDOR { get; set; }
        public bool UME { get; set; }
        public bool ALERT_MAILS { get; set; }
        public HttpCookie CreateloginCredential(CookieInfo objCookieInfo)
        {
            HttpCookie userInfo = new HttpCookie("UserInfo");
            userInfo["USERID"] = USERID.ToString();
            userInfo["PASS"] = PASS.ToString();
            userInfo["EMAIL"] = EMAIL.ToString();
            userInfo["MOBILE"] = MOBILE.ToString();
            userInfo["LAST_LOGON"] = LAST_LOGON.ToString();
            userInfo["PREV_LOGON"] = PREV_LOGON.ToString();
            userInfo["LANG"] = LANG.ToString();
            userInfo["USR_TYPE"] = USR_TYPE.ToString();
            userInfo["NAME"] = NAME.ToString();
            userInfo["IMG_PATH"] = IMG_PATH.ToString();
            userInfo["ADDR1"] = ADDR1.ToString();
            userInfo["ADDR2"] = ADDR2.ToString();
            userInfo["CITY"] = CITY.ToString();
            userInfo["REGION"] = REGION.ToString();
            userInfo["COUNTRY"] = COUNTRY.ToString();
            userInfo["PINCODE"] = PINCODE.ToString();
            userInfo["MAIL1"] = MAIL1.ToString();
            userInfo["MAIL2"] = MAIL2.ToString();
            userInfo["PHONE1"] = PHONE1.ToString();
            userInfo["PHONE2"] = PHONE2.ToString();
            userInfo["PANCARD"] = PANCARD.ToString();
            userInfo["SRV_TAX"] = SRV_TAX.ToString();
            userInfo["ECC_NO"] = ECC_NO.ToString();
            userInfo["CST_NO"] = CST_NO.ToString();
            userInfo["LST_NO"] = LST_NO.ToString();
            userInfo["IP_ADDR_LAST"] = IP_ADDR_LAST.ToString();
            userInfo["IP_ADDR_PREV"] = IP_ADDR_PREV.ToString();
            userInfo.Expires = DateTime.Now.AddMinutes(600);
            return userInfo;
        }
        public bool IsCookieExist(HttpRequest objRequest)
        {
            if (objRequest.Cookies["UserInfo"] != null)
            {
                return true;
            }
            else
            {

                FormsAuthentication.SignOut();                
                return false;
            }
        }
        public CookieInfo GetUserDetails(HttpRequest objReq)
        {
            
            if(IsCookieExist(objReq))
            {
                var UserInfo= objReq.Cookies["UserInfo"];
                USERID = UserInfo["USERID"];
                PASS = UserInfo["PASS"];
                EMAIL =UserInfo["EMAIL"];
                MOBILE = UserInfo["MOBILE"];
                LAST_LOGON = UserInfo["LAST_LOGON"];
                PREV_LOGON = UserInfo["PREV_LOGON"];
                LANG = UserInfo["LANG"];
                USR_TYPE = UserInfo["USR_TYPE"];
                NAME = UserInfo["NAME"];
                IMG_PATH = UserInfo["IMG_PATH"];
                ADDR1 = UserInfo["ADDR1"];
                ADDR2 = UserInfo["ADDR2"];
                CITY = UserInfo["CITY"];
                REGION = UserInfo["REGION"];
                COUNTRY = UserInfo["COUNTRY"];
                PINCODE = UserInfo["PINCODE"];
                MAIL1 = UserInfo["MAIL1"];
                MAIL2 = UserInfo["MAIL2"];
                PHONE1 = UserInfo["PHONE1"];
                PHONE2 = UserInfo["PHONE2"];
                PANCARD = UserInfo["PANCARD"];
                SRV_TAX = UserInfo["SRV_TAX"];
                ECC_NO = UserInfo["ECC_NO"];
                CST_NO = UserInfo["CST_NO"];
                LST_NO = UserInfo["LST_NO"];
                IP_ADDR_LAST = UserInfo["IP_ADDR_LAST"];
                IP_ADDR_PREV = UserInfo["IP_ADDR_PREV"];
                return this;
            }
            else
            {
                return this;
            }
        }
        public HttpCookie RemoveUserCredential(HttpRequest objReq)
        {
            var cookie = objReq.Cookies["UserInfo"];
            cookie.Expires = DateTime.Now.AddMinutes(-600);
            return cookie;
        }
        public HttpCookie UpdateUserCredential(HttpRequest objReq, String path)
        {
            HttpCookie tmp = objReq.Cookies["UserInfo"];
            CookieInfo objCookie = new CookieInfo();
            var old_cookie = objReq.Cookies["UserInfo"];
            old_cookie.Expires = DateTime.Now.AddMinutes(-600);
            HttpCookie userInfo = new HttpCookie("UserInfo");
            userInfo["USERID"] = tmp["USERID"];
            userInfo["PASS"] = tmp["PASS"];
            userInfo["EMAIL"] = tmp["EMAIL"];
            userInfo["MOBILE"] = tmp["MOBILE"];
            userInfo["LAST_LOGON"] = tmp["LAST_LOGON"];
            userInfo["PREV_LOGON"] = tmp["PREV_LOGON"];
            userInfo["LANG"] = tmp["LANG"];
            userInfo["USR_TYPE"] = tmp["USR_TYPE"];
            userInfo["NAME"] = tmp["NAME"];
            userInfo["IMG_PATH"] = path;
            userInfo["ADDR1"] = tmp["ADDR1"];
            userInfo["ADDR2"] = tmp["ADDR2"];
            userInfo["CITY"] = tmp["CITY"];
            userInfo["REGION"] = tmp["REGION"];
            userInfo["COUNTRY"] = tmp["COUNTRY"];
            userInfo["PINCODE"] = tmp["PINCODE"];
            userInfo["MAIL1"] = tmp["MAIL1"];
            userInfo["MAIL2"] = tmp["MAIL2"];
            userInfo["PHONE1"] = tmp["PHONE1"];
            userInfo["PHONE2"] = tmp["PHONE2"];
            userInfo["PANCARD"] = tmp["PANCARD"];
            userInfo["SRV_TAX"] = tmp["SRV_TAX"];
            userInfo["ECC_NO"] = tmp["ECC_NO"];
            userInfo["CST_NO"] = tmp["CST_NO"];
            userInfo["LST_NO"] = tmp["LST_NO"];
            userInfo["IP_ADDR_LAST"] = tmp["IP_ADDR_LAST"];
            userInfo["IP_ADDR_PREV"] = tmp["IP_ADDR_PREV"];
            userInfo.Expires = DateTime.Now.AddMinutes(30);
            HttpContext.Current.Response.Cookies.Set(userInfo);
            FormsAuthentication.SetAuthCookie(userInfo["USERID"], true);
            return userInfo;
        }
        public HttpCookie UpdatePassCredential(HttpRequest objReq, String pass)
        {
            HttpCookie tmp = objReq.Cookies["UserInfo"];
            CookieInfo objCookie = new CookieInfo();
            var old_cookie = objReq.Cookies["UserInfo"];
            old_cookie.Expires = DateTime.Now.AddMinutes(-300);
            HttpCookie userInfo = new HttpCookie("UserInfo");
            userInfo["USERID"] = tmp["USERID"];
            userInfo["PASS"] = pass;
            userInfo["EMAIL"] = tmp["EMAIL"];
            userInfo["MOBILE"] = tmp["MOBILE"];
            userInfo["LAST_LOGON"] = tmp["LAST_LOGON"];
            userInfo["PREV_LOGON"] = tmp["PREV_LOGON"];
            userInfo["LANG"] = tmp["LANG"];
            userInfo["USR_TYPE"] = tmp["USR_TYPE"];
            userInfo["NAME"] = tmp["NAME"];
            userInfo["IMG_PATH"] = tmp["IMG_PATH"];
            userInfo["ADDR1"] = tmp["ADDR1"];
            userInfo["ADDR2"] = tmp["ADDR2"];
            userInfo["CITY"] = tmp["CITY"];
            userInfo["REGION"] = tmp["REGION"];
            userInfo["COUNTRY"] = tmp["COUNTRY"];
            userInfo["PINCODE"] = tmp["PINCODE"];
            userInfo["MAIL1"] = tmp["MAIL1"];
            userInfo["MAIL2"] = tmp["MAIL2"];
            userInfo["PHONE1"] = tmp["PHONE1"];
            userInfo["PHONE2"] = tmp["PHONE2"];
            userInfo["PANCARD"] = tmp["PANCARD"];
            userInfo["SRV_TAX"] = tmp["SRV_TAX"];
            userInfo["ECC_NO"] = tmp["ECC_NO"];
            userInfo["CST_NO"] = tmp["CST_NO"];
            userInfo["LST_NO"] = tmp["LST_NO"];
            userInfo["IP_ADDR_LAST"] = tmp["IP_ADDR_LAST"];
            userInfo["IP_ADDR_PREV"] = tmp["IP_ADDR_PREV"];
            userInfo.Expires = DateTime.Now.AddMinutes(30);
            HttpContext.Current.Response.Cookies.Set(userInfo);
            FormsAuthentication.SetAuthCookie(userInfo["USERID"], true);
            return userInfo;
        }
        public HttpCookie CreateUserScreens(CookieInfo objCookieInfo)
        {
            HttpCookie userScreens = new HttpCookie("UserScreens");
            userScreens["DASHBOARD"] = objCookieInfo.DASHBOARD.ToString();
            userScreens["FMS_BILL_BOOKING"] = objCookieInfo.FMS_BILL_BOOKING.ToString();
            userScreens["ASN"] = objCookieInfo.ASN.ToString();
            userScreens["ASN_REPORT"] = objCookieInfo.ASN_REPORT.ToString();
            userScreens["FMS_PYMT_REPORT"] = objCookieInfo.FMS_PYMT_REPORT.ToString();
            userScreens["GATE"] = objCookieInfo.GATE.ToString();
            userScreens["GATE_ADMIN"] = objCookieInfo.GATE_ADMIN.ToString();
            userScreens["GATE_REPORTS"] = objCookieInfo.GATE_REPORTS.ToString();
            userScreens["GRP_VENDOR"] = objCookieInfo.GRP_VENDOR.ToString();
            userScreens["MAT_TRANSISTS"] = objCookieInfo.MAT_TRANSISTS.ToString();
            userScreens["MSG_BOARD"] = objCookieInfo.MSG_BOARD.ToString();
            userScreens["MSG_BRD_AUTHOR"] = objCookieInfo.MSG_BRD_AUTHOR.ToString();
            userScreens["ORD_ACK"] = objCookieInfo.ORD_ACK.ToString();
            userScreens["PO_LOOKUP"] = objCookieInfo.PO_LOOKUP.ToString();
            userScreens["PYMT_DETAILS"] = objCookieInfo.PYMT_DETAILS.ToString();
            userScreens["PAYMENT_REPORT"] = objCookieInfo.PAYMENT_REPORT.ToString();
            userScreens["QUERY_RES_ADMIN"] = objCookieInfo.QUERY_RES_ADMIN.ToString();
            userScreens["QUERY_RES_USER"] = objCookieInfo.QUERY_RES_USER.ToString();
            userScreens["QUERY_RESOLUTION"] = objCookieInfo.QUERY_RESOLUTION.ToString();
            userScreens["SOCK_VENDOR"] = objCookieInfo.SOCK_VENDOR.ToString();
            userScreens["UME"] = objCookieInfo.UME.ToString();
            userScreens["ALERT_MAILS"] = objCookieInfo.ALERT_MAILS.ToString();
            userScreens.Expires = DateTime.Now.AddMinutes(600);
            return userScreens;
        }
        public bool IsCookieScreensExist(HttpRequest objRequest)
        {
            if (objRequest.Cookies["UserScreens"] != null)
            {
                return true;
            }
            else
            {
                FormsAuthentication.SignOut();
                return false;
            }
        }
        public CookieInfo GetUserScreens(HttpRequest objReq)
        {
            if (IsCookieScreensExist(objReq))
            {
                var UserScreens = objReq.Cookies["UserScreens"];
                ASN = bool.Parse(UserScreens["ASN"]);
                ASN_REPORT = bool.Parse(UserScreens["ASN_REPORT"]);
                DASHBOARD = bool.Parse(UserScreens["DASHBOARD"]);
                FMS_BILL_BOOKING = bool.Parse(UserScreens["FMS_BILL_BOOKING"]);
                FMS_PYMT_REPORT = bool.Parse(UserScreens["FMS_PYMT_REPORT"]);
                GATE = bool.Parse(UserScreens["GATE"]);
                GATE_ADMIN = bool.Parse(UserScreens["GATE_ADMIN"]);
                GATE_REPORTS = bool.Parse(UserScreens["GATE_REPORTS"]);
                GRP_VENDOR = bool.Parse(UserScreens["GRP_VENDOR"]);
                MAT_TRANSISTS = bool.Parse(UserScreens["MAT_TRANSISTS"]);
                MSG_BOARD = bool.Parse(UserScreens["MSG_BOARD"]);
                MSG_BRD_AUTHOR = bool.Parse(UserScreens["MSG_BRD_AUTHOR"]);
                ORD_ACK = bool.Parse(UserScreens["ORD_ACK"]);
                PO_LOOKUP = bool.Parse(UserScreens["PO_LOOKUP"]);
                PYMT_DETAILS = bool.Parse(UserScreens["PYMT_DETAILS"]);
                PAYMENT_REPORT = bool.Parse(UserScreens["PAYMENT_REPORT"]);
                QUERY_RES_ADMIN = bool.Parse(UserScreens["QUERY_RES_ADMIN"]);
                QUERY_RES_USER = bool.Parse(UserScreens["QUERY_RES_USER"]);
                QUERY_RESOLUTION = bool.Parse(UserScreens["QUERY_RESOLUTION"]);
                SOCK_VENDOR = bool.Parse(UserScreens["SOCK_VENDOR"]);
                UME = bool.Parse(UserScreens["UME"]);
                ALERT_MAILS = bool.Parse(UserScreens["ALERT_MAILS"]);
                return this;
            }
            else
            {
                return this;
            }
        }
        public HttpCookie RemoveUserScreens(HttpRequest objReq)
        {
            var cookie = objReq.Cookies["UserScreens"];
            cookie.Expires = DateTime.Now.AddMinutes(-600);
            return cookie;
        }
    }

    public interface ICookieInfo
    {
        string USERID { get; set; }
        string PASS { get; set; }
        string EMAIL { get; set; }
        string MOBILE { get; set; }
        string LAST_LOGON { get; set; }
        string PREV_LOGON { get; set; }
        string LANG { get; set; }
        string USR_TYPE { get; set; }
        string NAME { get; set; }
        string IMG_PATH { get; set; }
        string ADDR1 { get; set; }
        string ADDR2 { get; set; }
        string CITY { get; set; }
        string REGION { get; set; }
        string COUNTRY { get; set; }
        string PINCODE { get; set; }
        string MAIL1 { get; set; }
        string MAIL2 { get; set; }
        string PHONE1 { get; set; }
        string PHONE2 { get; set; }
        string PANCARD { get; set; }
        string SRV_TAX { get; set; }
        string ECC_NO { get; set; }
        string CST_NO { get; set; }
        string LST_NO { get; set; }
        string IP_ADDR_LAST { get; set; }
        string IP_ADDR_PREV { get; set; }
        bool ASN { get; set; }
        bool ASN_REPORT { get; set; }
        bool DASHBOARD { get; set; }
        bool FMS_BILL_BOOKING { get; set; }
        bool FMS_PYMT_REPORT { get; set; }
        bool GATE { get; set; }
        bool GATE_ADMIN { get; set; }
        bool GATE_REPORTS { get; set; }
        bool GRP_VENDOR { get; set; }
        bool MAT_TRANSISTS { get; set; }
        bool MSG_BOARD { get; set; }
        bool MSG_BRD_AUTHOR { get; set; }
        bool ORD_ACK { get; set; }
        bool PO_LOOKUP { get; set; }
        bool PYMT_DETAILS { get; set; }
        bool PAYMENT_REPORT { get; set; }
        bool QUERY_RES_ADMIN { get; set; }
        bool QUERY_RES_USER { get; set; }
        bool QUERY_RESOLUTION { get; set; }
        bool SOCK_VENDOR { get; set; }
        bool UME { get; set; }
        bool ALERT_MAILS { get; set; }
        HttpCookie CreateloginCredential(CookieInfo objCookieInfo);
        bool IsCookieExist(HttpRequest objRequest);
        CookieInfo GetUserDetails(HttpRequest objReq);
        HttpCookie RemoveUserCredential(HttpRequest objReq);
        HttpCookie UpdateUserCredential(HttpRequest objReq, String path);
        HttpCookie UpdatePassCredential(HttpRequest objReq, String path);
        HttpCookie CreateUserScreens(CookieInfo objCookieInfo);
        CookieInfo GetUserScreens(HttpRequest objReq);
        HttpCookie RemoveUserScreens(HttpRequest objReq);
    }
}