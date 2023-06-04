using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChattingServer
{
    public class State
    {

        private TcpClient client;
        private StringBuilder sb;
        private string name;
        private string ipAddress;
        private DateTime joinTime;
        private DateTime leaveTime;

        public State(string name, TcpClient client)
        {
            Name = name;
            Sb = new StringBuilder();
            Client = client;
            IpAddress = client.Client.RemoteEndPoint.AddressFamily.ToString();
            JoinTime = DateTime.Now;
        }

        public TcpClient Client
        {
            get { return client; }
            set { client = value; }
        }

        public StringBuilder Sb
        {
            get { return sb; }
            set { sb = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value;  }
        }

        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public DateTime JoinTime
        {
            get { return joinTime; }
            set { joinTime = value; }
        }

        public DateTime LeaveTime
        {
            get { return leaveTime; }
            set { leaveTime = value; }
        }

        public void Add(byte b)
        {
            sb.Append((char)b);
        }

        public void Send(string text)
        {
            var bytes = Encoding.ASCII.GetBytes(string.Format("{0}\r\n", text));
            client.GetStream().Write(bytes, 0, bytes.Length);
        }

    }
}
