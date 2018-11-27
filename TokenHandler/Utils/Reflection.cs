using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Utils
{
    /// <summary>
    /// To help tracing In/Out movements trough the Web service we need to analyse
    /// and store this trafic, made of list of business objects. Here we will detect
    /// which instance is going in/out in a dynamic way without knowing  the type 
    /// by advance.
    /// </summary>
    public class Reflection
    {
        public static Reflection GetReflection() {
            return new Reflection();
        }
        public string GetValues<T>(List<T> objectPut)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elementSup in objectPut)
            {
                Type type = elementSup.GetType();
                List<string> listPropNameValues = new List<string>();
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    if (propertyInfo.CanRead)
                    {
                        try
                        {
                            var propName = propertyInfo.Name;
                            var propValue = propertyInfo.GetValue(elementSup, null);
                            listPropNameValues.Add(string.Format(" {0} : {1} ", propName, propValue));
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                sb.Append(FormatProperties(type.Name, listPropNameValues));
            }
            return sb.ToString();
        }
        public string FormatProperties(String className, List<string> listNameValue)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.Append(" Class name: ").Append(className);
            sb.AppendLine();
            foreach (var element in listNameValue)
            {
                sb.AppendLine(element);
            }
            return sb.ToString(); ;
        }
    }
}
