using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Utils;
using static src.DTO.GemstoneShapeDTO;

namespace src.Services.GemstoneShape
{
    public interface IGemstoneShapeService
    {
        Task<GemstoneShapeReadDTO> CreateOneAsync(GemstoneShapeCreateDTO createDto);

        Task<List<GemstoneShapeReadDTO>> GetAllAsync(PaginationOptions Options);

        // Task<GemstoneShapeReadDTO> GetByIdAsync(Guid id);
        Task<int> CountGemstonesShapAsync();

        Task<List<GemstoneShapeReadDTO>> GetAllAsync();
    }
}
