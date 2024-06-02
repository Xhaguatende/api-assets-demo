// -------------------------------------------------------------------------------------
//  <copyright file="GetAssetByIdQueryHandler.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAssetById;

using Domain.Assets.Exceptions;
using MediatR;
using Repositories;

public class GetAssetByIdQueryHandler : IRequestHandler<GetAssetByIdQuery, GetAssetByIdResponse>
{
    private readonly IAssetRepository _assetRepository;

    public GetAssetByIdQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<GetAssetByIdResponse> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

        if (asset is null)
        {
            throw new AssetNotFoundException(request.Id);
        }

        return new GetAssetByIdResponse
        {
            Id = asset.Id,
            AssetTypeId = asset.AssetTypeId,
            Description = asset.Description,
            Name = asset.Name
        };
    }
}