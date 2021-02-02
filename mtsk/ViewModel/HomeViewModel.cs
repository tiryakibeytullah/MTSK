using System;
using mtsk.Models.Requests;
using mtsk.Models.Responses;

namespace mtsk.ViewModel
{
    public class HomeViewModel
    {
        public GetUserInformationResponseMessage getUserInformationResponseMessage { get; set; }
        public AddOrderRequestMessage addOrderRequestMessage { get; set; }
        public AddOrderResponseMessage addOrderResponseMessage { get; set; }
    }
}
