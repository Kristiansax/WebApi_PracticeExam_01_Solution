using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWebApplication.Models;

namespace WebApiWebApplication
{
    public class AuctionRepository
    {
        private static List<AuctionItem> auctionList;
        private static AuctionRepository instance = null;
        private static readonly object padlock = new object();
        private AuctionRepository()
        {
            auctionList = new List<AuctionItem>
            {
                new AuctionItem
                {
                    BidCustomName = null,
                    BidCustomPhone = null,
                    BidPrice = 0,
                    BidTimeStamp = DateTime.Now,
                    ItemDescription = "Shoes",
                    RatingPrice = 200,
                    ItemNumber = 1111
                },
                new AuctionItem
                {
                    BidCustomName = null,
                    BidCustomPhone = null,
                    BidPrice = 0,
                    BidTimeStamp = DateTime.Now,
                    ItemDescription = "Amiga",
                    RatingPrice = 350,
                    ItemNumber = 2222
                },
                new AuctionItem{
                    BidCustomName = null,
                    BidCustomPhone = null,
                    BidPrice = 0,
                    BidTimeStamp = DateTime.Now,
                    ItemDescription = "Commodore 64",
                    RatingPrice = 400,
                    ItemNumber = 3333
                },
                new AuctionItem
                {
                    BidCustomName = null,
                    BidCustomPhone = null,
                    BidPrice = 0,
                    BidTimeStamp = DateTime.Now,
                    ItemDescription = "Tastatur",
                    RatingPrice = 800,
                    ItemNumber = 4444
                },
            };
        }

        public static AuctionRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuctionRepository();
                    }
                    return instance;
                }
            }
        }

        public List<AuctionItem> GetList()
        {
            lock (padlock)
            {
                return auctionList;
            }

        }

        public void UpdateList(Bid bid)
        {
            lock (padlock)
            {
                int index = auctionList.FindIndex(a => a.ItemNumber == bid.ItemNumber);
                auctionList[index] = new AuctionItem
                                        {
                                            BidCustomName = bid.BidCustomName,
                                            BidCustomPhone = bid.BidCustomPhone,
                                            ItemNumber = bid.ItemNumber,
                                            BidPrice = bid.Price,
                                            BidTimeStamp = DateTime.Now,
                                            ItemDescription = auctionList[index].ItemDescription,
                                            RatingPrice = auctionList[index].RatingPrice
                                        };
            }
        }
    }
}