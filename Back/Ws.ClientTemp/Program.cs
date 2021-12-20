using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ws.Server.ServerRequests;

namespace Ws.ClientTemp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press enter to continue...");
                var command = Console.ReadLine();
                string callToServer;
                switch (command)
                {
                    case "1":
                        callToServer = "getCurrentTime";
                        break;
                    case "2":
                        callToServer = "connectToAuction";
                        break;
                    case "3":
                        callToServer = "registerClient";
                        break;
                    case "0":
                        System.Environment.Exit(0);
                        callToServer = "";
                        break;
                    default:
                        callToServer = "getCurrentTime";
                        break;
                }

                using (ClientWebSocket client = new ClientWebSocket())
                {
                    Uri serviceUri = new Uri($"ws://localhost:5000/{callToServer}");
                    var cTs = new CancellationTokenSource();
                    cTs.CancelAfter(TimeSpan.FromSeconds(120));
                    try
                    {
                        await client.ConnectAsync(serviceUri, cTs.Token);

                        ArraySegment<byte> byteToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(callToServer));
                        await client.SendAsync(byteToSend, WebSocketMessageType.Text, true, cTs.Token);
                        var responseBuffer = new byte[1024];
                        var offset = 0;
                        var packet = 1024;
                        ArraySegment<byte> byteReceived = new ArraySegment<byte>(responseBuffer, offset, packet);
                        WebSocketReceiveResult response = await client.ReceiveAsync(byteReceived, cTs.Token);
                        var responseMessage = Encoding.UTF8.GetString(responseBuffer, offset, response.Count);
                        Console.WriteLine(responseMessage);
                        await client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", cTs.Token);
                    }

                    catch (WebSocketException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
