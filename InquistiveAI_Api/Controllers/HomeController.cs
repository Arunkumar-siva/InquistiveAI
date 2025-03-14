﻿using InquistiveAI_Library.DTO;
using InquistiveAI_Library.Exceptions;
using InquistiveAI_Library.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InquistiveAI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            this._homeRepository = homeRepository;
        }
        

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var response = await _homeRepository.CheckUserCredentials(loginDto);
                return Ok(response); 
            }
            catch (InvalidCredentialsException exception) 
            {
                return Unauthorized(new
                {
                    Message = exception.Message, 
                    ErrorCode = "INVALID CREDENTIALS"
                });
            }
            catch (Exception exception)
            {
                return StatusCode(500, new
                {
                    Message = "An unexpected error occurred.",
                    Error = exception.Message 
                });
            }
        }

    }
}
