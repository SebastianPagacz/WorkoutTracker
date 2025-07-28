using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Command.SetCommand;

public record AddSetCommand : IRequest<SetDto>
{
    public int Repetitions { get; set; }
    public decimal Weigth { get; set; }
    public int ExerciseId { get; set; }
    public int WorkoutId { get; set; }
}
