using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Classes.ProcessingMethods
{
    public class MeatFry : ProcessingMethod
    {
        public MeatFry()
            : base("Fry meat products", 10, 5)
        {
            this.ProcessingCapacity = 30;
        }
    }
}
