using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Repository;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutTracker.Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Database
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase("TestDb"));

        // Repositories
        builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
