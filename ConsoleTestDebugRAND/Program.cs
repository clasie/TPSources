using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestDebugRAND
{
    class Program
    {
        class Test {
            public int P1 { get; set; }
            public string P2 { get; set; }
            public string P3 { get; set; }
        }
        static void Main(string[] args)
        {
            List<Test> testList = new List<Test>() {
                new Test() { P1 = 10, P2 = "value1", P3 = "value1" },
                new Test() { P1 = 10, P2 = "value2", P3 = "value2" },
                new Test() { P1 = 10, P2 = "value3", P3 = "value3" }
            };
            Reflect r = new Reflect();
            var x = r.GetValues(testList);
        }
        public class Reflect {
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
                            catch (Exception ex) {
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
                foreach (var element in listNameValue) {
                    sb.AppendLine(element);
                }
                return sb.ToString(); ;
            }
        }
    }
}
