using Algebra.SLAE;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    public class HttpTransfer : ServerTcp
    {
        public string[] requestString { get; set; }
        public override async void Request(SolveMethod method)
        {
            CurrentMethod = method;
            int index = 0;
            while(eventFlag || index + 1 < requestString.Length)
            {
                try
                {
                    HttpWebRequest webRequest = HttpWebRequest.CreateHttp(requestString[index]);
                    GoToSolve += LeftPart_Action;
                    GoToSolve += RightPart_Action;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            InvokeIvent();
        }

        private async void LeftPart_Action(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (CurrentMethod.LeftPart == null && CurrentMethod.RightPart == null)
                {

                    //CurrentMethod.LeftPart = ReadingTemplate.GetCoefficientsByTemplate(data.ToString(), "\n");
                }
            });
        }

        private async void RightPart_Action(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (CurrentMethod.LeftPart != null)
                {

                    //CurrentMethod.RightPart = ReadingTemplate.GetUpshotByTemplate(data.ToString());
                }
            });
        }


        public override void Response(Socket tcpSocket, string answer)
        {
            throw new NotImplementedException();
        }
    }
}
