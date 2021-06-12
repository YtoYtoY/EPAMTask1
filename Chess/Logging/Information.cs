using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logging
{
    public class Information
    {
        public List<string> LogText = new List<string>();

        public void AddLog(string info)
        {
            LogText.Add('[' +DateTime.Now.ToString("dd/MM/yy H/mm/ss") + "] -- " + info.ToString());
        }
        public override string ToString()
        {
            return LogText.ToString();
        }
        public override int GetHashCode()
        {
            return LogText.GetHashCode();
        }
    }
}
