using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;

namespace src.DTO
{
    public class GemstoneShapeDTO
    {
        public class GemstoneShapeCreateDTO
        {
            public string ShapeName { get; set; }
            public decimal GemstoneShapPrice { get; set; }
            public string GemstoneImage { get; set; }

            public decimal GemstoneShapWeight { get; set; }
            public string GemstoneShapeInfo { get; set; }
            public Guid GemstoneId { get; set; }
        }

        public class GemstoneShapListDto
        {
            public List<GemstoneShapeReadDTO> GemstonesShape { get; set; }
            public int TotalCount { get; set; }
        }

        public class GemstoneShapeReadDTO
        {
            public Guid GemstoneShapeId { get; set; }
            public string ShapeName { get; set; }
            public string GemstoneImage { get; set; }

            public decimal GemstoneShapPrice { get; set; }
            public decimal GemstoneShapWeight { get; set; }
            public string GemstoneShapeInfo { get; set; }
            public Guid GemstoneId { get; set; }
        }

        public class GemstoneShapeUpdateDto
        {
            public string? ShapeName { get; set; }
            public string? GemstoneImage { get; set; }
            public decimal? GemstoneShapPrice { get; set; }
            public decimal? GemstoneShapWeight { get; set; }
            public string? GemstoneShapeInfo { get; set; }
            public Guid? GemstoneId { get; set; }
        }
    }
}
