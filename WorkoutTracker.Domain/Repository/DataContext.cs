using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Repository;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<ExerciseModel> Exercises { get; set; }
    public DbSet<SetModel> Sets { get; set; }
    public DbSet<WorkoutModel> Workouts { get; set; }
}
