using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Repository.Repositories;

public interface IWorkoutRepository
{
    public Task<WorkoutModel> AddAsync(WorkoutModel workout);
    public Task<List<WorkoutModel>> GetAsync();
    public Task<WorkoutModel> GetByIdAsync(int id);
    public Task UpdateAsync(WorkoutModel workout);
}
