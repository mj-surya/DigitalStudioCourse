using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BackEnd.Interfaces;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/controller")]
    [ApiController]
    [EnableCors("reactApp")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService){
            _userService=userService;
        }
        [HttpPost("login")]
        public ActionResult Login(User entity){
            var result = _userService.Login(entity);
            if(result!=null){
                return Ok(result);
            }
            return BadRequest("Invalid Username or password");
        }
        [HttpPost("register")]
        public ActionResult Register(User entity){
            var result = _userService.Register(entity);
            if(result!=null){
                return Ok(result);
            }
            return BadRequest("Could not register user");
        }
        
    }
}