using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.User;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users.Select(user => user.ToUserDto()));
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<User>> GetById([FromRoute] int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpGet("email/{email:string}")]
        public async Task<ActionResult<User>> GetUserByEmail([FromRoute] string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }


        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserRequestDto createRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = createRequestDto.ToUserFromCreateDto();

            await _userRepository.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetById), new { userId = user.Id }, user.ToUserDto());

        }

        [HttpPut("{userId:int}")]
        public async Task<ActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserRequestDto updateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.UpdateUserAsync(userId, updateRequestDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> Delete([FromRoute] int userId)
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