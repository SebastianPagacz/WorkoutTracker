using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WorkoutPlanner.Application.Command.SetCommand;
using WorkoutPlanner.Application.Query.SetQuery;
using WorkoutTracker.Domain.Dto;

namespace WorkoutTracker.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SetController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(SetDto set, int exerciseId, int workoutId)
    {
        var result = await mediator.Send(new AddSetCommand
        {
            Repetitions = set.Repetitions,
            Weigth = set.Weigth,
            ExerciseId = exerciseId,
            WorkoutId = workoutId
        });

        return StatusCode(200, result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetSetsCommand());

        return StatusCode(200, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetSetByIdQuery { Id = id });

        return StatusCode(200, result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, SetDto set)
    {
        var result = await mediator.Send(new PatchSetCommand
        {
            Id = id,
            Repetitions = set.Repetitions,
            Weigth = set.Weigth,
        });

        return StatusCode(200, result);
    }
}
