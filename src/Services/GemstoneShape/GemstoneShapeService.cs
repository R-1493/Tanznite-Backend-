using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.DTO;
using src.Repository;
using src.Services.GemstoneShape;
using src.Utils;
using static src.DTO.GemstoneShapeDTO;

namespace Services.GemstoneShape
{
    public class GemstoneShapeService : IGemstoneShapeService
    {
        private readonly GemstoneShapeRepository _gemstonesShapeRepo;
        protected readonly IMapper _mapper;

        public GemstoneShapeService(GemstoneShapeRepository gemstoneShapeRepository, IMapper mapper)
        {
            _gemstonesShapeRepo = gemstoneShapeRepository;
            _mapper = mapper;
        }

        public async Task<GemstoneShapeReadDTO> CreateOneAsync(GemstoneShapeCreateDTO createDto)
        {
            var GemstoneItem = _mapper.Map<GemstoneShapeCreateDTO, src.Entity.GemstoneShape>(
                createDto
            );
            var createdGemstone = await _gemstonesShapeRepo.CreateOnAsync(GemstoneItem);
            return _mapper.Map<src.Entity.GemstoneShape, GemstoneShapeReadDTO>(createdGemstone);
        }

        public async Task<int> CountGemstonesShapAsync()
        {
            return await _gemstonesShapeRepo.CountAsync();
        }

        public async Task<List<GemstoneShapeReadDTO>> GetAllAsync(PaginationOptions Options)
        {
            var gemstonesSahpe = await _gemstonesShapeRepo.GetAllAsync(Options);
            return _mapper.Map<List<src.Entity.GemstoneShape>, List<GemstoneShapeReadDTO>>(
                gemstonesSahpe
            );
        }

        public async Task<List<GemstoneShapeReadDTO>> GetAllAsync()
        {
            var gemstonesSahpeList = await _gemstonesShapeRepo.GetAllAsync();
            return _mapper.Map<List<src.Entity.GemstoneShape>, List<GemstoneShapeReadDTO>>(
                gemstonesSahpeList
            );
        }
    }
}
