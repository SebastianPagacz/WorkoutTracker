
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Repository.Repositories;

public class ExerciseRepository(DataContext context) : IExerciseRepository
{
    public async Task<ExerciseModel> AddASync(ExerciseModel exercise)
    {
        await context.Exercises.AddAsync(exercise);
        await context.SaveChangesAsync();

        return exercise;
    }

    public async Task<List<ExerciseModel>> GetAsync()
    {
        return await context.Exercises.ToListAsync();
    }

    public async Task<ExerciseModel> GetByIdAsync(int id)
    {
        return await context.Exercises.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("cipka");
    }

    public async Task UpdateAsync()
    {
        await context.SaveChangesAsync();
    }
}
