using Game.Inventory.Application.Commands.Grant;
using Game.Inventory.Application.InventoryItems.Queries.Find;
using Game.Inventory.Application.Queries.Find;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Game.Inventory.WebApi.Controllers;

[ApiController]
[Route("items")]
[Produces("application/json")]
public class InventoryItemsController : ControllerBase
{
    private readonly ISender _mediator;

    public InventoryItemsController(ISender mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a list of items granted to the user provided
    /// </summary>
    /// <returns>
    /// A list of inventory items
    /// </returns>
    /// <remarks>
    /// <para>Sample request:</para>
    /// <para>
    ///     GET /items/c1ef1215-43f7-455b-8d5a-3a61e62effa5
    /// </para>
    /// </remarks>
    /// <response code="200"></response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<InventoryItemDto>>> GetByIdAsync([FromRoute] Guid id) =>
        Ok(await _mediator.Send(new FindInventoryItemsByUserIdQuery(id)));

    /// <summary>
    /// Creates a new item
    /// </summary>
    /// <returns>
    /// The id of the newly created item
    /// </returns>
    /// <remarks>
    /// <para>Sample request:</para>
    /// <para>
    ///     POST /items
    ///     {
    ///        "userId": "c1ef1215-43f7-455b-8d5a-3a61e62effa5",
    ///        "catalogItemId": "7fffed1c-f09c-4e53-a102-55cb501c0102",
    ///        "quantity": 2
    ///     }
    /// </para>
    /// </remarks>
    /// <response code="204">The catalog item was granted successfully</response>
    /// <response code="400">The request parameter is invalid</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAsync(GrantCatalogItemCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}