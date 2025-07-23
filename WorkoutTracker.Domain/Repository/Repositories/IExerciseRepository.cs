using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Repository.Repositories;

public interface IExerciseRepository
{
    public Task<ExerciseModel> AddASync(ExerciseModel exercise);
    public Task<ExerciseModel> GetByIdAsync(int id);
    public Task<List<ExerciseModel>> GetAsync();
    public Task UpdateAsync();
}
