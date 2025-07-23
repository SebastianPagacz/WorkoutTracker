using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Domain.Models;

public class ExerciseModel
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string ExerciseName { get; set; } = string.Empty;
    
    [Required]
    public BodyPartEnum BodyPart { get; set; }

    public bool IsDeleted { get; set; }
}
