using Algebra.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Algebra.Interfaces;
using Algebra.SLAE;

namespace Algebra.Transfer
{
    /// <summary>
    /// Class for transferring data using the Tcp/ip protocol
    /// </summary>
    public abstract class TcpIpTransfer : Interfaces.Transfer
    {
        /// <summary>
        /// Tsp/ip server connection
        /// </summary>
        public TcpListener server = new TcpListener(Constants.localAddress, Constants.port);

        private TcpClient client;

        private NetworkStream stream;

        public SolveMethod CurrentMethod { get; set; }

        /// <summary>
        /// Connecting and working with the server
        /// </summary>
        public void Connect()
        {
            
            server.Start();
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient();
                    stream = client.GetStream();
                    try
                    {
                        if (stream.CanRead)
                        {
                            double[][] leftMatrix = null;
                            double[] rightArray = null;


                            /* 
                             * --- Anonymous method ---
                             * Getting the coefficients of the left side,
                             * that is, a two-dimensional array
                             */
                            CurrentMethod.GoToSolve += async (s, e) =>
                            {
                                // time for new information
                                await Task.Delay(1000);


                                byte[] readBuffer = new byte[1024 * Constants.byteLimit];
                                StringBuilder result = new StringBuilder();
                                int numberOfBytesRead = 0;

                                do
                                {
                                    numberOfBytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
                                    result.AppendFormat("{0}", Encoding.UTF8.GetString(readBuffer, 0, numberOfBytesRead));
                                }
                                while (stream.DataAvailable);

                                leftMatrix = ReadingTemplate.GetCoefficientsByTemplate(result.ToString(), "\n");
                            };


                            /*
                             * --- Anonymous method ---
                             * Getting the coefficients of the right side,
                             * that is, a one-dimensional array
                             */
                            CurrentMethod.GoToSolve += async (s, e) =>
                            {
                                // time for new information
                                await Task.Delay(Constants.pause);


                                byte[] readBuffer = new byte[1024 * Constants.byteLimit];
                                StringBuilder result = new StringBuilder();
                                int numberOfBytesRead = 0;

                                do
                                {
                                    numberOfBytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
                                    result.AppendFormat("{0}", Encoding.UTF8.GetString(readBuffer, 0, numberOfBytesRead));
                                }
                                while (stream.DataAvailable);

                                rightArray = ReadingTemplate.GetUpshotByTemplate(result.ToString());
                            };


                            /*
                             * Event triggering
                             */
                            CurrentMethod.InvokeEvent(leftMatrix, rightArray);

                            string answer = CurrentMethod.ToString();
                            Byte[] responseData = Encoding.UTF8.GetBytes(answer);

                            stream.Write(responseData, 0, responseData.Length);
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



       
    }
}
