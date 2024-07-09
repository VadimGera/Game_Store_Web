using GameStore.Dtos.Game;
using GameStore.Models;

namespace GameStore.Dtos.User;

/// <summary>
/// То, что мы будет отдвавать на фронь
/// </summary>
public class UserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Юзер нейм
    /// </summary>
    public required string Username { get; set; }   
    
    /// <summary>
    /// Почта пользоватедя
    /// </summary>
    public required string Email { get; set; } = null!;
    
    /// <summary>
    /// Статус пользователя
    /// </summary>
    public UserStatus Status { get; set; }
    
    
    /// <summary>
    /// Сумма на балансе
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Подтвержден ли email
    /// </summary>
    public bool IsEmailVerified { get; set; }
    
    public List<GameDto>? BoughtGames { get; set; }
}