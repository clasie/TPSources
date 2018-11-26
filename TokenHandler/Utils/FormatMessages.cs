using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Utils
{
    public static class FormatMessages
    {
        /// <summary>
        /// Helper to format logs
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="methodParams"></param>
        /// <param name="exceptionMessage"></param>
        /// <returns></returns>
        public static string getLogMessage(string className, string methodName, string methodParams, string exceptionMessage ) {
            //return "FROM getLogMessage";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine().Append(" . Class name: ").Append(className);
            sb.AppendLine().Append(" . MetodName name: ").Append(methodName);
            sb.AppendLine().Append(" . Metod params: ").Append(methodParams);
            sb.AppendLine().Append(" . Exception: ").Append(exceptionMessage);
            return sb.ToString();
        }
    }
}
