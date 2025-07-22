using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Domain.Models;

public class SetModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public decimal Weigth { get; set; }
    
    public int ExerciseId { get; set; }
    public ExerciseModel Exercise { get; set; } = default!;

    public int WorkoutId { get; set; }
    public WorkoutModel Workout { get; set; } = default!;
}
