// -------------------------------------------------------------------------------------
//  <copyright file="UpdateAssetCommand.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.UpdateAsset;

using MediatR;

public record UpdateAssetCommand : IRequest<UpdateAssetResponse>
{
    public Guid AssetTypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}