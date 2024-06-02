// -------------------------------------------------------------------------------------
//  <copyright file="AssetRepository.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Infrastructure.Repositories;

using Application.Repositories;
using Base;
using Database;
using Domain.Assets;

public class AssetRepository : BaseRepository<Asset, Guid>, IAssetRepository
{
    public AssetRepository(AssetsContext context) : base(context)
    {
    }
}