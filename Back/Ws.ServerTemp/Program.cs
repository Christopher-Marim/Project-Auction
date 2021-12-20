using Auction.Data.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Ws.ServerTemp.ServerRequests;

namespace Ws.ServerTemp
{
    class Program
    {
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> clientSockets = new List<Socket>();
        private static readonly List<Socket> clientSocketsConnectedToTheAuction = new List<Socket>();
        private const int BUFFER_SIZE = 2048;
        private const int PORT = 5000;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];
        public ClientRequests requests;

        static void Main()
        {
            Console.Title = "Server";
            SetupServer();
            Console.ReadLine(); // When we press enter close everything
            CloseAllSockets();
        }

        private static void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
            Console.WriteLine("Server setup complete");
        }

        /// <summary>
        /// Close all connected client (we do not need to shutdown the server socket as its connections
        /// are already closed with the clients).
        /// </summary>
        private static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            var requests = ClientRequests.GetInstance();
            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            User user = new User($"User{requests.counter}", requests.counter);
            requests.registeredUsers.Add(user);
            requests.counter += 1;
            Console.WriteLine($"Client {requests.counter} connected and registered, waiting for request...");
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            var requests = ClientRequests.GetInstance();
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                current.Close();
                clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.UTF8.GetString(recBuf);
            Console.WriteLine("Received Text: " + text);

            if (text.ToLower() == "get time") //Tempo atual
            {
                Console.WriteLine("Text is a get time request");
                byte[] data = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());
                current.Send(data);
                Console.WriteLine("Time sent to client");
            }
            else if (text.ToLower().Contains("create auction")) //Criar leilão
            {
                string[] words = text.Split(',');
                string name = "";
                string priceMin = "";
                string about = "";
                string time = "";
                for (int i = 0; i < words.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            //ignore
                            break;
                        case 1:
                            name = words[i];
                            break;
                        case 2:
                            priceMin = words[i];
                            break;
                        case 3:
                            about = words[i];
                            break;
                        case 4:
                            time = words[i];
                            break;
                        default:
                            break;
                    }
                }
                
                requests.currentAuction = new AuctionModel(Guid.NewGuid().ToString(), name, $"C:/xesque", 
                    priceMin,Double.Parse(priceMin), DateTime.Now.ToString(), about, int.Parse(time));

                byte[] data = Encoding.ASCII.GetBytes(
                        $"Server says\nAuction created!!!" +
                        $"\nNome do item: {requests.currentAuction.Name}" +
                        $"\nPreço inicial: {requests.currentAuction.PriceMin.ToString()}" +
                        $"\nCriado em {requests.currentAuction.Date}" +
                        $"\nLeilão se encerra em {requests.currentAuction.Time}");
                current.Send(data);
                Console.WriteLine("Time sent to client");
            }
            else if (text.ToLower().Contains("connect to auction")) //Client se conecta ao leilão
            {
                Console.WriteLine("Connect to the auction");

                string[] words = text.Split(',');
                User user = null;
                foreach (var item in requests.registeredUsers)
                {
                    if (item.Id == int.Parse(words[1]))
                    {
                        user = item;
                    }
                }
                byte[] data = Encoding.UTF8.GetBytes(
                    $"Server says\nGuid For connection: {user.Id}" +
                    $"\n{user.Name} You entered the auction!" +
                    $"\nCurrentItem: {requests.currentAuction.Name}" +
                    $"\nCurrentValue: {requests.currentAuction.Price}");
                current.Send(data);
                Console.WriteLine("Time sent to client");
            }
            else if (text.ToLower().Contains("set new auction price")) //Client faz um lance
            {
                Console.WriteLine($"Set new price to the auction");
                string[] words = text.Split(',');
                User user = null;
                foreach (var item in requests.registeredUsers)
                {
                    if (item.Id == int.Parse(words[1]))
                    {
                        user = item;
                        user.Winner = true;
                    }
                }
                requests.currentAuction.Price += Double.Parse(words[2]);
                byte[] data = Encoding.UTF8.GetBytes(
                    $"Server says\nAuction : {requests.currentAuction.Name}" +
                    $"\nNovo maior lance: {requests.currentAuction.Price}" +
                    $"\nPor: {user.Name}");
                current.Send(data);
                Console.WriteLine("Time sent to client");
            }
            else if (text.ToLower() == "exit") //Client vaza
            {
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                clientSockets.Remove(current);
                Console.WriteLine("Client disconnected");
                return;
            }
            else //Request inválido
            {
                Console.WriteLine("Text is an invalid request");
                byte[] data = Encoding.UTF8.GetBytes("Invalid request");
                current.Send(data);
                Console.WriteLine("Warning Sent");
            }

            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }
    }
}
