using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.Gemstone;
using src.Utils;
using static src.DTO.GemstonesDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GemstoneController : ControllerBase
    {
        protected readonly IGemstoneService _gemstoneService;

        public GemstoneController(IGemstoneService gemstoneService)
        {
            _gemstoneService = gemstoneService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<GemstoneListDto>>> GetAll(
            [FromQuery] PaginationOptions options
        )
        {
            var gemstonesList = await _gemstoneService.GetAllAsync(options);
            var totalCount = await _gemstoneService.CountGemstonesAsync();
            var response = new GemstoneListDto
            {
                Gemstones = gemstonesList,
                TotalCount = totalCount,
            };
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{GemstoneId}")]
        public async Task<ActionResult<GemstoneReadDto>> GetById(Guid GemstoneId)
        {
            var foundGemstone = await _gemstoneService.GetByIdAsync(GemstoneId);
            if (foundGemstone == null)
            {
                return NotFound("Gemstone not found");
            }
            return Ok(foundGemstone);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<GemstoneReadDto>> CreateOne(GemstoneCreateDto createDto)
        {
            var newGemstone = await _gemstoneService.CreateOneAsync(createDto);
            return Ok(newGemstone);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{GemstoneId}")]
        public async Task<ActionResult> UpdateOne(Guid GemstoneId, GemstoneUpdateDto updateDto)
        {
            var gemstoneUpdated = await _gemstoneService.UpdateOneAsync(GemstoneId, updateDto);
            if (gemstoneUpdated == null)
            {
                return NotFound();
            }
            return Ok(gemstoneUpdated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{GemstoneId}")]
        public async Task<ActionResult> DeleteOne(Guid GemstoneId)
        {
            var gemstoneDeleted = await _gemstoneService.DeleteOneAsync(GemstoneId);
            if (gemstoneDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("Search")]
        public async Task<ActionResult<List<GemstoneReadDto>>> GetAllJewelryBySearch(
            [FromQuery] PaginationOptions paginationOptions
        )
        {
            var gemstonesList = await _gemstoneService.GetAllBySearchAsync(paginationOptions);
            return Ok(gemstonesList);
        }
    }
}
