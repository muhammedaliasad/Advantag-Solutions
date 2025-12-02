using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Infrastructure.Interfaces;
using AdvAsmPlanning.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvAsmPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService _accountService) : ControllerBase
    {

        /// <summary>
        /// Get distinct dropdown values for Account based on key
        /// </summary>
        /// <param name="key">Column name to filter distinct values (e.g., "c_AccountSubgroup")</param>
        /// <returns>List of DropDownDto</returns>
        [HttpPost("dropdown")]
        public async Task<ActionResult<IEnumerable<DropdownDto>>> GetDropdown([FromBody] string key)
            => Ok(await _accountService.GetAllAsync(key));
    }
}