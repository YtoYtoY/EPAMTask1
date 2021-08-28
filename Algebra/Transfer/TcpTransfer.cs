using Algebra.Classes;
using Algebra.SLAE;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    /// <summary>
    /// Receiving client data
    /// </summary>
    public class TcpTransfer : ServerTcp
    {
        /// <summary>
        /// Current listener
        /// </summary>
        private Socket listener = null;

        /// <summary>
        /// Request for data
        /// </summary>
        /// <param name="method">Method for solving SLAE</param>
        public override void Request(SolveMethod method)
        {
            _CurrentMethod = method;
            _tcpEndPoint = new IPEndPoint(IPAddress.Parse(Constants.ipAddres), Constants.port);
            _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _tcpSocket.Bind(_tcpEndPoint);
            _tcpSocket.Listen(Constants.listenerLimit);

            int index = 0;

            while (index < Constants.listenerLimit)
            {
                var buffer = new byte[1024 * Constants.byteLimit];                
                listener = _tcpSocket.Accept();
                do
                {
                    int size = listener.Receive(buffer);
                    _data[index].Append(Encoding.UTF8.GetString(buffer, 0, size));
                    index++;
                }
                while (listener.Available > 0);

                GoToSolve += LeftPart_Action;
                GoToSolve += RightPart_Action;

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
            InvokeIvent();

            string answer = ReadingTemplate.SetToString(_CurrentMethod.Answer);
            listener.Send(Encoding.UTF8.GetBytes(answer));
        }

        
    }
}