namespace GameStore.Models;

public class BuyingGames : BaseModel
{
    public required User User { get; set; }
    public required Game Game { get; set; }
    public decimal Price { get; set; }
    public Coupon? Coupon { get; set; }
    public bool IsSuccess { get; set; }
}