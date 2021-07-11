using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Parser
{
    public interface IParse
    {
        void DataRead(string path);
        void DataWrite(string path);

    }
}
