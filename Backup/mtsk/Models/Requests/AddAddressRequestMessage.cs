using System;
namespace mtsk.Models.Requests
{
    public class AddAddressRequestMessage
    {
        public int cityID { get; set; }
        public int districtID { get; set; }
        public string openAddress { get; set; }
    }
}
