using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public static class DALFactory
    {
       public static IEmployeeDAL EmployeeFactory()
       {
           return new EmployeeDAL();
       }
    }
}
 