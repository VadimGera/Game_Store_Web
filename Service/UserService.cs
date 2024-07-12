using GameStore.Data;
using GameStore.Dtos.Game;
using GameStore.Dtos.User;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Service;

/// <summary>
/// Реализация абстракции взаимодейтсвия с пользователями
/// </summary>
/// <param name="context"></param>
public class UserService(ApplicationContext context) : IUserService
{
    public async Task<List<UserDto>> GetUsers()
    {
        return await context.Users
            .Include(x => x.BoughtGames)
            .Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Status = user.Status,
                Balance = user.Balance,
                IsEmailVerified = user.IsEmailVerified,
                BoughtGames = user.BoughtGames.Select(game => new GameDto
                {
                    Id = game.Id,
                    GameName = game.GameName
                }).ToList()
            }).ToListAsync();
        
        
    }

    public async Task<UserDto> GetUserById (int id)
    {
        var user = await context.Users
            .Include(x => x.BoughtGames)
            .Select(x => new UserDto
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                Status = x.Status,
                Balance = x.Balance,
                IsEmailVerified = x.IsEmailVerified,
                BoughtGames = x.BoughtGames.Select(game => new GameDto
                {
                    Id = game.Id,
                    GameName = game.GameName
                }).ToList()
            })
            .FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<bool> AddGameToUser(AddGameToUserDto dto)
    {
        var user = await context.Users
            .Include(x => x.BoughtGames)
            .FirstOrDefaultAsync(x => x.Id == dto.UserId);

        if (user is null)
            return false;


        if (user.BoughtGames != null && user.BoughtGames.Any(x => x.Id == dto.GameId))
            return false;

        var game = await context.Games.FindAsync(dto.GameId);

        if (game is null)
            return false;


        user.BoughtGames ??= new List<Game>();

        user.BoughtGames.Add(game);

        await context.SaveChangesAsync();

        return true;
    }
}


/// <summary>
/// Абстракция взаимодейтсвия с пользователями
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Метод, который будет отдавать коллекцию пользователей
    /// </summary>
    /// <returns>Коллекцию пользователй</returns>
    public Task<List<UserDto>> GetUsers();

    /// <summary>
    /// Добавить игру пользователю
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<bool> AddGameToUser(AddGameToUserDto dto);
    //TODO GetUserById(int id)
    //TODO UpdateUser(UpdateUserDto dto)
    //TODO DeleteUser(int id)
    //TODO DeleteUser(User user)
    //TODO CreateUser(CreateUserDto dto)   

    //var user = await context.Users.FindAsync(dto.Id);
    //user.UserName = dto.UserName;
    //....
    // await context.SaveChangesAsync();

}