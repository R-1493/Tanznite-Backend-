using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entity
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AddressId { get; set; }

        public List<SingleProduct> SingleProduct { get; set; }

        public Guid? PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;
    }
}
