using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Utils;
using static src.DTO.JewelryDTO;

namespace src.Services.Jewelry
{
    public interface IJewelryService
    {
        Task<JewelryReadDto> CreateOneAsync(JewelryCreateDto createDto);
        Task<List<JewelryReadDto>> GetAllAsync(PaginationOptions Options);
        Task<JewelryReadDto> GetByIdAsync(Guid JewelryId);
        Task<bool> UpdateOneAsync(Guid JewelryId, JewelryUpdateDto updateDto);
        Task<bool> DeleteOneAsync(Guid JewelryId);
        Task<List<JewelryReadDto>> GetAllBySearchAsync(PaginationOptions paginationOptions);
        Task<List<JewelryReadDto>> GetAllAsync();
        Task<List<JewelryReadDto>> GetAllByFilterationAsync(
            FilterationOptions jewelryFilter,
            PaginationOptions paginationOptions
        );
        Task<int> CountJewelryAsync();
    }
}
