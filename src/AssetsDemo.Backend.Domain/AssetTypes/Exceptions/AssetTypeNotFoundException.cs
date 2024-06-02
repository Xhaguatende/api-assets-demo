// -------------------------------------------------------------------------------------
//  <copyright file="AssetTypeNotFoundException.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Domain.AssetTypes.Exceptions;

using Domain.Exceptions;

public class AssetTypeNotFoundException : NotFoundException
{
    public AssetTypeNotFoundException(Guid id) : base($"Asset type with Id: '{id}' was not found.")
    {
    }
}