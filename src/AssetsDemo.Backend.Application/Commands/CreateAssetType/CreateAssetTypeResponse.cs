// -------------------------------------------------------------------------------------
//  <copyright file="CreateAssetTypeResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.CreateAssetType;

public record CreateAssetTypeResponse(bool Success, Guid Id);