using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Ws.ServerTemp.ServerRequests
{
    public class MulticastBroadcast
    {
        public static IPAddress mcastAddress;
        public static int mcastPort;
        public static Socket mcastSocket;

        public static void JoinMulticastGroup()
        {
            try
            {
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint IPlocal = new IPEndPoint(ipAddress, 5000);

                mcastSocket.Bind(IPlocal);

                MulticastOption mcastOption;
                mcastOption = new MulticastOption(mcastAddress, IPAddress.Parse("127.0.0.1"));

                mcastSocket.SetSocketOption(SocketOptionLevel.IP,
                                            SocketOptionName.AddMembership,
                                            mcastOption);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.ToString());
            }
        }

        public static void BroadcastMessage(string message)
        {
            IPEndPoint endPoint;

            try
            {
                //Send multicast packets to the listener.
                endPoint = new IPEndPoint(mcastAddress, mcastPort);
                mcastSocket.SendTo(ASCIIEncoding.ASCII.GetBytes(message), endPoint);
                Console.WriteLine("Multicast data sent.....");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.ToString());
            }

            mcastSocket.Close();
        }
    }
}
