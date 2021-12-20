using System;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ws.Server.ServerRequests;
using Ws.ServerTemp.ServerRequests;

namespace Ws.ClientTemp
{
    class Program
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private const int PORT = 5000;

        static void Main()
        {
            Console.Title = "Client";
            ConnectToServer();
            RequestLoop();
            Exit();
        }

        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(IPAddress.Loopback, PORT);
                    MulticastBroadcast.JoinMulticastGroup();
                }
                catch (SocketException)
                {
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Connected");
        }

        private static void RequestLoop()
        {
            Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");

            while (true)
            {
                SendRequest();
                ReceiveResponse();
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        private static void Exit()
        {
            SendString("exit"); // Tell the server we are exiting
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        private static void SendRequest()
        {
            Console.Write("Send a request: ");
            string request = Console.ReadLine();
            string message = "";
            if (request.ToLower() == "create auction")
            {
                message = "create auction,";
                Console.WriteLine($"Create a new auction:\n\n");
                Console.WriteLine("Digite o nome do item:\n");
                var name = Console.ReadLine();
                message = message + name + ",";
                Console.WriteLine("Digite o preço inicial do item:\n");
                var priceMin = Double.Parse(Console.ReadLine());
                message = message + priceMin + ",";
                Console.WriteLine("Digite uma descrição do item caso:\n");
                var about = Console.ReadLine();
                message = message + about + ",";
                Console.WriteLine("Digite quanto tempo deseja que dure o leilão (em minutos):\n");
                var time = Console.ReadLine();
                message = message + time;

                SendString(message);
            }
            else if (request.ToLower() == "connect to auction")
            {
                Console.Write("Digite o seu ID:\n");
                var id = Console.ReadLine();
                message = "connect to auction," + id;

                SendString(message);
            }
            else if (request.ToLower() == "set new auction price")
            {
                message = "set new auction price,";

                Console.Write("Digite o seu ID:\n");
                var id = Console.ReadLine();
                message = message + id + ",";

                double newValue = 0;
                while (newValue < 10)
                {
                    Console.WriteLine("Escreva em quanto você quer aumentar o lance atual:\n" +
                        "O valor deve ser superior a 10$");
                    newValue = Double.Parse(Console.ReadLine());
                }
                message = message + newValue.ToString();

                SendString(message);
            }

            //SendString(message);

            if (request.ToLower() == "exit")
            {
                Exit();
            }
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private static void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            Console.WriteLine(text);
        }
    }
}
