using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Interfaces
{
    public interface ISerialization
    {
        void Save<T>(ICollection<T> data, string path);
        ICollection<T> Restore<T>(string path);
    }
}
