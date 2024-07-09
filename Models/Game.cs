namespace GameStore.Models;

public class Game : BaseModel
{
    public string? GameName { get; set; }
    
    public string? GameDescription { get; set; }

    public decimal AverageRating { get; set; }
    public decimal Privce { get; set; }

    public required StudioDev StudioDev { get; set; }

    public ICollection<GameReview>? Reviews { get; set; }
    
    public ICollection<User>? UsersWhoBoughtGame { get; set; }
    
    public ICollection<BuyingGames>? BuyingGames { get; set; }
}