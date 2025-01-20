using Library.Application.DTOs.User;
using Library.Application.Services.Implementations;
using Library.Application.Services.Interfaces;
using Library.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel model)
        {
            var userId = _userService.Create(model);

            return CreatedAtAction(nameof(GetById), new { id = userId }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserInputModel model)
        {
            _userService.Update(model);

            return NoContent();
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel model)
        {
            _userService.Login(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);

            return Ok();
        }
    }
}
