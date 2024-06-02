// -------------------------------------------------------------------------------------
//  <copyright file="IAssetTypeRepository.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Repositories;

using Domain.AssetTypes;

public interface IAssetTypeRepository : IRepository<AssetType, Guid>;