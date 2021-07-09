using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.DataWork
{
    public interface IDataFactory
    {
        void DataRead(string path);

        void DataWrite(string path);
    }
}
