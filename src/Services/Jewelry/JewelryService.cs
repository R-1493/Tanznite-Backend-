using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using src.Utils;
using static src.DTO.JewelryDTO;

namespace src.Services.Jewelry
{
    public class JewelryService : IJewelryService
    {
        private readonly JewelryRepository _jewelryRepo;
        protected readonly IMapper _mapper;

        public JewelryService(JewelryRepository jewelryRepo, IMapper mapper)
        {
            _jewelryRepo = jewelryRepo;
            _mapper = mapper;
        }

        public async Task<JewelryReadDto> CreateOneAsync(JewelryCreateDto createDto)
        {
            var JewelryItem = _mapper.Map<JewelryCreateDto, src.Entity.Jewelry>(createDto);
            var createdJewelry = await _jewelryRepo.CreateOneAsync(JewelryItem);
            return _mapper.Map<src.Entity.Jewelry, JewelryReadDto>(createdJewelry);
        }

        public async Task<List<JewelryReadDto>> GetAllAsync(PaginationOptions Options)
        {
            var jewelryItems = await _jewelryRepo.GetAllAsync(Options);
            return _mapper.Map<List<src.Entity.Jewelry>, List<JewelryReadDto>>(jewelryItems);
        }

        public async Task<List<JewelryReadDto>> GetAllAsync()
        {
            var jewelryList = await _jewelryRepo.GetAllAsync();
            return _mapper.Map<List<src.Entity.Jewelry>, List<JewelryReadDto>>(jewelryList);
        }

        public async Task<int> CountJewelryAsync()
        {
            return await _jewelryRepo.CountAsync();
        }

        public async Task<JewelryReadDto> GetByIdAsync(Guid JewelryId)
        {
            var foundJewelry = await _jewelryRepo.GetByIdAsync(JewelryId);

            if (foundJewelry == null)
            {
                throw CustomException.NotFound($"category with {JewelryId} cant find");
            }

            return _mapper.Map<src.Entity.Jewelry, JewelryReadDto>(foundJewelry);
        }

        public async Task<bool> UpdateOneAsync(Guid JewelryId, JewelryUpdateDto updateDto)
        {
            var foundJewelry = await _jewelryRepo.GetByIdAsync(JewelryId);

            if (foundJewelry == null)
            {
                throw CustomException.NotFound($"Jewelry with ID {JewelryId} not found for update");
            }

            _mapper.Map(updateDto, foundJewelry);

            bool isUpdated = await _jewelryRepo.UpdateOnAsync(foundJewelry);
            return isUpdated;
        }

        public async Task<bool> DeleteOneAsync(Guid JewelryId)
        {
            var foundJewelry = await _jewelryRepo.GetByIdAsync(JewelryId);
            if (foundJewelry == null)
            {
                throw CustomException.NotFound(
                    $"Jewelry with ID {JewelryId} not found for deletion"
                );
            }
            bool isDeleted = await _jewelryRepo.DeleteOnAsync(foundJewelry);
            return isDeleted;
        }

        public async Task<List<JewelryReadDto>> GetAllBySearchAsync(
            PaginationOptions paginationOptions
        )
        {
            var jewelryList = await _jewelryRepo.GetAllBySearch(paginationOptions);
            if (jewelryList.Count == 0)
            {
                throw CustomException.NotFound($"No results found");
            }
            return _mapper.Map<List<src.Entity.Jewelry>, List<JewelryReadDto>>(jewelryList);
        }

        public async Task<List<JewelryReadDto>> GetAllByFilterationAsync(
            FilterationOptions jewelryFilter,
            PaginationOptions paginationOptions
        )
        {
            var jewelryList = await _jewelryRepo.GetAllByFilteringAsync(
                jewelryFilter,
                paginationOptions
            );

            // Sorting logic based on SortBy and IsAscending from jewelryFilter
            if (!string.IsNullOrEmpty(jewelryFilter.SortBy))
            {
                jewelryList = jewelryFilter.IsAscending
                    ? jewelryList.OrderBy(j => GetSortValue(j, jewelryFilter.SortBy)).ToList()
                    : jewelryList
                        .OrderByDescending(j => GetSortValue(j, jewelryFilter.SortBy))
                        .ToList();
            }

            // Pagination logic using Limit and Offset from paginationOptions
            jewelryList = jewelryList
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToList();

            return _mapper.Map<List<src.Entity.Jewelry>, List<JewelryReadDto>>(jewelryList);
        }

        private object GetSortValue(src.Entity.Jewelry jewelry, string sortBy)
        {
            return sortBy switch
            {
                "Price" => jewelry.JewelryPrice,
                "Name" => jewelry.JewelryName,
                "Type" => jewelry.JewelryType,
                _ => jewelry.JewelryType,
            };
        }
    }
}
