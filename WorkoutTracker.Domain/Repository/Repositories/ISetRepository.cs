using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Repository.Repositories;

public interface ISetRepository
{
    public Task<SetModel> AddAsync(SetModel set);
    public Task<List<SetModel>> GetAsync();
    public Task<SetModel> GetByIdAsync(int id);
    public Task UpdateAsync(SetModel set);
}
