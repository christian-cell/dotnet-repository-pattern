using Microsoft.AspNetCore.Mvc;
using UsersServices.Services;
using UsersModels.Models;

namespace UsersApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        try
        {
            return Ok(await _userService.GetUserAsync(id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUser(User newUser)
    {
        try
        {
            await _userService.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.UserId }, newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User updatedUser)
    {
        try
        {
            await _userService.UpdateUserAsync(id, updatedUser);
            return Ok(new { message = "User updated successfully!" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = "An error occurred while updating the user.", details = ex.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return Ok(new { message = "User deleted successfully!" });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = "An error occurred while deleting the user.", details = ex.Message });
        }
    }
}
    