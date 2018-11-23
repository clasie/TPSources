using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestDebugRAND
{
    class Program
    {
        static void Main(string[] args)
        {
            //var x = TokenHandler.Token
            //    .Instance.CheckTokenValidity(
            //        TokenHandler.Constants.TokenKey.GeneratedKeyToTest);
            var newKey = TokenHandler.Token.Instance.createToken("");

            var y = TokenHandler.Token.Instance.CheckTokenValidity(
                   //TokenHandler.Constants.TokenKey.GeneratedKeyToTest
                   newKey
                ).IsValidKey;
        }
    }
}
