using System;
namespace ApiRestTest.Models
{
    public class Compra
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int ProductCuantity { get; set; }

        public DateTime BuyDate { get; set; }
    }
}

