using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logging
{
    public static class Information
    {
        public static List<string> LogText = new List<string>();

        public static void AddLog(string info)
        {
            LogText.Add('[' +DateTime.Now.ToString("H/mm/ss") + "] -- " + info.ToString());
        }
    }
}
