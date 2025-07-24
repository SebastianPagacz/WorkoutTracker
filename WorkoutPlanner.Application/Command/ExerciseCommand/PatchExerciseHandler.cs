using AutoMapper;
using MediatR;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Enums;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutPlanner.Application.Command.ExerciseCommand;

public class PatchExerciseHandler(IExerciseRepository repository, IMapper mapper) : IRequestHandler<PatchExerciseCommand, ExerciseDto>
{
    public async Task<ExerciseDto> Handle(PatchExerciseCommand request, CancellationToken cancellationToken)
    {
        var existingExercise = await repository.GetByIdAsync(request.Id);

        if (existingExercise == null || existingExercise.IsDeleted)
            throw new Exception("TODO: add custom");

        if(!string.IsNullOrEmpty(request.Name))
            existingExercise.Name = request.Name;

        if(request.BodyPart != null && request.BodyPart != 0)
            existingExercise.BodyPart = (BodyPartEnum)request.BodyPart;

        await repository.UpdateAsync();
        return mapper.Map<ExerciseDto>(existingExercise);
    }
}
