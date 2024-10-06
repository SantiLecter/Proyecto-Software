using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SecurityApp.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CuidadoController : ControllerBase
{
    private IMediator _mediator;

    public CuidadoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
}