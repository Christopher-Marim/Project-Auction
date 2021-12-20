using Auction.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.ServerTemp.ServerRequests
{
    public class ClientRequests
    {
        private static ClientRequests _instance;

        public List<User> registeredUsers;
        public AuctionModel currentAuction;
        public int counter;

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
    }
}
