using System;
using mtsk.Models.Requests;
using mtsk.Models.Responses;

namespace mtsk.ViewModel
{
    public class MyProfileViewModel
    {
        public GetUserInformationResponseMessage getUserInformationResponseMessage { get; set; }
        public GetPastOrderResponseMessage getPastOrderResponseMessage { get; set; }
        public UpdateUserInformationRequestMessage updateUserInformationRequestMessage { get; set; }
    }
}
