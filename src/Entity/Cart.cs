using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public int CartQuantity { get; set; }
        public double CartPrice { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;
        public List<Order> Orders { get; set; }

        public double CalculateTotalCartPrice()
        {
            double totalCartPrice = 0;

            foreach (var order in Orders)
            {
                foreach (var orderProduct in order.SingleProduct)
                {
                    totalCartPrice += (double)orderProduct.FinalPrice;
                }
            }

            return totalCartPrice;
        }
    }
}
