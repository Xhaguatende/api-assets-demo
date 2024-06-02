// -------------------------------------------------------------------------------------
//  <copyright file="IAssetRepository.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Repositories;

using Domain.Assets;

public interface IAssetRepository : IRepository<Asset, Guid>;