using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Domain.Models;

public class WorkoutModel
{
    public int Id { get; set; }
    public DateOnly TimeStamp { get; set; }
}
