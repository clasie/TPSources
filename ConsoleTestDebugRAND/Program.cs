using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestDebugRAND
{
    //[DomainName("MyTable")]
    //class Test {
    //}
    //class DomainNameAttribute
    //{

    //}
    class Program
    {
        static void Main(string[] args)
        {
            TokenHandler.Token.Instance.IsValidKey(TokenHandler.Constants.TokenKey.GeneratedKeyToTest);
        }
    }
}
