using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.Constants;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvAsmPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController(IDropdownService dropdownService) : ControllerBase
    {
        /// <summary>
        /// Get distinct dropdown values for Account based on key.
        /// </summary>
        /// <param name="key">Dropdown key (one of the enum values)</param>
        /// <returns>ApiResponseDto containing list of DropdownResponseDto</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseDto<IEnumerable<DropdownResponseDto>>), 200)]
        public async Task<IActionResult> GetDropdown([FromQuery] DropdownKey key)
        {
            var result = await dropdownService.GetAllAsync(key);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}