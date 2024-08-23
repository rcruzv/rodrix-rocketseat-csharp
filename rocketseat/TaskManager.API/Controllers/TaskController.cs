using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCase.TaskManager.Delete;
using TaskManager.Application.UseCase.TaskManager.Get;
using TaskManager.Application.UseCase.TaskManager.GetAll;
using TaskManager.Application.UseCase.TaskManager.Register;
using TaskManager.Application.UseCase.TaskManager.Update;
using TaskManager.Comunication.Request;
using TaskManager.Comunication.Response;

namespace TaskManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(TaskRegisterResponse), StatusCodes.Status201Created)]
    public IActionResult Register(TaskRequest request)
    {
        return base.Created(string.Empty,
            new RegisterUseCase().Execute(request)
        );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] TaskRequest request)
    {
        new UpdateUseCase().Execute(id, request);
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TaskGetByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get([FromRoute] int id)
    {
        return Ok(
            new GetByIdUseCase().Execute(id)
        );
    }

    [HttpGet()]
    [ProducesResponseType(typeof(TaskGetAllResponse), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return Ok(
            new GetAllUseCase().Execute()
        );
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Delete([FromRoute] int id)
    {
        new DeleteUseCase().Execute(id);
        return Ok();
    }
}
