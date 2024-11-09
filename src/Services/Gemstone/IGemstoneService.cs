using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Utils;
using static src.DTO.GemstonesDTO;

namespace src.Services.Gemstone
{
    public interface IGemstoneService
    {
        Task<GemstoneReadDto> CreateOneAsync(GemstoneCreateDto createDto);
        Task<List<GemstoneReadDto>> GetAllAsync(PaginationOptions Options);
        Task<GemstoneReadDto> GetByIdAsync(Guid GemstoneId);
        Task<bool> DeleteOneAsync(Guid GemstoneId);
        Task<bool> UpdateOneAsync(Guid GemstoneId, GemstoneUpdateDto updateDto);
        Task<int> CountGemstonesAsync();
        Task<List<GemstoneReadDto>> GetAllBySearchAsync(PaginationOptions paginationOptions); //jewelry Search with pagination
    }
}
