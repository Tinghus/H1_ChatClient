using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace H1_ChatClient
{
    public class Connection
    {
        public string Ip { get; set; }
        public int port { get; set; }
        private TcpClient socketForServer;
        public bool isConnected = true;

        public NetworkStream networkStream { get; set; }
        public StreamReader streamReader { get; set; }
        public StreamWriter streamWriter { get; set; }

        public Connection(string myIp, int port)
        {
            this.Ip = myIp;
            this.port = port;
        }

        public void ConnectToServer()
        {
            try
            {
                socketForServer = new TcpClient(Ip.ToString(), port);
            }
            catch
            {
                Console.WriteLine("Connection failed");
                return;
            }
        }

        public void ServerConnection()
        {
            networkStream = socketForServer.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
        }

        public void Disconect()
        {
            streamWriter.Flush();
            streamWriter.Close();
            networkStream.Close();
            streamWriter.Close();
            socketForServer.Close();
        }
    }
}
