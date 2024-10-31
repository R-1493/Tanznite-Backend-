using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.GemstoneShapeDTO;

namespace src.Services.GemstoneShape
{
    public interface IGemstoneShapeService
    {
        Task<GemstoneShapeReadDTO> CreateOneAsync(GemstoneShapeCreateDTO createDto);

        Task<GemstoneShapeReadDTO> GetAllAsync();

        // Task<GemstoneShapeReadDTO> GetByIdAsync(Guid id);
    }
}
