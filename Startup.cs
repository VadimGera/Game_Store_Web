using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Service;

var builder = WebApplication.CreateBuilder(args);

//TODO IGameService
//TODO GameReviewService

//TODO Create GameReview Controller
//TODO Update Game controller

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));



builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();