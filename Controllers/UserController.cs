using GameStore.Data;
using GameStore.Dtos;
using GameStore.Dtos.Game;
using GameStore.Models;
using GameStore.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(ApplicationContext context, IUserService userService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddGameToUser(AddGameToUserDto dto)
    {
        return Ok(await userService.AddGameToUser(dto));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userService.GetUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById (int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user is null) 
            return NotFound();
        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        //var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        var user = await context.Users.FindAsync(id);

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(UpdateUserDto dto)
    {

        if (dto.Id < 0)
            return BadRequest();
        
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (user is null)
            return NotFound();

        user.Username = dto.UserName;
        
        await context.SaveChangesAsync();

        return NoContent();

    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await context.Users
            .FindAsync(id);
        
        if (user is null)
            return NotFound();


        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> UserExists(int id)
    {
        return Ok(await context.Users.AnyAsync(e => e.Id == id));
    }

    [HttpGet]
    public async Task<IActionResult> AddUsers()
    {
        var names = new List<string>() { "Alex", "Bob", "Vadim", "Oleg" };

        foreach (var name in names)
        {
            context.Users.Add(new User
            {
                Username = name,
                Email = $"{name}@gmail.com",
                CreateDate = DateTime.UtcNow
            });
        }

        await context.SaveChangesAsync();

        return Ok();
    }



}