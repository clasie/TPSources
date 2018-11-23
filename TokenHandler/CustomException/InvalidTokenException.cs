using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenHandler.Constants;

namespace TokenHandler.CustomException
{

    [Serializable]
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException()
        {

        }

        public InvalidTokenException(string name)
            : base(String.Format("{0} {1}", TokenKey.CustomExceptionLabel, name))
        {

        }

    }
}
