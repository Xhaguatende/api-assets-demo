// -------------------------------------------------------------------------------------
//  <copyright file="UpdateAssetResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Commands.UpdateAsset;

public record UpdateAssetResponse(bool Success, Guid Id, string Message);