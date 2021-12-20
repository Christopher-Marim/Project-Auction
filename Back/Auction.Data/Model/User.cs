﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(string name, int id)
        {
            //Id = Guid.NewGuid();
            Id = id;
            Name = name;
        }
    }
}