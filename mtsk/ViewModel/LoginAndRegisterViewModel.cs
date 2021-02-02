using System;
using mtsk.Models.Requests;

namespace mtsk.ViewModel
{
    public class LoginAndRegisterViewModel
    {
        public LoginRequestMessage loginRequestMessage { get; set; }
        public RegisterRequestMessage registerRequestMessage { get; set; }
    }
}
