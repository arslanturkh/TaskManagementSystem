using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.bl;
using TaskManagementApp.DTO;
using TaskManagementApp.DTOs;
using TaskManagementApp.Helpers;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserBL _userBL;

        public UsersController(UserBL userBL)
        {
            _userBL = userBL;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {
            var users = await _userBL.GetAllUsersAsync();

            // Map Users to UserReadDto
            var userDtos = users.Select(user => new UserReadDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email
            });

            return Ok(userDtos);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            var user = await _userBL.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserReadDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email
            };

            return Ok(userDto);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> PostUser(UserCreateDto userCreateDto)
        {
            // Hash the password
            var hashedPassword = PasswordHasher.HashPassword(userCreateDto.Password);

            var user = new User
            {
                Username = userCreateDto.Username,
                PasswordHash = hashedPassword,
                Email = userCreateDto.Email
            };

            await _userBL.AddUserAsync(user);

            var userReadDto = new UserReadDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, userReadDto);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserCreateDto userUpdateDto)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            var existingUser = await _userBL.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update user properties
            existingUser.Username = userUpdateDto.Username;
            existingUser.Email = userUpdateDto.Email;

            // Hash the new password if provided
            if (!string.IsNullOrEmpty(userUpdateDto.Password))
            {
                existingUser.PasswordHash = PasswordHasher.HashPassword(userUpdateDto.Password);
            }

            await _userBL.UpdateUserAsync(existingUser);

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userBL.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userBL.DeleteUserAsync(user);

            return NoContent();
        }
    }
}
