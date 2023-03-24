using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading;

namespace H1_ChatClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ipAddress = "127.0.0.1";
            int port = 8080;

            Connection client = new Connection(ipAddress, port);

            client.ConnectToServer();
            Console.Write("Press any key");
            Console.ReadKey();
            Console.Clear();

            client.ServerConnection();
            try
            {
                string messageSent = "";
                string messageRecieved = "";

                while (client.isConnected)
                {
                    messageSent = Console.ReadLine();

                    if (messageSent == "quit")
                    {
                        client.isConnected = false;
                    }
                    else
                    {
                        client.streamWriter.WriteLine(messageSent);
                        client.streamWriter.Flush();
                        messageRecieved = client.streamReader.ReadLine();
                        Console.WriteLine(messageRecieved);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Connection Error");
                Console.ReadKey();
            }

            client.Disconect();

        }
    }
}