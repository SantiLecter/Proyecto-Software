using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityApp.Application.Features.Examen.Commands.CreateExamen;
using System.Net;
using SecurityApp.Application.Features.Examen.Queries;
using SecurityApp.Application.Features.Examen.Queries.GetExamenByAnimal;
using SecurityApp.Application.Features.Examen.Commands.UpdateExamen;
using SecurityApp.Application.Features.Examen.Commands.DeleteExamen;

namespace SecurityApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ExamenController : ControllerBase
{
    private IMediator _mediator;

    public ExamenController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<ExamenVm>> GetExamenByAnimalID(string id)
    {
        var query = new GetExamenByAnimalQuery(id);
        var examen = await _mediator.Send(query);
        return examen;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    //[Authorize]
    public async Task<ActionResult<string>> CreateExamen([FromBody] CreateExamenCommand command)
    {
        var newExamen = await _mediator.Send(command);
        return newExamen;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    //[Authorize]
    public async Task<ActionResult> UpdateExamen(string id, [FromBody] UpdateExamenCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("El ID especificado en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    //[Authorize]
    public async Task<ActionResult> DeleteExamen(string id, [FromBody] DeleteExamenCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("El ID especificado en la URL no coincide con el ID en el cuerpo de la solicitud.");
        }

        await _mediator.Send(command);
        return NoContent();
    }
}