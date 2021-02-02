using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mtsk.Models.Responses;
using mtsk.ViewModel;
using Newtonsoft.Json;

namespace mtsk.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/users/";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.GetStringAsync(url);
                HomeViewModel message = new HomeViewModel();
                message.getUserInformationResponseMessage = JsonConvert.DeserializeObject<GetUserInformationResponseMessage>(response.Result);
                if (Session["token"] != null)
                {
                    Session["name"] = message.getUserInformationResponseMessage.data.userName;
                }
                return View(message);
            }
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel homeViewModel)
        {
            homeViewModel.addOrderRequestMessage.torderPrice = homeViewModel.addOrderRequestMessage.torderPiece * 5;
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/temporder";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.PostAsJsonAsync(url, homeViewModel.addOrderRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                HomeViewModel message = new HomeViewModel();
                message.addOrderResponseMessage = JsonConvert.DeserializeObject<AddOrderResponseMessage>(responseString.Result);
                Console.WriteLine(message.addOrderResponseMessage.data.torderPiece);
                return RedirectToAction("Index", "MyBasket");
            }
        }
    }
}
