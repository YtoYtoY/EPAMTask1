using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Classes
{
    public static class Constants
    {
        public const int port = 8888;
        public static readonly IPAddress localAddress = IPAddress.Any;
        public const int byteLimit = 3000;
        public const string readingDoublePattern = @"-?\d+(?:\,\d+)?";
    }
}
