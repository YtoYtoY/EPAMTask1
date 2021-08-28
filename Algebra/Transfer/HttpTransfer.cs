using Algebra.Classes;
using Algebra.SLAE;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    /// <summary>
    /// Receiving client data via http link
    /// </summary>
    public class HttpTransfer : ServerTcp
    {
        /// <summary>
        /// Links for data
        /// </summary>
        public string[] requestString = new string[Constants.listenerLimit];

        /// <summary>
        /// Request for data
        /// </summary>
        /// <param name="method">Method for dolving SLAE</param>
        public override void Request(SolveMethod method)
        {
            _CurrentMethod = method;
            int index = 0;

            while (index < Constants.listenerLimit)
            {
                HttpWebRequest webRequest = HttpWebRequest.CreateHttp(requestString[index]);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var stream = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
                _data[index] = new StringBuilder(stream);
                index++;
            }
            GoToSolve += LeftPart_Action;
            GoToSolve += RightPart_Action;

            InvokeIvent();
        }
    }
}
