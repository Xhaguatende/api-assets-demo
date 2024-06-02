// -------------------------------------------------------------------------------------
//  <copyright file="AssetTypeRepository.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Infrastructure.Repositories;

using Application.Repositories;
using Base;
using Database;
using Domain.AssetTypes;

public class AssetTypeRepository : BaseRepository<AssetType, Guid>, IAssetTypeRepository
{
    public AssetTypeRepository(AssetsContext context) : base(context)
    {
    }
}