using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Parser
{
    public class TEXT : Parser
    {
        public void SetToFile(string path, Delegate methods)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                string text = string.Empty;
                try
                {
                    var delegates = methods.GetInvocationList();
                    foreach (var item in delegates)
                    {

                        text += ((ForExecution)item)();

                    }
                    writer.Write(text);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}
