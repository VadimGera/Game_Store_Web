namespace GameStore.Models;

public class User : BaseModel
{
    
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

    /// <summary>
    /// Отзывы пользователя
    /// </summary>
    //public GameReview[]? Reviews {get;set;} тоже самое
    public ICollection<GameReview>? Reviews { get; set; }
    
    /// <summary>
    /// Купленные игры
    /// </summary>
    public ICollection<Game>? BoughtGames { get; set; }

    /// <summary>
    /// Покупка пользователм игр
    /// </summary>
    public ICollection<BuyingGames>? BuyingGames { get; set; }
}