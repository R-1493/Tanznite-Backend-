using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.GemstoneShapeDTO;
using static src.DTO.JewelryDTO;

namespace src.DTO
{
    public class SingleProductDTO
    {
        public class SingleProductCreateDto
        {
            public Guid JewelryId { get; set; }
            public Guid GemstoneShapeId { get; set; }
            public int Quantity { get; set; }
        }

        public class SingleProductReadDto
        {
            public Guid SingleProductId { get; set; }
            public decimal FinalPrice { get; set; }
            public JewelryReadDto Jewelry { get; set; }
            public GemstoneShapeReadDTO GemstoneShape { get; set; }
        }

        public class SingleProductUpdateDto
        {
            public decimal FinalPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}
