using System;
namespace ApiRestTest.Models
{
    public class ComprasPorUsuario
    {
        public int id { get; set; }

        public string ProductName { get; set; }

        public int ProductCuantity { get; set; }

        public DateTime BuyDate { get; set; }
    }
}

