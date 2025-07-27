using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Repository.Repositories;

public class SetRepository(DataContext context) : ISetRepository
{
    public async Task<SetModel> AddAsync(SetModel set)
    {
        await context.Sets.AddAsync(set);
        await context.SaveChangesAsync();

        return set;
    }

    public async Task<List<SetModel>> GetAsync()
    {
        return await context.Sets.ToListAsync();
    }

    public async Task<SetModel> GetByIdAsync(int id)
    {
        return await context.Sets.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task UpdateAsync(SetModel set)
    {
        await context.SaveChangesAsync();
    }
}
