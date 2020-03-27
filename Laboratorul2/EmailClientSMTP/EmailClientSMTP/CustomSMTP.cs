using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EmailClientSMTP
{
    public class CustomSMTP : TcpClient
    {
        public string from = null;
        public ArrayList to;
        public ArrayList cc;
        public ArrayList bcc;
        public string subject = null;
        public string bodyText = null;
        public string bodyHtml = null;
        public string server = null;
        public CustomSMTP()
        {
            to = new ArrayList();
            cc = new ArrayList();
            bcc = new ArrayList();
        }
    }
}
