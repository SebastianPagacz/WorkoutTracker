using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Repository.Repositories;

public class WorkoutRepository(DataContext context) : IWorkoutRepository
{
    public async Task<WorkoutModel> AddAsync(WorkoutModel workout)
    {
        await context.Workouts.AddAsync(workout);
        await context.SaveChangesAsync();
        return workout;
    }

    public async Task<List<WorkoutModel>> GetAsync()
    {
        return await context.Workouts.ToListAsync();
    }

    public async Task<WorkoutModel> GetByIdAsync(int id)
    {
        return await context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task UpdateAsync(WorkoutModel workout)
    {
        await context.SaveChangesAsync();
    }
}
