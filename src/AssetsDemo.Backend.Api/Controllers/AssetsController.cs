// -------------------------------------------------------------------------------------
//  <copyright file="AssetsController.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Api.Controllers;

using System.Net.Mime;
using Application.Commands.CreateAsset;
using Application.Commands.UpdateAsset;
using Application.Queries.GetAllAssets;
using Application.Queries.GetAssetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
    private readonly ISender _mediator;

    public AssetsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "The asset was created.", typeof(CreateAssetResponse))]
    [ProducesResponseType(typeof(CreateAssetResponse), StatusCodes.Status201Created)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateAssetCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = response.Id }, response);
    }

    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "The assets.", typeof(List<GetAllAssetsResponse>))]
    [ProducesResponseType(typeof(List<GetAllAssetsResponse>), StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAssetsQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "The asset.", typeof(GetAssetByIdResponse))]
    [ProducesResponseType(typeof(GetAssetByIdResponse), StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The asset was not found.", typeof(ProblemDetails))]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAssetByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The asset was updated.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateAssetCommand request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}