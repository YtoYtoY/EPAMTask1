using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Classes.ProcessingMethods
{
    public class SaladMixing : ProcessingMethod
    {
        public SaladMixing()
            : base("Mix the salad", 1, 0)
        {
            this.ProcessingCapacity = 3;
        }
    }
}
