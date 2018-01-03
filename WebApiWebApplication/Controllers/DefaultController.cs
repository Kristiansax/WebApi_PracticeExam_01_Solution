using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWebApplication.Models;

namespace WebApiWebApplication.Controllers
{
    public class DefaultController : ApiController
    {
        public List<AuctionItem> GetAuctions()
        {
            return AuctionRepository.Instance.GetList();
        }

        public AuctionItem GetAuctionItem(int itemnumber)
        {
            var list = AuctionRepository.Instance.GetList();
            AuctionItem result = list.Where(x => x.ItemNumber == itemnumber).SingleOrDefault();

            return result;
        }

        public HttpResponseMessage Put([FromBody]Bid bid)
        {
            var list = AuctionRepository.Instance.GetList();
            AuctionItem item = list.Where(x => x.ItemNumber == bid.ItemNumber).SingleOrDefault();

            if (item != null)
            {
                if (bid.Price > item.RatingPrice && bid.Price > item.BidPrice)
                {
                    AuctionRepository.Instance.UpdateList(bid);
                    return Request.CreateResponse(HttpStatusCode.OK, "OK");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "The bid is too low");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Could not find auction");
            }
        }
    }
}
