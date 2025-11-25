using Microsoft.AspNetCore.Mvc;
using ResultFlow.Core.Common;
using ResultFlow.Core.Service;

namespace ResultFlow.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUserAsync(id);

            if (result.Success)
                return Ok(result.Data);

            return result.ErrorCode switch
            {
                ErrorCode.NotFound => NotFound(result.ErrorMessage),
                ErrorCode.Validation => BadRequest(result.ErrorMessage),
                ErrorCode.Conflict => Conflict(result.ErrorMessage),
                ErrorCode.BusinessRule => BadRequest(result.ErrorMessage),
                _ => StatusCode(500, result.ErrorMessage)
            };
        }
    }
}
