// -------------------------------------------------------------------------------------
//  <copyright file="GetAllAssetTypesResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAllAssetTypes;

public record GetAllAssetTypesResponse
{
    public string Description { get; init; } = string.Empty;
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
}