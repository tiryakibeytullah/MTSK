using System;
namespace mtsk.Models.Responses
{
    public class AddAddressResponseMessage
    {
        public int success { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public int cityID { get; set; }
            public int districtID { get; set; }
            public string openAddress { get; set; }
            public int userID { get; set; }
        }
    }
}
