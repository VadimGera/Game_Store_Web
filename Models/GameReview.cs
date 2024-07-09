namespace GameStore.Models;

public class GameReview : BaseModel
{
    public required User User { get; set; }

    public required Game Game { get; set; }
    
    public decimal Rating { get; set; }
    
    public string? Description { get; set; }
}