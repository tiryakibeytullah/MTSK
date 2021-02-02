using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mtsk.Models.Requests;
using mtsk.Models.Responses;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;
using mtsk.ViewModel;

namespace mtsk.Controllers
{
    public class LoginController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginAndRegisterViewModel loginAndRegisterViewModel)
        {
            if (loginAndRegisterViewModel.loginRequestMessage != null)
            {
                var response = client.PostAsJsonAsync("https://mtsk-proje.herokuapp.com/api/users/login", loginAndRegisterViewModel.loginRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                LoginResponseMessage message = new LoginResponseMessage();
                message = JsonConvert.DeserializeObject<LoginResponseMessage>(responseString.Result);
                if (message.Success == 1)
                {
                    Session["token"] = message.Token;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.alert = "danger";
                    ViewBag.result = "Kullanıcı adı veya şifre hatalı!";
                    return View();
                }
            }
            else
            {
                var response = client.PostAsJsonAsync("https://mtsk-proje.herokuapp.com/api/users", loginAndRegisterViewModel.registerRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                RegisterResponseMessage message = new RegisterResponseMessage();
                message = JsonConvert.DeserializeObject<RegisterResponseMessage>(responseString.Result);
                if (message.success == 1)
                {
                    ViewBag.alert = "success";
                    ViewBag.result = "Kayıt başarılı!";
                    return View();
                }
                else
                {
                    ViewBag.alert = "danger";
                    ViewBag.result = "Kayıt yapılamadı!";
                    return View();
                }
            }
            
        }
    }
}
/*
            LoginRequestMessage requestMessage = new LoginRequestMessage();
            requestMessage.UserEmail = "mertguven789@gmail.com";
            requestMessage.UserPassword = "123456789";

            var response = client.PostAsJsonAsync("https://mtsk-proje.herokuapp.com/api/users/login", requestMessage);
            response.Wait();
            var q = response.Result;
            var responseString = q.Content.ReadAsStringAsync();
            LoginResponseMessage message = new LoginResponseMessage();
            message = JsonConvert.DeserializeObject<LoginResponseMessage>(responseString.Result);
            Console.WriteLine(message.Message);
*/