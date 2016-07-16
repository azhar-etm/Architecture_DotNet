using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS_WEB.Models
{
    public static class ModelFactory
    {
        public static ICookieInfo CookieFactory()
        {
            return new CookieInfo();
        }
        public static IEmployeeModel EmployeeFactory()
        {
            return new EmployeeModel();
        }
    }
}