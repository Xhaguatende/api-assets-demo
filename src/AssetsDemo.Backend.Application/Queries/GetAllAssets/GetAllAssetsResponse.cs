// -------------------------------------------------------------------------------------
//  <copyright file="GetAllAssetsResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAllAssets;

public record GetAllAssetsResponse
{
    public string AssetType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}