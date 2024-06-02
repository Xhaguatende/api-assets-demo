// -------------------------------------------------------------------------------------
//  <copyright file="AssetNotFoundException.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Domain.Assets.Exceptions;

using Domain.Exceptions;

public class AssetNotFoundException : NotFoundException
{
    public AssetNotFoundException(Guid id) : base($"Asset with Id: '{id}' was not found.")
    {
    }
}