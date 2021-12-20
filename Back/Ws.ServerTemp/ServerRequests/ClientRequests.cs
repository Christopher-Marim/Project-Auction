using Auction.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Timers;

namespace Ws.ServerTemp.ServerRequests
{
    public class ClientRequests
    {
        private static ClientRequests _instance;

        public List<User> registeredUsers;
        public AuctionModel currentAuction;
        public int counter;
        static Timer timer;

        public static ClientRequests GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClientRequests();
            }
            return _instance;
        }

        public ClientRequests()
        {
            registeredUsers = new List<User>();
            counter = 0;
        }

        public void StartTimer(int minutes) 
        {
            timer = new Timer(minutes * 60000);
            timer.AutoReset = false;
            timer.Elapsed += (source, eventArgs) =>
            {
                Console.WriteLine("Executando timer");
            };
            timer.Interval = minutes * 60000;
            timer.Start();
            
        }
    }
}
