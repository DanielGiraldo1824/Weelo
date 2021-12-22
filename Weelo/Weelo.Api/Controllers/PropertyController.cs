
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weelo.Application.Property.Commands;
using Weelo.Application.Property.Queries;

namespace Weelo.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PropertyController
{

    readonly IMediator _mediator = default!;

    public PropertyController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// Get property building by filters
    /// </summary>
    /// <param name="filter"></param>
    [HttpGet]
    public async Task<IEnumerable<PropertyDto>> Get([FromQuery] PropertyFilter filter) => await _mediator.Send(new PropertyQuery(filter.Address, filter.Name, filter.InternalCode, filter.OwnerName));

    /// <summary>
    /// Create property building
    /// </summary>
    /// <param name="property"></param>
    /// <response code="200">Successful response.</response>
    /// <response code="400">Invalid input values.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="500">Processing error.</response>
    [HttpPost]
    public async Task Post(PropertyCreateCommand property) => await _mediator.Send(property);

    /// <summary>
    /// Update property building
    /// </summary>
    /// <param name="property"></param>
    /// <response code="200">Successful response.</response>
    /// <response code="400">Invalid input values.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="500">Processing error.</response>
    [HttpPut]
    public async Task Put(PropertyUpdateCommand property) => await _mediator.Send(property);

}
