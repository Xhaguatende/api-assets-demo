// -------------------------------------------------------------------------------------
//  <copyright file="AssetType.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Domain.AssetTypes;

using Assets;
using Primitives;

public class AssetType : Entity<Guid>
{
    public AssetType(Guid id) : base(id)
    {
        Assets = new HashSet<Asset>();
    }

    public ICollection<Asset> Assets { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}