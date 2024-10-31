using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DTO;
using src.Services.GemstoneShape;
using static src.DTO.GemstoneShapeDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GemstoneShapeController : ControllerBase
    {
        protected readonly IGemstoneShapeService _gemstoneShapeService;

        public GemstoneShapeController(IGemstoneShapeService gemstoneShapeService)
        {
            _gemstoneShapeService = gemstoneShapeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<GemstoneShapeReadDTO>>> GetAll()
        {
            var gemstonesList = await _gemstoneShapeService.GetAllAsync();
            return Ok(gemstonesList);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<GemstoneShapeReadDTO>> CreateOne(GemstoneShapeCreateDTO createDto)
        {
            var newGemstone = await _gemstoneShapeService.CreateOneAsync(createDto);
            return Ok(newGemstone);
        }
    }
}
