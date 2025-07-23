using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Application.Query.ExerciseQuery;
using WorkoutTracker.Domain.Dto;
using WorkoutTracker.Domain.Models;
using WorkoutTracker.Domain.Repository.Repositories;

namespace WorkoutTracker.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController(IExerciseRepository repository, IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(ExerciseModel exercise)
    {
        await repository.AddASync(exercise);
        return StatusCode(200, exercise);
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
            var result = await repository.GetByIdAsync(id);
            return StatusCode(200, result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, ExerciseDto exercise)
    {
        var existing = await repository.GetByIdAsync(id);

        existing.Name = exercise.Name;
        existing.BodyPart = exercise.BodyPart;

        await repository.UpdateAsync();

        return StatusCode(200, existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await repository.GetByIdAsync(id);

        existing.IsDeleted = true;

        await repository.UpdateAsync();
        return StatusCode(200, new { Message = $"Succesfully deleted exercise {id}"});
    }
}
