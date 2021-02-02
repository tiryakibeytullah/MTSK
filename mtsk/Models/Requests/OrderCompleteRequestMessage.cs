using System;
namespace mtsk.Models.Requests
{
    public class OrderCompleteRequestMessage
    {
        public string orderPiece { get; set; }
        public string orderTotalPrice { get; set; }
        public string addressID { get; set; }
        public string paymentID { get; set; }
        public string shipmentID { get; set; }
    }
}
