using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Classes
{
    /// <summary>
    /// Constants static class
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Server port
        /// </summary>
        public const int port = 8888;

        /// <summary>
        /// Server ip-address
        /// </summary>
        public const string ipAddres = "127.0.0.1";

        /// <summary>
        /// Limitation for received and sent files
        /// </summary>
        public const int byteLimit = 8080;

        /// <summary>
        /// A regular expression to read double numbers from a file
        /// </summary>
        public const string readingDoublePattern = @"-?\d+(?:\,\d+)?";

        public const int pause = 10000;

        public const int listenerLimit = 2;
    }

    
}
