using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS_WEB.Models;

namespace RMS_WEB.Controllers
{
    public static class cookieInfo
    {
        public static CookieInfo GetUserInfo(HttpRequest objReq)
        {
            try
            {
                var obj = ModelFactory.CookieFactory();
                var response = obj.GetUserDetails(objReq);
                return response;
            }
            catch (Exception ex)
            {
               
                throw;
            }

        }
    }
}