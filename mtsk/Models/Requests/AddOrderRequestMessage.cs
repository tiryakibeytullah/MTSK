using System;
namespace mtsk.Models.Requests
{
    public class AddOrderRequestMessage
    {
        public int torderPiece { get; set; }
        public int torderPrice { get; set; }
        public int torderCase { get; set; }
    }
}
