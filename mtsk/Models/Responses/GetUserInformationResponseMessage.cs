using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace mtsk.Models.Responses
{
    public class GetUserInformationResponseMessage
    {
        public int success { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public int userID { get; set; }
            public string userName { get; set; }
            public string userSurname { get; set; }
            public string userEmail { get; set; }
            public string userTelephone { get; set; }
            public string userTC { get; set; }
            public string userGender { get; set; }
            public string userPassword { get; set; }
            public int userActive { get; set; }
        }
    }
}
