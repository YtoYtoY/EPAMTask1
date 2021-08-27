using Algebra.SLAE;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    public class HttpTransfer : ServerTcp
    {
        public string[] requestString = new string[2];
        public override async void Request(SolveMethod method)
        {
            CurrentMethod = method;
            int index = 0;
            while (eventFlag)
            {
                
                GoToSolve += LeftPart_Action;
                GoToSolve += RightPart_Action;


                InvokeIvent();
            }
        }

        private async void LeftPart_Action()
        {
            HttpWebRequest webRequest = HttpWebRequest.CreateHttp(requestString[0]);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var responseString = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            CurrentMethod.LeftPart = ReadingTemplate.GetCoefficientsByTemplate(responseString.ToString(), "\n");
        }

        private void RightPart_Action()
        {
            HttpWebRequest webRequest = HttpWebRequest.CreateHttp(requestString[1]);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var responseString = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            CurrentMethod.RightPart = ReadingTemplate.GetUpshotByTemplate(responseString.ToString());
        }

    }
}
