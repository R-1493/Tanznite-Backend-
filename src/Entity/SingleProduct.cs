using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class SingleProduct
    {
        [Key]
        public Guid SingleProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal FinalPrice { get; set; }
        public int Quantity { get; set; }
        public Guid JewelryId { get; set; }
        public Jewelry Jewelry { get; set; }
        public Guid GemstoneShapeId { get; set; }
        public GemstoneShape GemstoneShape { get; set; }

        public void CalculateFinalPrice()
        {
            if (Jewelry != null && GemstoneShape != null)
            {
                FinalPrice = (Jewelry.JewelryPrice + GemstoneShape.GemstoneShapPrice) * Quantity;
            }
        }
    }
}
