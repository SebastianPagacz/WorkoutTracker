using MediatR;
using WorkoutTracker.Domain.Dto;

namespace WorkoutPlanner.Application.Command.SetCommand;

public record PatchSetCommand : IRequest<SetDto>
{
    public int Id { get; set; }
    public int? Repetitions { get; set; }
    public decimal? Weigth { get; set; }
}
