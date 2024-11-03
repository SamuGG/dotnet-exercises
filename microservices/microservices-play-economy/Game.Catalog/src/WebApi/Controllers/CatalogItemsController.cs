using Game.Catalog.Application.Commands.Create;
using Game.Catalog.Application.Commands.Delete;
using Game.Catalog.Application.Commands.Update;
using Game.Catalog.Application.CatalogItems.Queries.Find;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Game.Catalog.WebApi.Controllers;

[ApiController]
[Route("items")]
[Produces("application/json")]
public class CatalogItemsController : ControllerBase
{
    private readonly ISender _mediator;

    public CatalogItemsController(ISender mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        _mediator = mediator;
    }

    /// <summary>
    /// Returns all items
    /// </summary>
    /// <returns>
    /// A read-only collection of items
    /// </returns>
    /// <response code="200">Always</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<CatalogItemDto>>> GetAsync() =>
        Ok(await _mediator.Send(new FindCatalogItemsQuery()));

    /// <summary>
    /// Returns single item with the given id
    /// </summary>
    /// <returns>
    /// A catalog item
    /// </returns>
    /// <remarks>
    /// <para>Sample request:</para>
    /// <para>
    ///    GET /items/7fffed1c-f09c-4e53-a102-55cb501c0102
    /// </para>
    /// </remarks>
    /// <response code="200">The item was retrieved successfully</response>
    /// <response code="404">The item couldn't be found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CatalogItemDto>> GetByIdAsync([FromRoute] Guid id)
    {
        var catalogItem = await _mediator.Send(new FindCatalogItemByIdQuery(id));
        return catalogItem is null ? NotFound() : Ok(catalogItem);
    }

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
    ///        "name": "Potion",
    ///        "description": "Restores a small amount of HP",
    ///        "price": 5
    ///     }
    /// </para>
    /// </remarks>
    /// <response code="201">The item was created successfully</response>
    /// <response code="400">The request parameter is invalid</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> PostAsync(CreateCatalogItemCommand command)
    {
        Guid newCatalogItemId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = newCatalogItemId }, newCatalogItemId);
    }

    /// <summary>
    /// Updates an existing item
    /// </summary>
    /// <returns>
    /// Nothing
    /// </returns>
    /// <remarks>
    /// <para>Sample request:</para>
    /// <para>
    ///     PUT /items
    ///     {
    ///        "id": "7fffed1c-f09c-4e53-a102-55cb501c0102",
    ///        "name": "Potion",
    ///        "description": "Restores some amount of HP",
    ///        "price": 7
    ///     }
    /// </para>
    /// </remarks>
    /// <response code="204">The item was updated successfully</response>
    /// <response code="400">The request parameter is invalid</response>
    /// <response code="404">The item couldn't be found</response>
    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutAsync(UpdateCatalogItemCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes an existing item
    /// </summary>
    /// <returns>
    /// Nothing
    /// </returns>
    /// <remarks>
    /// <para>Sample request:</para>
    /// <para>
    ///     DELETE /items/7fffed1c-f09c-4e53-a102-55cb501c0102
    /// </para>
    /// </remarks>
    /// <response code="204">The item was deleted successfully</response>
    /// <response code="404">The item couldn't be found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteCatalogItemCommand(id));
        return NoContent();
    }
}