using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.Jewelry;
using static src.DTO.JewelryDTO;

namespace src.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]//api/v1/Jewelry
    public class JewelryController : ControllerBase
    {

        /// <summary>
        /// The point of the JewelryController file is to handle HTTP requests related to jewelry items in the application.
        /// It defines endpoints for creating, reading, updating, and deleting jewelry items.
        /// 1- Creating a new jewelry item.
        /// 2- Retrieving a list of all jewelry items.
        /// 3- Updating jewelry item information such as name, type, price, image, and description.
        /// 4- Deleting a jewelry item.
        /// </summary>
        protected readonly IJewelryService _jewelryService;

        public JewelryController(IJewelryService jewelryService)
        {
            _jewelryService = jewelryService;
        }

        // POST: api/v1/Jewelry
        // Create a new jewelry item
        /// <API>
        /// {
        ///  "jewelryName": " ",
        ///   "jewelryType": " ",
        ///   "jewelryPrice": ,
        ///   "jewelryImage": " ",
        ///   "description": " ",
        ///  "gemstoneId": " ",
        ///  "carvingId": " ",
        ///  "userId": " "
        ///}
        /// <API>
        /// return jewelry info 
        [HttpPost]
        [Authorize(Roles = "Admin")] //--> Just the Admin Can Create New Jewelry
        public async Task<ActionResult<JewelryReadDto>> CreateOne(JewelryCreateDto createDto)
        {
            var nweJewelry = await _jewelryService.CreateOneAsync(createDto);
            return Ok(nweJewelry);//200 Ok
        }

        // GET: api/v1/Jewelry
        // Get all jewelry items
        [HttpGet]
        public async Task<ActionResult<List<JewelryReadDto>>> GetAll()
        {
            var jewelryList = await _jewelryService.GetAllAsync();
            return Ok(jewelryList); //200 OK
        }

        // GET: api/v1/Jewelry/{JewelryId}
        // Get a jewelry item by its ID
        [HttpGet("{JewelryId}")]
        public async Task<ActionResult<JewelryReadDto>> GetById(Guid JewelryId)
        {
            var foundJewelry = await _jewelryService.GetByIdAsync(JewelryId);
            if (foundJewelry == null)
            {
                return NotFound("Jewelry item not found"); //400 Not Found
            }
            return Ok(foundJewelry); //200 Ok
        }

        // PUT: api/v1/jewelry/{JewelryId}
        // Update a jewelry item
        /// <API>
        /// {
        ///   "jewelryName": " ",
        ///   "jewelryType": " ",
        ///   "jewelryPrice": ,
        ///   "jewelryImage": " ",
        ///   "description": " "
        /// }
        /// <API>
        [HttpPut("{JewelryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<JewelryReadDto>> UpdateOne(Guid JewelryId, JewelryUpdateDto updateDto)
        {
            var jewelryUpdate = await _jewelryService.UpdateOneAsync(JewelryId, updateDto);
            if (jewelryUpdate == null)
            {
                return NotFound("Jewelry item not found"); //400  Not Found
            }
            return Ok(jewelryUpdate); //200 OK
        }

        // DELETE: api/v1/Jewelry/{JewelryId}
        // Delete a jewelry item by its ID
        [HttpDelete("{JewelryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteOne(Guid JewelryId)
        {
            var jewelryDeleted = await _jewelryService.DeleteOneAsync(JewelryId);
            if (jewelryDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }
    }
}