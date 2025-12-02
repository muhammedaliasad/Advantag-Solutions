using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Infrastructure.Interfaces;
using AdvAsmPlanning.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvAsmPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController(IDropdownService _dropdownService) : ControllerBase
    {

        /// <summary>
        /// Get distinct dropdown values for Account based on key
        /// </summary>
        /// <param name="key">Column name to filter distinct values</param>
        /// <returns>List of DropDownDto</returns>
        [HttpPost("GetByKey")]
        public async Task<ActionResult<IEnumerable<DropdownDto>>> GetDropdown([FromBody] string key)
            => Ok(await _dropdownService.GetAllAsync(key));
    }
}