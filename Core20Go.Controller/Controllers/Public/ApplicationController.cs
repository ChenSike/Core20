using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core20Go.Controller.Controllers.Public
{
    [Route("public/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet("Welcome")]
        public IActionResult Action_Welecome()
        {
            DTO.Public.DTO_Welcome dTO_Welcome = new DTO.Public.DTO_Welcome();
            dTO_Welcome.message = "Welcome to using Core20Go apis.Instance is running.";
            return Ok(dTO_Welcome);
        }              
       
    }
}