namespace GameStore.Dtos.Game;

public class AddGameToUserDto
{
    public required int GameId { get; set; }
    public required int UserId { get; set; }
}