using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Algebra.Classes;
using Algebra.SLAE;

namespace Algebra.Transfer
{
    /// <summary>
    /// Delegate for event methods
    /// </summary>
    public delegate void EventDelegate();

    /// <summary>
    /// Abstract server class over the TSP / Ip protocol
    /// </summary>
    public abstract class ServerTcp
    {
        /// <summary>
        /// Delegate based event
        /// </summary>
        public event EventDelegate GoToSolve = null;

        /// <summary>
        /// Current method for solving SLAE
        /// </summary>
        protected SolveMethod _CurrentMethod { get; set; }

        /// <summary>
        /// TSP socket
        /// </summary>
        protected Socket _tcpSocket;

        /// <summary>
        /// Connection endpoint with ip address and port
        /// </summary>
        protected IPEndPoint _tcpEndPoint;


        /// <summary>
        /// StringBuilder array with the received data
        /// </summary>
        protected StringBuilder[] _data = new StringBuilder[Constants.listenerLimit];

        /// <summary>
        /// Method for raising the event - solving the SLAE
        /// </summary>
        public void InvokeIvent()
        {
            GoToSolve?.Invoke();

            if (_CurrentMethod.LeftPart == null || _CurrentMethod.RightPart == null)
                throw new Exception(Exceptions.MethodProcessingError);

            _CurrentMethod.TrySolve(_CurrentMethod.LeftPart, _CurrentMethod.RightPart);
        }

        /// <summary>
        /// Request for data
        /// </summary>
        /// <param name="method">Method for solving SLAE</param>
        public abstract void Request(SolveMethod method);

        /// <summary>
        /// Getting the matrix .A
        /// </summary>
        public void LeftPart_Action() => 
            _CurrentMethod.LeftPart = ReadingTemplate.GetCoefficientsByTemplate(_data[0].ToString(), "\n");

        /// <summary>
        /// Getting vector .B
        /// </summary>
        public void RightPart_Action() =>
            _CurrentMethod.RightPart = ReadingTemplate.GetUpshotByTemplate(_data[1].ToString());
    }
}
