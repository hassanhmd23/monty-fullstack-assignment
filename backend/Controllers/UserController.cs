using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using backend.Dtos.User;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users.Select(user => user.ToUserDto()));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> GetUserByEmail([FromRoute] string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserRequestDto createRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = createRequestDto.ToUserFromCreateDto();

            await _userRepository.CreateUserAsync(user, createRequestDto.Password, createRequestDto.Role);

            return CreatedAtAction(nameof(GetById), new { userId = user.Id }, user.ToUserDto());

        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDto>> Update([FromRoute] string userId, [FromBody] UpdateUserRequestDto updateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ((await _userRepository.ValidateEmail(userId, updateRequestDto.Email)) == HttpStatusCode.Conflict)
            {
                return Conflict();
            }

            if ((await _userRepository.ValidateUserName(userId, updateRequestDto.UserName)) == HttpStatusCode.Conflict)
            {
                return Conflict();
            }

            var user = await _userRepository.UpdateUserAsync(userId, updateRequestDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.DeleteUserAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}