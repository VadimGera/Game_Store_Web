using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore;
using GameStore.Data;
using GameStore.Dtos.Game;
using GameStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;

//http://localhost:1234/api/Game/GetGames

[ApiController]
[Route("api/[controller]/[action]")]
public class GameController : ControllerBase
{
    private readonly ApplicationContext _context;
    
    public GameController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    {
        return await _context.Games.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await _context.Games.FindAsync(id);

        if (game == null)
        {
            return NotFound();
        }

        return game;
    }

    [HttpPost]
    public async Task<IActionResult> PostGame(CreateGameDto dto)
    {
        var studioDev = await _context.StudioDevs.FindAsync(dto.StudioDevId);

        if (studioDev is null)
            return NotFound();

        var game = new Game
        {
            StudioDev = studioDev,
            GameName = dto.Name
        };
        
        _context.Games.Add(game);
        
        await _context.SaveChangesAsync();

        return Ok(game.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(int id, Game game)
    {
        if (id != game.Id)
        {
            return BadRequest();
        }

        _context.Entry(game).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GameExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GameExists(int id)
    {
        return _context.Games.Any(e => e.Id == id);
    }
}

    

