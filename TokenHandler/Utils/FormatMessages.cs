using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Utils
{
    public static class FormatMessages
    {
        public static string getLogMessage(string className, string metodName, string exceptionMessage ) {
            return string.Format("Class: {0} , Method: {1}, Exception: {2}",
                className, metodName, exceptionMessage);
        }
        //class: MethodBase.GetCurrentMethod().DeclaringType
        //method: System.Reflection.MethodBase.GetCurrentMethod()
    }
}
