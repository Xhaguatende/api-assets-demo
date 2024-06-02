// -------------------------------------------------------------------------------------
//  <copyright file="AssetTypesController.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Api.Controllers;

using System.Net.Mime;
using Application.Commands.CreateAssetType;
using Application.Queries.GetAllAssetTypes;
using Application.Queries.GetAssetTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[Route("api/[controller]")]
[ApiController]
public class AssetTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "The asset type was created.", typeof(CreateAssetTypeResponse))]
    [ProducesResponseType(typeof(CreateAssetTypeResponse), StatusCodes.Status201Created)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> CreateAssetType([FromBody] CreateAssetTypeCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = response.Id }, response);
    }

    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "The asset types.", typeof(List<GetAllAssetTypesResponse>))]
    [ProducesResponseType(typeof(List<GetAllAssetTypesResponse>), StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllAssetTypesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "The asset type.", typeof(GetAssetTypeByIdResponse))]
    [ProducesResponseType(typeof(GetAssetTypeByIdResponse), StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The asset type was not found.", typeof(ProblemDetails))]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAssetTypeByIdQuery(id), cancellationToken);
        return Ok(response);
    }
}