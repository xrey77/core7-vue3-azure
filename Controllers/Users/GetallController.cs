using Microsoft.AspNetCore.Mvc;
using core7_vue3_azure.Services;
using AutoMapper;
using core7_vue3_azure.Entities;
using core7_vue3_azure.Models.dto;
using core7_vue3_azure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace core7_vue3_azure.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GetallController : ControllerBase {
       

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<GetallController> _logger;

    public GetallController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<GetallController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpGet("/api/getallusers")]
        public IActionResult getAllusers() {
            try {
                
                var user = _userService.GetAll();
                var model = _mapper.Map<IList<UserModel>>(user);
                return Ok(model);
            } catch(AppException ex) {
               return Ok(new {statuscode = 404, Message = ex.Message});
            }
        }
    }
    
}