using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.DTO;
using src.Repository;
using src.Services.GemstoneShape;
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

        public Task<GemstoneShapeReadDTO> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
