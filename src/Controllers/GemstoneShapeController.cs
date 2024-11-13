using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DTO;
using src.Services.GemstoneShape;
using src.Utils;
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
        public async Task<ActionResult<List<GemstoneShapeReadDTO>>> GetAll(
            [FromQuery] PaginationOptions options
        )
        {
            var gemstonesShapeList = await _gemstoneShapeService.GetAllAsync(options);
            var totalCount = await _gemstoneShapeService.CountGemstonesShapAsync();
            var response = new GemstoneShapListDto
            {
                GemstonesShape = gemstonesShapeList,
                TotalCount = totalCount,
            };
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<GemstoneShapeReadDTO>> CreateOne(
            GemstoneShapeCreateDTO createDto
        )
        {
            var newGemstone = await _gemstoneShapeService.CreateOneAsync(createDto);
            return Ok(newGemstone);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{gemstoneShapeId}")]
        public async Task<ActionResult> UpdateOne(
            Guid gemstoneShapeId,
            GemstoneShapeUpdateDto updateDto
        )
        {
            var gemstoneUpdated = await _gemstoneShapeService.UpdateOneAsync(
                gemstoneShapeId,
                updateDto
            );
            if (gemstoneUpdated == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{gemstoneShapeId}")]
        public async Task<ActionResult> DeleteOne(Guid gemstoneShapeId)
        {
            var gemstoneShapeDeleted = await _gemstoneShapeService.DeleteOneAsync(gemstoneShapeId);
            if (gemstoneShapeDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
