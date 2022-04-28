using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository shopRepository;

        public ShopController(IShopRepository shopRepository)
        {
            this.shopRepository = shopRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Shop>> CreateShop(Shop shop)
        {
            try
            {
                if (shop == null)
                    return BadRequest();

                var existingShop = await shopRepository.GetShopByName(shop.Name);

                if (existingShop != null)
                {
                    ModelState.AddModelError("Name", "Shop name already in use");
                    return BadRequest(ModelState);
                }

                var createdShop = await shopRepository.AddShop(shop);

                return CreatedAtAction(nameof(GetShop), new { id = createdShop.Id }, createdShop);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            try
            {
                var result = await shopRepository.GetShop(id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
