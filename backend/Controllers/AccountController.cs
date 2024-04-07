using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Account;
using backend.Interfaces;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;
        public AccountController(ITokenService tokenService, IUserRepository userRepository, SignInManager<User> signInManager)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _signInManager = signInManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetUserByUserNameAsync(loginRequestDto.Username);

            if (user == null)
            {
                return Unauthorized(new { message = "Username not found" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequestDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Username not found and/or password incorrect" });
            }

            return Ok(
                new LoginDto
                {
                    Token = await _tokenService.CreateToken(user)
                }
            );
        }
    }
}