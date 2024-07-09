namespace GameStore.Dtos.Game;

public class CreateGameDto
{
    public required string Name { get; set; }
    public int StudioDevId { get; set; }
}