using Algebra.Classes;
using Algebra.SLAE;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    public class TcpTransfer : ServerTcp
    {
        private Socket listener = null;
        public override void Request(SolveMethod method)
        {
            CurrentMethod = method;
            Start();

            while (eventFlag)
            {
                listener = tcpSocket.Accept();
                do
                {
                    GoToSolve += LeftPart_Action;
                    GoToSolve += RightPart_Action;
                }
                while (listener.Available > 0);

                Finish(listener);
            }
            InvokeIvent();
            string answer = ReadingTemplate.SetToString(CurrentMethod.Answer);
            listener.Send(Encoding.UTF8.GetBytes(answer));
        }

        public async void LeftPart_Action()
        { 
            await Task.Run(() =>
            {
                if (CurrentMethod.LeftPart == null && CurrentMethod.RightPart == null)
                {
                    var buffer = new byte[1024 * Constants.byteLimit];
                    var data = new StringBuilder();

                    int size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                    CurrentMethod.LeftPart = ReadingTemplate.GetCoefficientsByTemplate(data.ToString(), "\n");
                }
            });
        }

        public async void RightPart_Action()
        {
            await Task.Run(() =>
            {
                if (CurrentMethod.LeftPart != null)
                {
                    var buffer = new byte[1024 * Constants.byteLimit];
                    var data = new StringBuilder();

                    int size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                    CurrentMethod.RightPart = ReadingTemplate.GetUpshotByTemplate(data.ToString());
                }
            });
        }
    }
}