// -------------------------------------------------------------------------------------
//  <copyright file="CreateAssetCommand.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.CreateAsset;

using MediatR;

public record CreateAssetCommand : IRequest<CreateAssetResponse>
{
    public Guid AssetTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}