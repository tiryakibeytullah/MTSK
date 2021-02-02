using System;
using System.Collections.Generic;

namespace mtsk.Models.Responses
{
    public class GetPastOrderResponseMessage
    {
        public int success { get; set; }
        public List<Data> data { get; set; }

        public class Data
        {
            public int UserID { get; set; }
            public string NAME_ { get; set; }
            public string SURNAME { get; set; }
            public string TELEPHONE { get; set; }
            public string GENDER { get; set; }
            public int ORDERPIECE { get; set; }
            public int TOTALPRICE { get; set; }
            public DateTime orderDate { get; set; }
            public string OPENADDRESS { get; set; }
            public string CITY { get; set; }
            public string DISTRICT { get; set; }
            public string PAYMENTNAME { get; set; }
            public string SHIPMENTNAME { get; set; }
        }
    }
}
