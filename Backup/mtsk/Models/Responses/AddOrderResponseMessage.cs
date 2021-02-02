using System;
namespace mtsk.Models.Responses
{
    public class AddOrderResponseMessage
    {
        public int success { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public int torderPiece { get; set; }
            public int torderPrice { get; set; }
            public int torderCase { get; set; }
            public int userID { get; set; }
        }
    }
}
