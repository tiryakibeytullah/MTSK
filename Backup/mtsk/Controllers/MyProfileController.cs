using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mtsk.Models.Requests;
using mtsk.Models.Responses;
using mtsk.ViewModel;
using Newtonsoft.Json;

namespace mtsk.Controllers
{
    public class MyProfileController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var getPastOrderUrl = "https://mtsk-proje.herokuapp.com/api/order/";
                var getUserInformationUrl = "https://mtsk-proje.herokuapp.com/api/users/";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var getUserInformationResponse = client.GetStringAsync(getUserInformationUrl);
                var getPastOrderResponse = client.GetStringAsync(getPastOrderUrl);
                MyProfileViewModel message = new MyProfileViewModel();
                message.getPastOrderResponseMessage = JsonConvert.DeserializeObject<GetPastOrderResponseMessage>(getPastOrderResponse.Result);
                message.getUserInformationResponseMessage = JsonConvert.DeserializeObject<GetUserInformationResponseMessage>(getUserInformationResponse.Result);
                return View(message);
            }
        }

        [HttpPost]
        public ActionResult Index(MyProfileViewModel myProfileViewModel)
        {
            myProfileViewModel.updateUserInformationRequestMessage.userName = myProfileViewModel.getUserInformationResponseMessage.data.userName;
            myProfileViewModel.updateUserInformationRequestMessage.userSurname = myProfileViewModel.getUserInformationResponseMessage.data.userSurname;
            myProfileViewModel.updateUserInformationRequestMessage.userEmail = myProfileViewModel.getUserInformationResponseMessage.data.userEmail;
            myProfileViewModel.updateUserInformationRequestMessage.userTelephone = myProfileViewModel.getUserInformationResponseMessage.data.userTelephone;
            myProfileViewModel.updateUserInformationRequestMessage.userTC = myProfileViewModel.getUserInformationResponseMessage.data.userTC;
            myProfileViewModel.updateUserInformationRequestMessage.userActive = myProfileViewModel.getUserInformationResponseMessage.data.userActive;
            myProfileViewModel.updateUserInformationRequestMessage.userGender = myProfileViewModel.getUserInformationResponseMessage.data.userGender;

            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/users/update";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.PostAsJsonAsync(url, myProfileViewModel.updateUserInformationRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                UpdateUserInformationResponseMessage message = new UpdateUserInformationResponseMessage();
                message = JsonConvert.DeserializeObject<UpdateUserInformationResponseMessage>(responseString.Result);
                return RedirectToAction("Index", "MyProfile");
            }
        }

        [HttpGet]
        public ActionResult DeleteUser(int userID)
        {
            DeleteUserAccountRequestMessage deleteUserAccountRequestMessage = new DeleteUserAccountRequestMessage();
            deleteUserAccountRequestMessage.userID = userID;
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/users/deleteMe";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.PostAsJsonAsync(url, deleteUserAccountRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                DeleteUserAccountResponseMessage message = new DeleteUserAccountResponseMessage();
                message = JsonConvert.DeserializeObject<DeleteUserAccountResponseMessage>(responseString.Result);
                Session.Remove("token");
                Session.Remove("name");
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult SessionRemove()
        {
            if (Session["token"] != null)
            {
                Session.Remove("token");
                Session.Remove("name");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
