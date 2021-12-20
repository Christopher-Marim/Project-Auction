using Auction.Data.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Ws.Server.ServerRequests
{
    public class RequestsToClient
    {

        private static RequestsToClient _instance;

        List<User> registeredUsers;
        AuctionModel currentAuction;
        int counter;

        public static RequestsToClient GetInstance() 
        {
            if (_instance == null)
            {
                _instance = new RequestsToClient();
            }
            return _instance;
        }

        public RequestsToClient()
        {
            registeredUsers = new List<User>();
            counter = 0;
        }

        public async Task GetCurrentTime(HttpContext httpContext, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                System.Threading.CancellationToken.None);
            if (result != null)
            {
                while (!result.CloseStatus.HasValue)
                {
                    string message = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                    Console.WriteLine($"Client says: {message}");
                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes($"Server says: {DateTime.UtcNow:f}")),
                        result.MessageType, result.EndOfMessage, System.Threading.CancellationToken.None);
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                }
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);
        }

        public async Task ConnectToAuction(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                System.Threading.CancellationToken.None);
            if (result != null)
            {
                while (!result.CloseStatus.HasValue)
                {
                    string message = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                    Console.WriteLine($"Client says: {message}");

                    var user = registeredUsers[0];
                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                        $"Server says\nGuid For connection: {user.Id}" +
                        $"\n{user.Name} You entered the auction!" +
                        $"\nCurrentItem: Car" +
                        $"\nCurrentValue: 1000$")),
                        result.MessageType, result.EndOfMessage, System.Threading.CancellationToken.None);
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                }
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);
        }

        public async Task RegisterClient(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                System.Threading.CancellationToken.None);
            if (result != null)
            {
                while (!result.CloseStatus.HasValue)
                {
                    string message = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                    
                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                        $"Server says\nId: " +
                        $"\nUsername: ")),
                        result.MessageType, result.EndOfMessage, System.Threading.CancellationToken.None);
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                }
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);
        }

        public async Task CreateAuction(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                System.Threading.CancellationToken.None);
            if (result != null)
            {
                while (!result.CloseStatus.HasValue)
                {
                    string message = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                    Console.WriteLine($"Client says: {message}");

                    Console.WriteLine("Digite o nome do item:\n");
                    var name = Console.ReadLine();
                    Console.WriteLine("Digite o preço inicial do item:\n");
                    var priceMin = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Digite uma descrição do item caso deseje, " +
                        "caso não, apenas ignore:\n");
                    var about = Console.ReadLine();
                    if (about.Length == 0)
                    {
                        about = null;
                    }
                    Console.WriteLine("Digite quanto tempo deseja que dure o leilão (em minutos):\n");
                    var time = int.Parse(Console.ReadLine());

                    currentAuction = new AuctionModel(Guid.NewGuid().ToString(), name, $"C:/xesque", priceMin.ToString(),
                        priceMin, DateTime.Now.ToString(), about, time);

                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                        $"Server says\nAuction created!!!" +
                        $"\nNome do item: {currentAuction.Name}" +
                        $"\nPreço inicial: {currentAuction.PriceMin.ToString()}" +
                        $"\nCriado em {currentAuction.Date}" +
                        $"\nLeilão se encerra em {currentAuction.Time}")),
                        result.MessageType, result.EndOfMessage, System.Threading.CancellationToken.None);
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                }
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);
        }

        public async Task SetNewPriceToAuction(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),
                System.Threading.CancellationToken.None);
            if (result != null)
            {
                while (!result.CloseStatus.HasValue)
                {
                    string message = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                    Console.WriteLine($"Client says: {message}");
                    currentAuction.Price += Double.Parse(message);
                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                        $"Server says\nAuction : {currentAuction.Name}" +
                        $"\nNovo maior lance: {currentAuction.Price}")),
                        result.MessageType, result.EndOfMessage, System.Threading.CancellationToken.None);
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                }
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);
        }
    }
}
