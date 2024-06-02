// -------------------------------------------------------------------------------------
//  <copyright file="CreateAssetResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.CreateAsset;

public record CreateAssetResponse(bool Success, Guid Id);