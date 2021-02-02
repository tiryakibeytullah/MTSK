using System;
namespace mtsk.Models.Requests
{
    public class UpdateUserInformationRequestMessage
    {
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userEmail { get; set; }
        public string userTelephone { get; set; }
        public string userTC { get; set; }
        public string userPassword { get; set; }
        public int userActive { get; set; }
        public string userGender { get; set; }
    }
}
