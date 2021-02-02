using System;
namespace mtsk.Models.Responses
{
    public class OrderCompleteResponseMessage
    {
        public int success { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public string orderPiece { get; set; }
            public string orderTotalPrice { get; set; }
            public string addressID { get; set; }
            public string paymentID { get; set; }
            public string shipmentID { get; set; }
            public int userID { get; set; }
            public string orderDate { get; set; }
        }
    }
}
