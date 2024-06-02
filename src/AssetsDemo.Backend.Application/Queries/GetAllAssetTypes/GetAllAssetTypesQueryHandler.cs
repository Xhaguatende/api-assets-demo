// -------------------------------------------------------------------------------------
//  <copyright file="GetAllAssetTypesQueryHandler.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAllAssetTypes;

using MediatR;
using Repositories;

public class GetAllAssetTypesQueryHandler : IRequestHandler<GetAllAssetTypesQuery, List<GetAllAssetTypesResponse>>
{
    private readonly IAssetTypeRepository _assetTypeRepository;

    public GetAllAssetTypesQueryHandler(IAssetTypeRepository assetTypeRepository)
    {
        _assetTypeRepository = assetTypeRepository;
    }

    public async Task<List<GetAllAssetTypesResponse>> Handle(
        GetAllAssetTypesQuery request,
        CancellationToken cancellationToken)
    {
        var assetTypes = await _assetTypeRepository.GetAllAsync(cancellationToken: cancellationToken);

        return assetTypes.Select(
            assetType => new GetAllAssetTypesResponse
            {
                Id = assetType.Id,
                Name = assetType.Name,
                Description = assetType.Description
            }).ToList();
    }
}