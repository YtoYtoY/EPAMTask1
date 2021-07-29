using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Classes.ProcessingMethods
{
    public class Bake : ProcessingMethod
    {
        public Bake()
            : base("Bake until tender", 10, 5)
        {
            this.ProcessingCapacity = 2;
        }
    }
}
