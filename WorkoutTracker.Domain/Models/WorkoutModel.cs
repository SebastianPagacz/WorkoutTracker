using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Domain.Models;

public class WorkoutModel
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Name { get; set; } = string.Empty;
}
