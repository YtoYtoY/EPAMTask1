using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Structs
{
    public struct Move
    {
        public Position From { get; private set; }
        public Position To { get; private set; }
        public Move(Position from, Position to)
            : this()
        {
            this.From = from;
            this.To = to;
        }
    }
}
