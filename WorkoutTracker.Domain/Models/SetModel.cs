using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Domain.Models;

public class SetModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public int Repetitions { get; set; }
    public decimal Weigth { get; set; }
    public bool IsDeleted { get; set; } = false;
    
    // Relations
    public int ExerciseId { get; set; }
    public ExerciseModel Exercise { get; set; } = default!;

    public int WorkoutId { get; set; }
    public WorkoutModel Workout { get; set; } = default!;
}
