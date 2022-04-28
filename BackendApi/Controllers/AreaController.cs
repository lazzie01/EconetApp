using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository areaRepository;

        public AreaController(IAreaRepository areaRepository)
        {
            this.areaRepository = areaRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Shop>>> Search(string name)
        {
            try
            {
                var result = await areaRepository.Search(name);

                if (result.Any())
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
