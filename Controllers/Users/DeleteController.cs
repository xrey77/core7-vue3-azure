using AutoMapper;
using core7_vue3_azure.Helpers;
using core7_vue3_azure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace core7_vue3_azure.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DeleteController : ControllerBase {

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<DeleteController> _logger;

    public DeleteController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<DeleteController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpDelete("/api/deleteuser/{id}")]
        public IActionResult deleteUser(int id) {
            try
            {
               _userService.Delete(id);
            return Ok();
           }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}