
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weelo.Application.Property.Commands;
using Weelo.Application.Property.Queries;
using Weelo.Application.PropertyImagen.Commands;

namespace Weelo.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PropertyImageController
{

    readonly IMediator _mediator = default!;

    public PropertyImageController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// dd Image from property
    /// </summary>
    /// <param name="propertyImage"></param>
    /// <response code="200">Successful response.</response>
    /// <response code="400">Invalid input values.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="500">Processing error.</response>
    [HttpPost]
    public async Task Post([FromForm] PropertyImageCreateCommand propertyImage) => await _mediator.Send(propertyImage);
}

