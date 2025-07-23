using AutoMapper;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Models;

namespace WorkoutTracker.Domain.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ExerciseModel, ExerciseDto>();
    }
}
