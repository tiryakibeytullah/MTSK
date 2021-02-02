using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using mtsk.Models.Requests;
using mtsk.Models.Responses;
using mtsk.ViewModel;
using Newtonsoft.Json;

namespace mtsk.Controllers
{
    public class MyBasketController : Controller
    {
        public int tPrice { get; set; }
        public int tPiece { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var addressUrl = "https://mtsk-proje.herokuapp.com/api/temporder/getaddress";
                var url = "https://mtsk-proje.herokuapp.com/api/temporder/";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.GetStringAsync(url);
                var addressResponse = client.GetStringAsync(addressUrl);
                MyBasketViewModel message = new MyBasketViewModel();
                message.getAllAddressResponseMessage = JsonConvert.DeserializeObject<GetAllAddressResponseMessage>(addressResponse.Result);
                message.getBasketResponseMessage = JsonConvert.DeserializeObject<GetBasketResponseMessage>(response.Result);
                ViewBag.totalPrice = 0;
                ViewBag.totalPiece = 0;
                foreach (var item in message.getBasketResponseMessage.data.siparisData)
                {
                    tPrice += item.TEMPORDERPRICE;
                    tPiece += item.TEMPORDERPIECE;
                    ViewBag.totalPrice += item.TEMPORDERPRICE;
                    ViewBag.totalPiece += item.TEMPORDERPIECE;
                }
                Session["totalPrice"] = tPrice.ToString();
                Session["totalPiece"] = tPiece.ToString();
                return View(message);
            }
        }

        [HttpGet]
        public ActionResult Delete(int deleteId)
        {
            DeleteOrderRequestMessage deleteOrderRequestMessage = new DeleteOrderRequestMessage();
            deleteOrderRequestMessage.tOrderID = deleteId;
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/temporder/delete";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.PostAsJsonAsync(url, deleteOrderRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                MyBasketViewModel message = new MyBasketViewModel();
                message.deleteOrderResponseMessage = JsonConvert.DeserializeObject<DeleteOrderResponseMessage>(responseString.Result);
                Console.WriteLine(message.deleteOrderResponseMessage.success);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddAddress(MyBasketViewModel myBasketViewModel)
        {
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/temporder/ADDress";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.PostAsJsonAsync(url, myBasketViewModel.addAddressRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                MyBasketViewModel message = new MyBasketViewModel();
                message.addAddressResponseMessage = JsonConvert.DeserializeObject<AddAddressResponseMessage>(responseString.Result);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult OrderComplete(MyBasketViewModel myBasketViewModel)
        {
            myBasketViewModel.orderCompleteRequestMessage.orderPiece = Session["totalPiece"].ToString();
            myBasketViewModel.orderCompleteRequestMessage.orderTotalPrice = Session["totalPrice"].ToString();
            using (var client = new HttpClient())
            {
                var url = "https://mtsk-proje.herokuapp.com/api/order/addOrder";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"]);
                var response = client.PostAsJsonAsync(url, myBasketViewModel.orderCompleteRequestMessage);
                response.Wait();
                var q = response.Result;
                var responseString = q.Content.ReadAsStringAsync();
                MyBasketViewModel message = new MyBasketViewModel();
                message.orderCompleteResponseMessage = JsonConvert.DeserializeObject<OrderCompleteResponseMessage>(responseString.Result);
                if (message.orderCompleteResponseMessage.success == 1)
                {
                    var deleteUrl = "https://mtsk-proje.herokuapp.com/api/temporder/clear";
                    var deleteResponse = client.GetStringAsync(deleteUrl);
                    MyBasketViewModel deleteMessage = new MyBasketViewModel();
                    deleteMessage.deleteAllOrderResponseMessage = JsonConvert.DeserializeObject<DeleteAllOrderResponseMessage>(deleteResponse.Result);
                    
                }
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
