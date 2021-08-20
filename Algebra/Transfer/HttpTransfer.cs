using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Algebra.Transfer
{
    public class HttpTransfer : TcpIpTransfer
    { 
        public void Connect(string path)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(path);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                StreamReader myStreamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding(1251));
                // TODO:
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
