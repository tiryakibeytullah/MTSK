using System;
using System.Collections.Generic;

namespace mtsk.Models.Responses
{
    public class GetBasketResponseMessage
    {
        public int success { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public List<SiparisData> siparisData { get; set; }
            public List<AddressData> addressData { get; set; }
        }
        public class SiparisData
        {
            public int TEMPORDERID { get; set; }
            public int TEMPORDERPIECE { get; set; }
            public int TEMPORDERPRICE { get; set; }
        }

        public class AddressData
        {
            public int ADDRESSID { get; set; }
            public string OPENADDRESS { get; set; }
            public string CITY { get; set; }
            public string DISTRICT { get; set; }
        }
    }
    

    
}
