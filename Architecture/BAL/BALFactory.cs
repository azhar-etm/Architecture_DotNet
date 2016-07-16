using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class BALFactory
    {
        public static IEmployeeBAL EmployeeFactory()
        {
            return new EmployeeBAL();
        }
    }

}
