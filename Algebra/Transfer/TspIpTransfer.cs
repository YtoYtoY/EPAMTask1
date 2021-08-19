using Algebra.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    class TspIpTransfer : Transfer
    {
        public override void Connect()
        {
            server.Start();
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    try
                    {
                        if (stream.CanRead)
                        {
                            GetAndSolve(stream);
                        }
                    }
                    finally
                    {
                        stream.Close();
                        client.Close();
                    }
                }
                catch
                {
                    server.Stop();
                    break;
                }
            }
        }

        public override void GetAndSolve(NetworkStream stream)
        {
            byte[] myReadBuffer = new byte[1024 * Constants.byteLimit];
            StringBuilder myCompleteMessage = new StringBuilder();
            int numberOfBytesRead = 0;
            do
            {
                numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                myCompleteMessage.AppendFormat("{0}", Encoding.UTF8.GetString(myReadBuffer, 0, numberOfBytesRead));
            }
            while (stream.DataAvailable);

            CurrentMethod.GoToSolve += CurrentMethod_GoToSolve;
            string answer = "TODO";                                // Туд должны быть иксы
            Byte[] responseData = Encoding.UTF8.GetBytes(answer);  // Это надо отослать

            stream.Write(responseData, 0, responseData.Length);
        }

        private void CurrentMethod_GoToSolve(object sender, EventArgs e)
        {
            
        }
    }
}
