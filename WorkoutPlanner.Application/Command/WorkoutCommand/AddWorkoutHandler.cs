using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Models;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.WorkoutCommand;

public class AddWorkoutHandler(IWorkoutRepository repository, IMapper mapper) : IRequestHandler<AddWorkoutCommand, WorkoutDto>
{
    public async Task<WorkoutDto> Handle(AddWorkoutCommand request, CancellationToken cancellationToken)
    {
        WorkoutModel newWorkout = new WorkoutModel
        {
            Date = request.Date,
            Name = request.Name,
        };

        await repository.AddAsync(newWorkout);

        return mapper.Map<WorkoutDto>(newWorkout);
    }
}
