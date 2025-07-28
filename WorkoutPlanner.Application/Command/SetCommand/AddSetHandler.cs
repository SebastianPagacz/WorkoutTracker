using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Exceptions;
using WorkoutTracker.Domain.Models;
using WorkoutTracker.Domain.Repository;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.SetCommand;

public class AddSetHandler(ISetRepository setRepository, IExerciseRepository exerciseRepository,IMapper mapper) : IRequestHandler<AddSetCommand, SetDto>
{
    public async Task<SetDto> Handle(AddSetCommand request, CancellationToken cancellationToken)
    {
        var exisitingExercise = await exerciseRepository.GetByIdAsync(request.ExerciseId) ?? throw new ItemNotFoundException($"Exercise with id {request.ExerciseId} does not exisit");

        var newSet = new SetModel
        {
            Repetitions = request.Repetitions,
            Weigth = request.Weigth,
            ExerciseId = request.ExerciseId,
            WorkoutId = request.WorkoutId,
        };

        await setRepository.AddAsync(newSet);

        return mapper.Map<SetDto>(newSet);
    }
}
