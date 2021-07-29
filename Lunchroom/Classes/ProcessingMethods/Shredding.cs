using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Classes.ProcessingMethods
{
    public class Shredding : ProcessingMethod
    {
        public Shredding()
            : base("Chop into salad", 1, 0)
        {
            this.ProcessingCapacity = 5;
        }

        
    }
}
