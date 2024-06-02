// -------------------------------------------------------------------------------------
//  <copyright file="GetAssetTypeByIdQueryHandler.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Queries.GetAssetTypeById;

using Domain.AssetTypes.Exceptions;
using MediatR;
using Repositories;

public class GetAssetTypeByIdQueryHandler : IRequestHandler<GetAssetTypeByIdQuery, GetAssetTypeByIdResponse>
{
    private readonly IAssetTypeRepository _assetTypeRepository;

    public GetAssetTypeByIdQueryHandler(IAssetTypeRepository assetTypeRepository)
    {
        _assetTypeRepository = assetTypeRepository;
    }

    public async Task<GetAssetTypeByIdResponse> Handle(
        GetAssetTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var assetType = await _assetTypeRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

        if (assetType is null)
        {
            throw new AssetTypeNotFoundException(request.Id);
        }

        return new GetAssetTypeByIdResponse
        {
            Id = assetType.Id,
            Description = assetType.Description,
            Name = assetType.Name
        };
    }
}