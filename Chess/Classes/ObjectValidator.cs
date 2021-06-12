using Chess.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    public static class ObjectValidator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage)
        {
            if (obj == null)
            {
                Information.AddLog(errorMessage);
                throw new NullReferenceException(errorMessage);
            }
        }
    }
}
