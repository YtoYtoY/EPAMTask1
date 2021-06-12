using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logging
{
    public class DataRegister
    {
        public string DataLoggerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOG");
        public void WriteLogData()
        {
            if(Directory.Exists(DataLoggerPath))
            {
                Stream fs = File.Create(Path.Combine(DataLoggerPath, $"log - [{DateTime.Now.ToString("dd/MM/yy H/mm/ss")}].txt"));
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in Information.LogText)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
            }
        }
    }
}
