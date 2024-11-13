using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class GemstoneShape
    {
        [Key]
        public Guid GemstoneShapeId { get; set; }
        public string ShapeName { get; set; }
        public decimal GemstoneShapPrice { get; set; }
        public string GemstoneImage { get; set; }
        public decimal GemstoneShapWeight { get; set; }
        public string GemstoneShapeInfo { get; set; }
        public Guid GemstoneId { get; set; }
        public Gemstones Gemstone { get; set; }
    }
}
