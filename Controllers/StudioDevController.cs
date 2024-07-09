using GameStore.Data;
using GameStore.Dtos.StudioDev;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class StudioDevController(ApplicationContext context) : ControllerBase
{
    [HttpPost]
    public async Task<int> CreateStudioDev(CreateStudioDevDto dto)
    {
        var studio = new StudioDev
        {
            Name = dto.Name
        };

        context.Add(studio);

        await context.SaveChangesAsync();

        return studio.Id;
    }
}