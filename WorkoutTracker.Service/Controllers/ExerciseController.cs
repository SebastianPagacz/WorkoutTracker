using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Application.Command.ExerciseCommand;
using WorkoutPlanner.Application.Query.ExerciseQuery;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Models;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutTracker.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(ExerciseDto exercise)
    {
        var result = await mediator.Send(new AddExerciseCommand
        {
            Name = exercise.Name,
            BodyPart = exercise.BodyPart,
        });
        return StatusCode(200, result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetExerciseQuery());
        return StatusCode(200, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetExerciseByIdQuery { Id = id });

        return StatusCode(200, result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, ExerciseDto exercise)
    {
        var result = await mediator.Send(new PatchExerciseCommand 
        {
            Id = id,
            Name = exercise.Name,
            BodyPart = exercise.BodyPart,
        });

        return StatusCode(200, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteExerciseCommand { Id = id });

        return StatusCode(200, result);
    }
}
