// -------------------------------------------------------------------------------------
//  <copyright file="GetAssetByIdResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAssetById;

public record GetAssetByIdResponse
{
    public Guid AssetTypeId { get; set; }

    public string Description { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}