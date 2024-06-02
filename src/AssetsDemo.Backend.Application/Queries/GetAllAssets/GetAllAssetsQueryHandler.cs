// -------------------------------------------------------------------------------------
//  <copyright file="GetAllAssetsQueryHandler.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAllAssets;

using System.Linq.Expressions;
using Domain.Assets;
using MediatR;
using Repositories;

public class GetAllAssetsQueryHandler : IRequestHandler<GetAllAssetsQuery, List<GetAllAssetsResponse>>
{
    private readonly IAssetRepository _assetRepository;

    public GetAllAssetsQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<List<GetAllAssetsResponse>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
    {
        var includes = new Expression<Func<Asset, object>>[]
        {
            asset => asset.AssetType
        };

        var assets = await _assetRepository.GetAllAsync(includes, cancellationToken);

        return assets.Select(asset => new GetAllAssetsResponse
        {
            Id = asset.Id,
            AssetType = asset.AssetType.Name,
            Description = asset.Description,
            Name = asset.Name
        }).ToList();
    }
}