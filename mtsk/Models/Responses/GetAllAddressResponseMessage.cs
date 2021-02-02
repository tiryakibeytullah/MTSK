using System;
using System.Collections.Generic;

namespace mtsk.Models.Responses
{
    public class GetAllAddressResponseMessage
    {
        public int success { get; set; }
        public Data data { get; set; }
    }

    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }

    public class District
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int CityID { get; set; }
    }

    public class Data
    {
        public List<City> cities { get; set; }
        public List<District> districts { get; set; }
    }
}
