using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class GemstoneShape
    {
        public Guid GemstoneShapeId { get; set; }
        public string ShapeName { get; set; }
        public decimal GemstoneShapPrice { get; set; }

        public decimal GemstoneShapWeight { get; set; }
        public string GemstoneShapeInfo { get; set; }
        public Guid GemstoneId { get; set; }
        public Gemstones Gemstone { get; set; }

        // public void CalculateFinalPrice()
        // {
        //     if (Gemstone != null)
        //     {
        //         GemstoneShapPrice += Gemstone.GemstonePrice;
        //     }
        // }
    }
}
