using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWebApplication.Models
{
    public class Bid
    {
        public int ItemNumber { get; set; }
        public int Price { get; set; }
        public string BidCustomName { get; set; }
        public string BidCustomPhone { get; set; }
    }
}