using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Data.Model
{
    public class AuctionModel
    {
        string Id;
        public string Name;
        string Image;
        public string Price;
        public double PriceMin;
        public string Date;
        string? About;
        public int Time;

        public AuctionModel(string id, string name, string image, string price, double priceMin, string date, string? about, int time)
        {
            Id = id;
            Name = name;
            Image = image;
            Price = price;
            PriceMin = priceMin;
            Date = date;
            About = about;
            Time = time;
        }
    }
}
