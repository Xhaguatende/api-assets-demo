// -------------------------------------------------------------------------------------
//  <copyright file="Asset.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Domain.Assets;

using AssetTypes;
using Primitives;

public class Asset : Entity<Guid>
{
    public Asset(Guid id) : base(id)
    {
    }

    public AssetType AssetType { get; set; } = default!;
    public Guid AssetTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}