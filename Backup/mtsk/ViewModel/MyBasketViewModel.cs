using System;
using mtsk.Models.Requests;
using mtsk.Models.Responses;

namespace mtsk.ViewModel
{
    public class MyBasketViewModel
    {
        public GetBasketResponseMessage getBasketResponseMessage { get; set; }
        public DeleteOrderRequestMessage deleteOrderRequestMessage { get; set; }
        public DeleteOrderResponseMessage deleteOrderResponseMessage { get; set; }
        public OrderCompleteRequestMessage orderCompleteRequestMessage { get; set; }
        public OrderCompleteResponseMessage orderCompleteResponseMessage { get; set; }
        public DeleteAllOrderResponseMessage deleteAllOrderResponseMessage { get; set; }
        public GetAllAddressResponseMessage getAllAddressResponseMessage { get; set; }
        public AddAddressRequestMessage addAddressRequestMessage { get; set; }
        public AddAddressResponseMessage addAddressResponseMessage { get; set; }
    }
}
