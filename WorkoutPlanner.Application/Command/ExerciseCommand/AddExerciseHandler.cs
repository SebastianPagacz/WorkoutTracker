using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Models;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.ExerciseCommand;

public class AddExerciseHandler(IExerciseRepository repository, IMapper mapper) : IRequestHandler<AddExerciseCommand, ExerciseDto>
{
    public async Task<ExerciseDto> Handle(AddExerciseCommand request, CancellationToken cancellationToken)
    {
        ExerciseModel newExercise = new ExerciseModel
        {
            Name = request.Name,
            BodyPart = request.BodyPart,
            IsDeleted = false
        };

        await repository.AddASync(newExercise);

        return mapper.Map<ExerciseDto>(newExercise);
    }
}
